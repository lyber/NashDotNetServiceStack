using System.Collections.Generic;
using SS_FF_Example.ServiceModel;
using ServiceStack;
 
namespace SS_FF_Example.ServiceInterface
{
    /// <summary>
    /// The ProjectionService inherits from ServiceStack.Service and provides the
    /// processing to the incoming request objects.  In this service we’re returning
    /// types we have reused, but you can create your own response objects to return as well.
    /// Note that the Method names must match the HTTP Verb that they are meant to handle.
    /// </summary>
    public class ProjectionService : Service
    {
        // Returns a list of Projections to the user given a GetProjectionsRequest (which is empty)
        public List<Projection> Get(GetProjectionsRequest request)
        {
            // Notice we’re passing “Db” as a parameter to ProjectionDataProvider,
            // this Db variable is provided by the IOC Container we set up in
            // the ApplicationHost.Configure method.
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            return pdw.GetProjectionList();
        }

        // Return a list of projections by player last name
        public List<Projection> Get(StringRequest request)
        {
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            return pdw.GetProjectionListByLastName(request.Parameter);
        }
 
        // Return a single Projection given their ProjectionID
        public Projection Get(ProjectionIDRequest request)
        {
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            return pdw.GetProjectionByID(request.ProjectionID);
        }
 
        // Creates a new Projection
        public int Post(ProjectionRequest request)
        { 
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            return pdw.AddProjection(request.Projection);
        }
 
        // Updates an existing Projection
        public Projection Put(ProjectionRequest request)
        { 
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            return pdw.UpdateProjection(request.Projection);
        }
 
        // Deletes a Projection
        public void Delete(ProjectionIDRequest request)
        {
            ProjectionDataWorker pdw = new ProjectionDataWorker(Db);
            pdw.DeleteProjectionByID(request.ProjectionID);
        }
    }
}