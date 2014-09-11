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
                            Properties.Settings.Default.FFConnectionString, SqlServerDialect.Provider
                         )
                );

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                // We’re just creating a single table, but you could add
                // as many as you need.  Also note the “overwrite: false” parameter,
                // this will only create the table if it doesn’t already exist.
                db.CreateTable<Projection>(overwrite: false);
            }

            this.Plugins.Add(new RazorFormat());
        }
    }
}