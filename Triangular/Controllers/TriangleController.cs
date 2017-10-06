using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triangular.Models;

namespace Triangular.Controllers
{
    public class TriangleController : ApiController
    {
        // POST api/triangle
        public IEnumerable<string> Post([FromBody] List<List<decimal>> triangles)
        {
            var triangleLogic = new TriangleClassifier();
            var classifications = triangles.Select(triangle => triangleLogic.Classify(triangle));
            return classifications;
        }
    }
}