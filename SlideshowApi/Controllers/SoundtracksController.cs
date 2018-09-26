using SlideshowApi.Controllers;
using SlideshowApi.Models;
using SlideshowApi.Services;
using SlideshowDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

[RoutePrefix("api/Soundtracks")]
public class SoundtracksController : BaseApiController
{
    private IIdentityService _identityService;

    public SoundtracksController(IRepository repo, IIdentityService identityService) :
        base(repo)
    {
        _identityService = identityService;
    }

    // GET: api/Soundtrack
    public HttpResponseMessage Get()
    {
        var slideModel = TheRepository.GetAllSoundtracks()
                                       .ToList()
                                       .Select(st => TheModelFactory.Create(st));

        if (slideModel == null)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        return Request.CreateResponse(HttpStatusCode.OK, slideModel);
    }

    // GET: api/Soundtrack/5
    [Route("{id}", Name = "Soundtrack")]
    public IHttpActionResult Get(int id)
    {
        var soundtrack = TheRepository.GetSoundtrack(id);

        if (soundtrack == null)
        {
            return NotFound();
        }

        SoundtrackModel sm = TheModelFactory.Create(soundtrack);

        return Ok(sm);
    }

    // POST: api/Soundtrack
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Soundtrack/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Soundtrack/5
    public void Delete(int id)
    {
    }
}
