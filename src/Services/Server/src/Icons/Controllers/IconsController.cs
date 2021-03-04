//using Icons.Models;
//using Icons.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Caching.Memory;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Icons.Controllers
//{
//    [Route("")]
//    public class IconsController : Controller
//    {
//        private readonly IMemoryCache _memoryCache;
//        private readonly IDomainMappingService _domainMappingService;
//        private readonly IIconFetchingService _iconFetchingService;
//        private readonly ILogger<IconsController> _logger;
//        private readonly IconsSettings _iconsSettings;

//        public IconsController(
//            IMemoryCache memoryCache,
//            IDomainMappingService domainMappingService,
//            IIconFetchingService iconFetchingService,
//            ILogger<IconsController> logger,
//            IconsSettings iconsSettings)
//        {
//            _memoryCache = memoryCache;
//            _domainMappingService = domainMappingService;
//            _iconFetchingService = iconFetchingService;
//            _logger = logger;
//            _iconsSettings = iconsSettings;
//        }

//        [HttpGet("~/alive")]
//        [HttpGet("~/now")]
//        public DateTime GetAlive()
//        {
//            return DateTime.UtcNow;
//        }

//        public async Task<IActionResult> Get(string hostname)
//        {
//            if (string.IsNullOrWhiteSpace(hostname) || !hostname.Contains("."))
//            {
//                return new BadRequestResult();
//            }

//            var url = $"http://{hostname}";
//            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
//            {
//                return new BadRequestResult();
//            }

//            var domain = uri.Host;

//            var mappedDomain = _domainMappingService.MapDomain(domain);
//            if (!_iconsSettings.CacheEnabled || !_memoryCache.TryGetValue(mappedDomain, out Icon icon))
//            {
//                var result = await _iconFetchingService.GetIconAsync(domain);
//                if (result == null)
//                {
//                    _logger.LogWarning("Null result returned for {0}.", domain);
//                    icon = null;
//                }
//            }
//        }
//    }
//}
