using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wex.Context;
using Wex.Context.Models;

namespace WatchExApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly WexContext _context;

        public PostController(WexContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Criteria criteria)
        {
            IQueryable<Post> posts = _context.Posts.Include("Images");

            if(!string.IsNullOrWhiteSpace(criteria.Filter))
            {
                posts = posts.Where(p => p.Title.Contains(criteria.Filter));
            }

            List<Post> results = await posts
                .Where(p => p.Images.Any())
                .Where(p => !p.IsMeta && !p.Stickied)
                .OrderByDescending(p => p.CreatedUtc)
                .Skip(criteria.Skip)
                .Take(criteria.Take)
                .ToListAsync();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Post post = await _context
                .Posts.Include("Images")
                .SingleOrDefaultAsync(p => p.Id == id);

            return Ok(post);
        }
    }
}