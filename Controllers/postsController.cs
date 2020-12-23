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
    public class postsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/posts
        public IQueryable<post> Getposts()
        {
            return db.posts;
        }

        // GET: api/posts/5
        [ResponseType(typeof(post))]
        public IHttpActionResult Getpost(int id)
        {
            post post = db.posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // GET: api/posts/5
        [ResponseType(typeof(post))]
        [Route("api/recentposts")]

        public IHttpActionResult GetRecentPosts()
        {
            var post = db.posts.OrderByDescending(n=>n.updated_at);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // GET: api/posts/5
        [ResponseType(typeof(post))]
        [Route("api/poststype")]

        public IHttpActionResult GetPoststype()
        {
            var post = db.posts.OrderByDescending(n => n.post_type);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }




    }
}