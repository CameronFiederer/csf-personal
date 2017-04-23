using Dapper.FastCrud;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSF.Data
{
    public class Repository<T> where T : class
    {
        protected IDbConnection database;

        public Repository(ConnectionFactory connectionFactory)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.PostgreSql;

            database = connectionFactory.Create();
        }

        public void Insert(T model)
        {
            database.Insert<T>(model);
        }

        public void Insert(IEnumerable<T> models)
        {
            List<T> modelList = models.ToList();
            foreach (T model in modelList)
                Insert(model);
        }

        public void Update(T model)
        {
            database.Update<T>(model);
        }

        public void Update(IEnumerable<T> models)
        {
            List<T> modelList = models.ToList();
            foreach (T model in modelList)
                Update(model);
        }

        public void Delete(T model)
        {
            database.Delete<T>(model);
        }

        public void Delete(IEnumerable<T> models)
        {
            List<T> modelList = models.ToList();
            foreach (T model in modelList)
                Delete(model);
        }

        public T Get(T modelWithId)
        {
            return database.Get(modelWithId);
        }

        public IEnumerable<T> GetAll()
        {
            return database.Find<T>();
        }
    }
}