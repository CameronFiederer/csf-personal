using CSF.Domain;
using CSF.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSF.Web.Controllers
{
    public abstract class BaseController<T> where T : BaseModel, new()
    {
        protected BaseManager<T> baseManager;

        public BaseController(BaseManager<T> baseManager)
        {
            this.baseManager = baseManager;
        }

        [HttpGet]
        [Route("[controller]/{id:int}")]
        public virtual T Get(int id)
        {
            T model = new T();
            model.Id = id; 
            return baseManager.Get(model);
        }

        // Gotta figure out this routing properly
        [HttpGet]
        [Route("[controller]s")]
        public virtual IEnumerable<T> GetAll()
        {
            return baseManager.GetAll();
        }

        [HttpPost]
        [Route("[controller]")]
        public virtual void Post(T model)
        {
            baseManager.Insert(model);
        }

        [HttpPost]
        [Route("[controller]s")]
        public virtual void PostThese(IEnumerable<T> models)
        {
            baseManager.Insert(models);
        }

        [HttpPut]
        [Route("[controller]")]
        public virtual void Put(T model)
        {
            baseManager.Update(model);
        }

        [HttpPut]
        [Route("[controller]s")]
        public virtual void PutThese(IEnumerable<T> models)
        {
            baseManager.Update(models);
        }

        [HttpDelete]
        [Route("[controller]")]
        public virtual void Delete(T model)
        {
            baseManager.Delete(model);
        }

        [HttpDelete]
        [Route("[controller]s")]
        public virtual void DeleteThese(IEnumerable<T> models)
        {
            baseManager.Delete(models);
        }
    }
}
