using CSF.Domain;
using CSF.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CSF.Web.Controllers
{
    public abstract class CrudController<T> : ControllerBase where T : BaseModel, new()
    {
        protected BaseManager<T> baseManager;

        public CrudController(BaseManager<T> baseManager)
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
        [Authorize(Policy = "Administrator")]
        public virtual void Post([FromBody]T model)
        {
            baseManager.Insert(model);
        }

        [HttpPost]
        [Route("[controller]s")]
        [Authorize(Policy = "Administrator")]
        public virtual void PostThese([FromBody]IEnumerable<T> models)
        {
            baseManager.Insert(models);
        }

        [HttpPut]
        [Route("[controller]")]
        [Authorize(Policy = "Administrator")]
        public virtual void Put([FromBody]T model)
        {
            baseManager.Update(model);
        }

        [HttpPut]
        [Route("[controller]s")]
        [Authorize(Policy = "Administrator")]
        public virtual void PutThese([FromBody]IEnumerable<T> models)
        {
            baseManager.Update(models);
        }

        [HttpDelete]
        [Route("[controller]")]
        [Authorize(Policy = "Administrator")]
        public virtual void Delete([FromBody]T model)
        {
            baseManager.Delete(model);
        }

        [HttpDelete]
        [Route("[controller]s")]
        [Authorize(Policy = "Administrator")]
        public virtual void DeleteThese([FromBody]IEnumerable<T> models)
        {
            baseManager.Delete(models);
        }
    }
}
