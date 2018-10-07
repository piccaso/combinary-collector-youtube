﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google;
using YoutubeCollector.Db;
using YoutubeCollector.Models;
using Google.Apis.Logging;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YoutubeCollector.collectors;
using YoutubeCollector.Lib;
using Video = YoutubeCollector.Models.Video;

namespace YoutubeCollector {
    public class HostedService : BackgroundService {
        private readonly ILogger<HostedService> _logger;
        private readonly Repository _repository;
        private readonly SettingsProvider _settingsProvider;
        private readonly ChannelCollector _channelCollector;
        private readonly CommentCollector _commentCollector;
        private readonly AnswerCollector _answerCollector;

        public HostedService(ILogger<HostedService> logger, Repository repository, SettingsProvider settingsProvider, ChannelCollector channelCollector, CommentCollector commentCollector, AnswerCollector answerCollector) {
            _logger = logger;
            _repository = repository;
            _settingsProvider = settingsProvider;
            _channelCollector = channelCollector;
            _commentCollector = commentCollector;
            _answerCollector = answerCollector;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            await _repository.Migrate();
            var quotaExceeded = false;
            while (!stoppingToken.IsCancellationRequested) {
                try {
                    if (_settingsProvider.CollectVideos) await _channelCollector.ExecuteAsync(stoppingToken);
                    if (_settingsProvider.CollectComments) await _commentCollector.ExecuteAsync(stoppingToken);
                    if (_settingsProvider.CollectAnswers) await _answerCollector.ExecuteAsync(stoppingToken);
                }
                catch (TaskCanceledException) {
                    /* goning down */
                }
                catch (GoogleApiException ex) {
                    quotaExceeded = ex.Error.Errors.Any(e => e.Reason.Contains("Exceeded"));
                    _logger.LogCritical(ex, "GoogleApiException");
                }
                catch (Exception e) {
                    _logger.LogCritical(e, "Critical Error");
                }

                await Idle(stoppingToken, quotaExceeded);
            }
        }

        private async Task Idle(CancellationToken ct, bool quotaExceeded) {
            try {
                var idleMinutes = _settingsProvider.IdleMinutes;
                if (quotaExceeded) {
                    //TODO: Calculate time until quota reset - probably end of the day, but wich timezone?
                    var now = DateTime.UtcNow; // TODO: apply offset 
                    var endOfDay = now.Date.AddHours(24);
                    var diff = endOfDay - now;
                    idleMinutes = ((int) diff.TotalMinutes) + 1;
                }
                var idleUntil = DateTime.Now.AddMinutes(idleMinutes);
                while (idleMinutes > 0) {
                    _logger.LogDebug($"Idle... {idleMinutes} minutes left until {idleUntil}");
                    await Task.Delay(TimeSpan.FromMinutes(1), ct);
                    idleMinutes--;
                }
                   
            }
            catch (TaskCanceledException) {
                /* goning down */
            }
        }
    }
}
