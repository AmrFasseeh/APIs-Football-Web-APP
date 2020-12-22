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
    public class PostTagsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/PostTags
        public IQueryable<PostTag> GetPostTags()
        {
            return db.PostTags;
        }

        // GET: api/PostTags/5
        [ResponseType(typeof(PostTag))]
        public IHttpActionResult GetPostTag(int id)
        {
            var postTags = db.posts.Where(p => p.id == db.PostTags.First(pt => pt.tagId == id).postId);
            if (postTags == null)
            {
                return NotFound();
            }

            return Ok(postTags);
        }
    }
}