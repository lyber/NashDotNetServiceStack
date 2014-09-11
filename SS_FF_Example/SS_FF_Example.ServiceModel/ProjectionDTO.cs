using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_FF_Example.ServiceModel
{
    [Route("/Projection", Verbs = "GET")]
    public class GetProjectionsRequest { }

    [Route("/Projection", Verbs = "POST")]
    [Route("/Projection/ProjectionID", Verbs = "PUT")]
    public class ProjectionRequest
    {
        public int ProjectionID { get; set; }
        public Projection Projection { get; set; }
    }

    [Route("/Projection/{ProjectionID}", Verbs = "GET, DELETE")]
    public class ProjectionIDRequest
    {
        public int ProjectionID { get; set; }
    }

    [Route("/Projection/LastName/{Parameter}")]
    [Route("/Projection/Team/{Parameter}")]
    [Route("/Projection/Position/{Parameter}")]
    public class StringRequest
    {
        public string Parameter { get; set; }
    }

    public class ProjectionListResponse
    {
        public List<Projection> Projections { get; set; }
    }

    public class ProjectionResponse
    {
        public Projection Projections { get; set; }
    }
}
