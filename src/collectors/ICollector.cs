﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeCollector.collectors {
    public interface ICollector {
        Task ExecuteAsync(CancellationToken stoppingToken);
    }
}
