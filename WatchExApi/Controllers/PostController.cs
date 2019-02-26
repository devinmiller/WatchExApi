using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wex.Context;
using Wex.Context.Models;

namespace WatchExApi.Controllers
{
    [ODataRoutePrefix("posts")]
    public class PostController : ODataController
    {
        private readonly WexContext _context;

        public PostController(WexContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute]
        public IActionResult Get()
        {
            return Ok(_context.Posts.Include(x => x.Images).AsQueryable());
        }
    }
}