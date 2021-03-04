using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public static class CommonHelper
    {


        /// <summary>
        /// Gets or sets application base path
        /// </summary>
        public static string BaseDirectory { get; set; }

        /// <summary>
        /// Gets or sets web application content files
        /// </summary>
        public static string WebRootPath { get; set; }

        /// <summary>
        /// Gets or sets application default cache time minutes
        /// </summary>
        public static int CacheTimeMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating for cookie expires in hours
        /// </summary>
        public static int CookieAuthExpires { get; set; }

        /// <summary>
        /// Gets or sets a value indicating for allow to request with JSON response for Public Controller 
        /// </summary>
        public static bool AllowToJsonResponse { get; set; }

    }
}
