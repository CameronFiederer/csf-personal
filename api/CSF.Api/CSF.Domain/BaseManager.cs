using CSF.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSF.Domain
{
    public class BaseManager<T> where T : class
    {
        protected Repository<T> repository;

        public BaseManager(Repository<T> repository)
        {
            this.repository = repository;
        }

        public void Insert(T model)
        {
            repository.Insert(model);
        }

        public void Insert(IEnumerable<T> models)
        {
            repository.Insert(models);
        }

        public void Update(T model)
        {
            repository.Update(model);
        }

        public void Update(IEnumerable<T> models)
        {
            repository.Update(models);
        }

        public void Delete(T model)
        {
            repository.Delete(model);
        }

        public void Delete(IEnumerable<T> models)
        {
            repository.Delete(models);
        }

        public T Get(T modelWithId)
        {
            return repository.Get(modelWithId);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }
    }
}