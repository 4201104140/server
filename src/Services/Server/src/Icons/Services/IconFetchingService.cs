//using Icons.Models;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace Icons.Services
//{
//    public class IconFetchingService : IIconFetchingService
//    {
//        private readonly HashSet<string> _iconRels =
//            new HashSet<string> { "icon", "apple-touch-icon", "shortcut icon" };
//        private readonly HashSet<string> _blacklistedRels =
//            new HashSet<string> { "preload", "image_src", "preconnect", "canonical", "alternate", "stylesheet" };
//        private readonly HashSet<string> _iconExtensions =
//            new HashSet<string> { ".ico", ".png", ".jpg", ".jpeg" };

//        private readonly string _pngMediaType = "image/png";
//        private readonly byte[] _pngHeader = new byte[] { 137, 80, 78, 71 };
//        private readonly byte[] _webpHeader = Encoding.UTF8.GetBytes("RIFF");

//        private readonly string _icoMediaType = "image/x-icon";
//        private readonly string _icoAltMediaType = "image/vnd.microsoft.icon";
//        private readonly byte[] _icoHeader = new byte[] { 00, 00, 01, 00 };

//        private readonly string _jpegMediaType = "image/jpeg";
//        private readonly byte[] _jpegHeader = new byte[] { 255, 216, 255 };

//        private readonly HashSet<string> _allowedMediaTypes;
//        private readonly HttpClient _httpClient;
//        private readonly ILogger<IIconFetchingService> _logger;

//        public IconFetchingService(ILogger<IIconFetchingService> logger)
//        {
//            _logger = logger;
//            _allowedMediaTypes = new HashSet<string>
//            {
//                _pngMediaType,
//                _icoMediaType,
//                _icoAltMediaType,
//                _jpegMediaType
//            };

//            _httpClient = new HttpClient(new HttpClientHandler
//            {
//                AllowAutoRedirect = false,
//                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
//            });
//            _httpClient.Timeout = TimeSpan.FromSeconds(20);
//        }

//        public async Task<IconResult> GetIconAsync(string domain)
//        {
//            if (IPAddress.TryParse(domain, out _))
//            {
//                _logger.LogWarning("IP Address: {0}.", domain);
//                return null;
//            }

//            if (!Uri.TryCreate($"http://{domain}", UriKind.Absolute, out var parsedHttpUri))
//            {
//                _logger.LogWarning("Bad domain: {0}.", domain);
//                return null;
//            }

//            var uri = parsedHttpUri;
//            var response = await 
//        }
//    }
//}
