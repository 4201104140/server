using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Core.Data
{
    /// <summary>
    /// Data settings helper
    /// </summary>
    public static class DataSettingsHelper
    {
        private static bool? _databaseIsInstalled;
        private static string _connectionString;

        public static bool DatabaseIsInstalled()
        {
            if (!_databaseIsInstalled.HasValue)
            {
                var manager = new 
            }
        }
    }
}
