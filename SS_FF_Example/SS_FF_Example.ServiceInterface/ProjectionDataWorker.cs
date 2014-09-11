using System.Collections.Generic;
using ServiceStack.OrmLite;
using SS_FF_Example.ServiceModel;
 
namespace SS_FF_Example.ServiceInterface
{
    /// <summary>
    /// A helper class that uses the ServiceStack.OrmLite Object Relational Mapper
    /// to support CRUD operations on the Projection table.
    /// </summary>
    public class ProjectionDataWorker
    {
        // The IDbConnection passed in from the IOC container on the service
        System.Data.IDbConnection _dbConnection;
 
        // Store the database connection passed in
        public ProjectionDataWorker(System.Data.IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
 
        // Inserts a new row into the Projection table
        public int AddProjection(Projection p)
        {
            return (int)_dbConnection.Insert<Projection>(p, selectIdentity: true);
        }
 
        // Return a list of projections from our DB
        // (this is the equivilent of “SELECT * FROM Projection”)
        public List<Projection> GetProjectionList()
        {
            return _dbConnection.Select<Projection>();
        }

        // Return list of projections based on last name
        public List<Projection> GetProjectionListByLastName(string lastName)
        {
            return _dbConnection.LoadSelect(_dbConnection.From<Projection>().Where(p => p.Lastname.StartsWith(lastName)));
        }
 
        // Return a single Projection given their ID
        public Projection GetProjectionByID(int id)
        {
            return _dbConnection.SingleById<Projection>(id);
        }
 
        // Updates a row in the Projection table. Note that this call updates
        // all fields, in order to update only certain fields using OrmLite,
        // use an anonymous type like the below line, which would only
        // update the FirstName and LastName fields:
        // _dbConnection.Update(new { Points = 20, PassingTouchdowns = 2 });
        public Projection UpdateProjection(Projection p)
        {
            _dbConnection.Update<Projection>(p);
            return p;
        }
 
        // Deletes a row from the Projection table
        public int DeleteProjectionByID(int id)
        {
            return _dbConnection.Delete(id);
        }
    }
}