﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace YoutubeCollector.Lib.UrlBucketClient
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class UrlBucketApiClient 
    {
        private string _baseUrl = "";
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
    
        public UrlBucketApiClient(string baseUrl)
        {
            BaseUrl = baseUrl; 
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() => 
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }
    
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
    
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
    
        /// <summary>Stores an asset after downloading it from the given URL.</summary>
        /// <param name="url">The URL where the asset is currently located</param>
        /// <param name="userAgent">Optional, 'user-agent' header to use when downloading (default: null - no user agent)</param>
        /// <param name="overwriteExisting">Optional, overwrite existing file (default: true)</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ProblemDetails> ApiStoreUrlGetAsync(string url, string userAgent, bool? overwriteExisting)
        {
            return ApiStoreUrlGetAsync(url, userAgent, overwriteExisting, System.Threading.CancellationToken.None);
        }
    
        /// <summary>Stores an asset after downloading it from the given URL.</summary>
        /// <param name="url">The URL where the asset is currently located</param>
        /// <param name="userAgent">Optional, 'user-agent' header to use when downloading (default: null - no user agent)</param>
        /// <param name="overwriteExisting">Optional, overwrite existing file (default: true)</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<ProblemDetails> ApiStoreUrlGetAsync(string url, string userAgent, bool? overwriteExisting, System.Threading.CancellationToken cancellationToken)
        {
            if (url == null)
                throw new System.ArgumentNullException("url");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/store-url?");
            urlBuilder_.Append("url=").Append(System.Uri.EscapeDataString(ConvertToString(url, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            if (userAgent != null) 
            {
                urlBuilder_.Append("userAgent=").Append(System.Uri.EscapeDataString(ConvertToString(userAgent, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (overwriteExisting != null) 
            {
                urlBuilder_.Append("overwriteExisting=").Append(System.Uri.EscapeDataString(ConvertToString(overwriteExisting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("Bad Request", (int)response_.StatusCode, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(ProblemDetails);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <summary>Retrieves a previously stored asset as an easy to consume model.</summary>
        /// <param name="url">The URL identifying the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<DownloadFileModel> ApiRetrieveGetAsync(string url)
        {
            return ApiRetrieveGetAsync(url, System.Threading.CancellationToken.None);
        }
    
        /// <summary>Retrieves a previously stored asset as an easy to consume model.</summary>
        /// <param name="url">The URL identifying the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<DownloadFileModel> ApiRetrieveGetAsync(string url, System.Threading.CancellationToken cancellationToken)
        {
            if (url == null)
                throw new System.ArgumentNullException("url");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/retrieve?");
            urlBuilder_.Append("url=").Append(System.Uri.EscapeDataString(ConvertToString(url, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(DownloadFileModel); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<DownloadFileModel>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                            throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                        }
                        else
                        if (status_ == "404") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                            throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(DownloadFileModel);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <summary>Stores an asset (without downloading it).</summary>
        /// <param name="content">Content of the asset</param>
        /// <param name="url">URL identifying the asset</param>
        /// <param name="contentType">Content type of the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ProblemDetails> ApiStoreBytesPostAsync(byte[] content, string url, string contentType)
        {
            return ApiStoreBytesPostAsync(content, url, contentType, System.Threading.CancellationToken.None);
        }
    
        /// <summary>Stores an asset (without downloading it).</summary>
        /// <param name="content">Content of the asset</param>
        /// <param name="url">URL identifying the asset</param>
        /// <param name="contentType">Content type of the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<ProblemDetails> ApiStoreBytesPostAsync(byte[] content, string url, string contentType, System.Threading.CancellationToken cancellationToken)
        {
            if (url == null)
                throw new System.ArgumentNullException("url");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/store-bytes?");
            urlBuilder_.Append("url=").Append(System.Uri.EscapeDataString(ConvertToString(url, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            if (contentType != null) 
            {
                urlBuilder_.Append("contentType=").Append(System.Uri.EscapeDataString(ConvertToString(contentType, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(content, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("Bad Request", (int)response_.StatusCode, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(ProblemDetails);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <summary>Retrieves a previously stored asset as HTTP Response.</summary>
        /// <param name="url">The URL identifying the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<byte[]> ApiRetrieveBytesGetAsync(string url)
        {
            return ApiRetrieveBytesGetAsync(url, System.Threading.CancellationToken.None);
        }
    
        /// <summary>Retrieves a previously stored asset as HTTP Response.</summary>
        /// <param name="url">The URL identifying the asset</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<byte[]> ApiRetrieveBytesGetAsync(string url, System.Threading.CancellationToken cancellationToken)
        {
            if (url == null)
                throw new System.ArgumentNullException("url");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/retrieve-bytes?");
            urlBuilder_.Append("url=").Append(System.Uri.EscapeDataString(ConvertToString(url, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(byte[]); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<byte[]>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("Bad Request", (int)response_.StatusCode, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("Not Found", (int)response_.StatusCode, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(byte[]);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }
        
            return System.Convert.ToString(value, cultureInfo);
        }
    }
    
    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProblemDetails : System.ComponentModel.INotifyPropertyChanged
    {
        private string _type;
        private string _title;
        private int? _status;
        private string _detail;
        private string _instance;
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type
        {
            get { return _type; }
            set 
            {
                if (_type != value)
                {
                    _type = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title
        {
            get { return _title; }
            set 
            {
                if (_title != value)
                {
                    _title = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Status
        {
            get { return _status; }
            set 
            {
                if (_status != value)
                {
                    _status = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("detail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Detail
        {
            get { return _detail; }
            set 
            {
                if (_detail != value)
                {
                    _detail = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("instance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Instance
        {
            get { return _instance; }
            set 
            {
                if (_instance != value)
                {
                    _instance = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ProblemDetails FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(data);
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DownloadFileModel : System.ComponentModel.INotifyPropertyChanged
    {
        private string _objectName;
        private string _etag;
        private byte[] _content;
        private string _contentType;
    
        [Newtonsoft.Json.JsonProperty("objectName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ObjectName
        {
            get { return _objectName; }
            set 
            {
                if (_objectName != value)
                {
                    _objectName = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("etag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Etag
        {
            get { return _etag; }
            set 
            {
                if (_etag != value)
                {
                    _etag = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("content", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] Content
        {
            get { return _content; }
            set 
            {
                if (_content != value)
                {
                    _content = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("contentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ContentType
        {
            get { return _contentType; }
            set 
            {
                if (_contentType != value)
                {
                    _contentType = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static DownloadFileModel FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DownloadFileModel>(data);
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException) 
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException) 
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}