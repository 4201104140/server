using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Domain.Data
{
    public partial class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        /// <summary>
        /// Gets the collection
        /// </summary>
        protected IMongoCollection<T> _collection;
        public IMongoCollection<T> Collection {
            get {
                return _collection;
            }
        }

        /// <summary>
        /// Mongo Database
        /// </summary>
        protected IMongoDatabase _database;
        public IMongoDatabase Database {
            get {
                return _database;
            }
        }

        #endregion

        #region Ctor

        public Repository(IDataProvider)
        {

        }
        #endregion
    }
}
