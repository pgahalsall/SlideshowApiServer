using SlideshowDataAccess;
using SlideshowApi.Models;
using SlideshowApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SlideshowApi.Controllers
{
    [RoutePrefix("api/slides")]
    public class SlidesController : BaseApiController
    {
        private IIdentityService _identityService;

        public SlidesController(IRepository repo, IIdentityService identityService) : 
            base(repo)
        {
            _identityService = identityService;
        }

        public HttpResponseMessage Get()
        {
            var slideModel = TheRepository.GetAllSlides()
                                       .ToList()
                                       .Select(s => TheModelFactory.Create(s));

            if (slideModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, slideModel);
        }

        [Route("{slideid}", Name = "Slide")]
        public IHttpActionResult GetSlide(int slideid)
        {
            var slide = TheRepository
                            .GetSlide(slideid);

            if (slide == null)
            {
                return NotFound();
            }

            SlideModel sm = TheModelFactory.Create(slide);

            return Ok(sm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
