using SlideshowApi.Models;
using SlideshowApi.Services;
using SlideshowDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SlideshowApi.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : BaseApiController
    {
        private IIdentityService _identityService;

        public UsersController(IRepository repo, IIdentityService identityService) :
            base(repo)
        {
            _identityService = identityService;
        }

        // GET: api/Users
        public HttpResponseMessage Get()
        {
            var userModels = TheRepository.GetAllUsers()
                                     .ToList()
                                     .Select(u => TheModelFactory.Create(u));

            if (userModels == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, userModels);
        }

        // GET: api/Users/5
        [Route("{userid}", Name = "User")]
        public IHttpActionResult Get(int userid)
        {
            var user = TheRepository.GetUser(userid);

            if (user == null)
            {
                return NotFound();
            }

            UserModel um = TheModelFactory.Create(user);

            return Ok(um);
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
