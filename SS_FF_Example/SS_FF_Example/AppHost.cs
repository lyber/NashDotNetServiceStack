using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using SS_FF_Example.ServiceInterface;
using ServiceStack;
using ServiceStack.Razor;
using SS_FF_Example.ServiceModel;
using ServiceStack.OrmLite;
using ServiceStack.Data;
using ServiceStack.OrmLite.Sqlite;

namespace SS_FF_Example
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("SS_FF_Example", typeof(ProjectionService).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            container.Register<IDbConnectionFactory>
                (
                    new OrmLiteConnectionFactory
                        (
                            Properties.Settings.Default.FFConnectionString, SqliteDialect.Provider
                         )
                );

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                // We’re just creating a single table, but you could add
                // as many as you need.  Also note the “overwrite: false” parameter,
                // this will only create the table if it doesn’t already exist.
                db.CreateTable<Projection>(overwrite: true);

				db.Insert(new Projection{ FirstName = "Peyton", LastName = "Manning", Position = "QB", Team = "Den", Points = "28"});
				db.Insert(new Projection{ FirstName = "Drew", LastName = "Brees", Position = "QB", Team = "NO", Points = "21"});
				db.Insert(new Projection{ FirstName = "Andy", LastName = "Dalton", Position = "QB", Team = "Cin", Points = "21"});
				db.Insert(new Projection{ FirstName = "Andrew", LastName = "Luck", Position = "QB", Team = "Ind", Points = "21"});
				db.Insert(new Projection{ FirstName = "Tom", LastName = "Brady", Position = "QB", Team = "NE", Points = "20"});
				db.Insert(new Projection{ FirstName = "Aaron", LastName = "Rodgers", Position = "QB", Team = "GB", Points = "20"});
				db.Insert(new Projection{ FirstName = "LeSean", LastName = "McCoy", Position = "RB", Team = "Phi", Points = "19"});
				db.Insert(new Projection{ FirstName = "Julius", LastName = "Thomas", Position = "TE", Team = "Den", Points = "19"});
				db.Insert(new Projection{ FirstName = "Russell", LastName = "Wilson", Position = "QB", Team = "Sea", Points = "19"});
				db.Insert(new Projection{ FirstName = "Demaryius", LastName = "Thomas", Position = "WR", Team = "Den", Points = "18"});
				db.Insert(new Projection{ FirstName = "Ryan", LastName = "Fitzpatrick", Position = "QB", Team = "Hou", Points = "17"});
				db.Insert(new Projection{ FirstName = "Jake", LastName = "Locker", Position = "QB", Team = "Ten", Points = "17"});
				db.Insert(new Projection{ FirstName = "Nick", LastName = "Foles", Position = "QB", Team = "Phi", Points = "17"});
				db.Insert(new Projection{ FirstName = "Giovani", LastName = "Bernard", Position = "RB", Team = "Cin", Points = "17"});
				db.Insert(new Projection{ FirstName = "Alex", LastName = "Smith", Position = "QB", Team = "KC", Points = "16"});
				db.Insert(new Projection{ FirstName = "Jay", LastName = "Cutler", Position = "QB", Team = "Chi", Points = "16"});
				db.Insert(new Projection{ FirstName = "Calvin", LastName = "Johnson", Position = "WR", Team = "Det", Points = "16"});
				db.Insert(new Projection{ FirstName = "Adrian", LastName = "Peterson", Position = "RB", Team = "Min", Points = "16"});
				db.Insert(new Projection{ FirstName = "Jordy", LastName = "Nelson", Position = "WR", Team = "GB", Points = "16"});
				db.Insert(new Projection{ FirstName = "Jamaal", LastName = "Charles", Position = "RB", Team = "KC", Points = "16"});
				db.Insert(new Projection{ FirstName = "Matthew", LastName = "Stafford", Position = "QB", Team = "Det", Points = "16"});
				db.Insert(new Projection{ FirstName = "A.J.", LastName = "Green", Position = "WR", Team = "Cin", Points = "16"});
				db.Insert(new Projection{ FirstName = "Andre", LastName = "Johnson", Position = "WR", Team = "Hou", Points = "15"});
				db.Insert(new Projection{ FirstName = "Tony", LastName = "Romo", Position = "QB", Team = "Dal", Points = "15"});
				db.Insert(new Projection{ FirstName = "Ben", LastName = "Roethlisberger", Position = "QB", Team = "Pit", Points = "15"});
				db.Insert(new Projection{ FirstName = "Frank", LastName = "Gore", Position = "RB", Team = "SF", Points = "15"});
				db.Insert(new Projection{ FirstName = "Darren", LastName = "Sproles", Position = "RB", Team = "Phi", Points = "15"});
				db.Insert(new Projection{ FirstName = "Marshawn", LastName = "Lynch", Position = "RB", Team = "Sea", Points = "15"});
				db.Insert(new Projection{ FirstName = "Matt", LastName = "Ryan", Position = "QB", Team = "Atl", Points = "15"});
				db.Insert(new Projection{ FirstName = "Matt", LastName = "Forte", Position = "RB", Team = "Chi", Points = "15"});
				db.Insert(new Projection{ FirstName = "Arian", LastName = "Foster", Position = "RB", Team = "Hou", Points = "15"});
				db.Insert(new Projection{ FirstName = "Jimmy", LastName = "Graham", Position = "TE", Team = "NO", Points = "15"});
				db.Insert(new Projection{ FirstName = "Antonio", LastName = "Brown", Position = "WR", Team = "Pit", Points = "15"});
				db.Insert(new Projection{ FirstName = "Shane", LastName = "Vereen", Position = "RB", Team = "NE", Points = "15"});
				db.Insert(new Projection{ FirstName = "Alfred", LastName = "Morris", Position = "RB", Team = "Wsh", Points = "15"});
				db.Insert(new Projection{ FirstName = "Montee", LastName = "Ball", Position = "RB", Team = "Den", Points = "15"});
				db.Insert(new Projection{ FirstName = "Sebastian", LastName = "Janikowski", Position = "K", Team = "Oak", Points = "14"});
				db.Insert(new Projection{ FirstName = "Philip", LastName = "Rivers", Position = "QB", Team = "SD", Points = "14"});
				db.Insert(new Projection{ FirstName = "Donnie", LastName = "Avery", Position = "WR", Team = "KC", Points = "14"});
				db.Insert(new Projection{ FirstName = "Percy", LastName = "Harvin", Position = "WR", Team = "Sea", Points = "14"});
            }

            this.Plugins.Add(new RazorFormat());
        }
    }
}