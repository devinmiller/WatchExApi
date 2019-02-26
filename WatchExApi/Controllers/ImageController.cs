using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wex.Context;

namespace WatchExApi.Controllers
{
    [ODataRoutePrefix("images")]
    public class ImageController : ODataController
    {
        private readonly WexContext _context;

        public ImageController(WexContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute]
        public IActionResult Get()
        {
            return Ok(_context.Images.AsQueryable());
        }
    }
}