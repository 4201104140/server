using Grand.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Grand.Core.Plugins
{
    /// <summary>
    /// Sets the application up for the plugin referencing
    /// </summary>
    public static class PluginManager
    {
        #region Const

        public const string InstalledPluginsFilePath = "~/App_Data/InstalledPlugins.txt";
        public const string PluginsPath = "~/Plugins";
        public const string ShadowCopyPath = "~/Plugins/bin";

        private static object _synLock = new object();

        #endregion

        #region Fields

        private static DirectoryInfo _shadowCopyFolder;
        private static DirectoryInfo _pluginFolder;
        private static GrandConfig _config;

        #endregion

        #region Methods

        /// <summary>
        /// Returns a collection of all referenced plugin assemblies that have been shadow copied
        /// </summary>
        public static IEnumerable<PluginDescriptor> ReferencedPlugins { get; set; }

        /// <summary>
        /// Find a plugin descriptor by some type which is located into the same assembly as plugin
        /// </summary>
        /// <param name="typeInAssembly">Type</param>
        /// <returns>Plugin descriptor if exists; otherwise null</returns>
        public static PluginDescriptor FindPlugin(Type typeInAssembly)
        {
            if (typeInAssembly == null)
                throw new ArgumentNullException("typeInAssembly");

            if (ReferencedPlugins == null)
                return null;

            return ReferencedPlugins.FirstOrDefault(plugin => plugin.ReferencedAssembly != null
                && plugin.ReferencedAssembly.FullName.Equals(typeInAssembly.GetTypeInfo().Assembly.FullName, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}
