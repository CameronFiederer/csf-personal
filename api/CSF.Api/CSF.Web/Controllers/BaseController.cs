using CSF.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSF.Web.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController<T> where T : class
    {
        protected BaseManager<T> baseManager;

        public BaseController(BaseManager<T> baseManager)
        {
            this.baseManager = baseManager;
        }

        [HttpGet]
        [Route("Get")]
        public virtual T Get(T modelWithId)
        {
            return baseManager.Get(modelWithId);
        }

        // Gotta figure out this routing properly
        [HttpGet]
        [Route("GetAll")]
        public virtual IEnumerable<T> GetAll()
        {
            return baseManager.GetAll();
        }

        [HttpPost]
        public virtual void Post(T model)
        {
            baseManager.Insert(model);
        }

        [HttpPost]
        public virtual void PostThese(IEnumerable<T> models)
        {
            baseManager.Insert(models);
        }

        [HttpPut]
        public virtual void Put(T model)
        {
            baseManager.Update(model);
        }

        [HttpPut]
        public virtual void PutThese(IEnumerable<T> models)
        {
            baseManager.Update(models);
        }

        [HttpDelete]
        public virtual void Delete(T model)
        {
            baseManager.Delete(model);
        }

        [HttpDelete]
        public virtual void DeleteThese(IEnumerable<T> models)
        {
            baseManager.Delete(models);
        }
    }
}
