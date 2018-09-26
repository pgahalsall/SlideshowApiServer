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
    [RoutePrefix("api/Slideshows")]
    public class SlideshowsController : BaseApiController
    {
        private IIdentityService _identityService;

        public SlideshowsController(IRepository repo, IIdentityService identityService) :
            base(repo)
        {
            _identityService = identityService;
        }

        // GET: api/Slideshows
        public HttpResponseMessage Get()
        {
            IEnumerable<SlideshowModel> slideshows = TheRepository.GetAllSlideshows()
                                        .ToList()
                                        .Select(sh => TheModelFactory.Create(sh))
                                        .ToList();

            if (slideshows == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            foreach (SlideshowModel sh in slideshows)
            {
                IEnumerable<SlideModel> slides = TheRepository.GetSlideshowSlides(sh.Id)
                                                         .ToList()
                                                         .Select(s => TheModelFactory.Create(s))
                                                         .ToList();
                sh.Slides = slides;
            }

            return Request.CreateResponse(HttpStatusCode.OK, slideshows);
        }

        // GET: api/Slideshows/5
        [Route("{slideshowid}", Name = "Slideshow")]
        public HttpResponseMessage Get(int slideshowid)
        {
            Slideshow slideshow = TheRepository.GetSlideshow(slideshowid);

            if (slideshow == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            SlideshowModel model = TheModelFactory.Create(slideshow);

            IEnumerable<SlideModel> slides = TheRepository.GetSlideshowSlides(model.Id)
                                                         .ToList()
                                                         .Select(s => TheModelFactory.Create(s))
                                                         .ToList();
            model.Slides = slides;

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        // POST: api/Slideshows
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Slideshows/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Slideshows/5
        public void Delete(int id)
        {
        }
    }
}
