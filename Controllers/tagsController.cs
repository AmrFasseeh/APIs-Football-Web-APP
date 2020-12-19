using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIs_FinalProject.Models;

namespace APIs_FinalProject.Controllers
{
    public class tagsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/tags
        public IQueryable<tag> Gettags()
        {
            return db.tags;
        }

        // GET: api/tags/5
        [ResponseType(typeof(tag))]
        public IHttpActionResult Gettag(int id)
        {
            tag tag = db.tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

    }
}