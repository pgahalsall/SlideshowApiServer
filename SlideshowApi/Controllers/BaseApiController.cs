using SlideshowDataAccess;
using SlideshowApi.ActionResults;
using SlideshowApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SlideshowApi.Controllers
{

    public abstract class BaseApiController : ApiController
    {
        IRepository _repo;
        ModelFactory _modelFactory;

        public BaseApiController(IRepository repo)
        {
            _repo = repo;
        }

        protected IRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, TheRepository);
                }
                return _modelFactory;
            }
        }

        protected IHttpActionResult Versioned<T>(T body, string version = "v1") where T : class
        {
            return new VersionedActionResult<T>(Request, version, body);
        }

    }
}