using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dimaticaAPI.Models
{
    /// <summary>
    /// Class implementing the interface, this information is obtained from appsettings.json in startup.cs
    /// </summary>
    public class DutiesDatabaseSettings: IDutiesDatabaseSettings
    {
        public string DutiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    /// <summary>
    /// Interface for the database settings is defined
    /// </summary>
    public interface IDutiesDatabaseSettings
    {
        string DutiesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
