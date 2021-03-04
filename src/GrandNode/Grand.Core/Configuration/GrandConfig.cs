using System.Collections.Generic;

namespace Grand.Core.Configuration
{
    /// <summary>
    /// Represents a GrandConfig
    /// </summary>
    public partial class GrandConfig
    {


        /// <summary>
        /// Gets or sets a value indicating for default cache time in minutes
        /// </summary>
        public int DefaultCacheTimeMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating for cookie expires in hours - default 24 * 365 = 8760
        /// </summary>
        public int CookieAuthExpires { get; set; }



        /// <summary>
        /// Gets or sets a value indicating for allow to request with JSON response for Public Controller 
        /// </summary>
        public bool AllowToJsonResponse { get; set; }
    }
}
