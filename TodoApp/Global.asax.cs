using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TodoApp.Migrations;
using TodoApp.Models;

namespace TodoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //TodoApp‚ª‹N“®‚µ‚½‚çÅ‰‚ÉÀs‚³‚ê‚é
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Configuration SeedÒ¿¯ÄŞ Às
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoesContext, Configuration>());
        }
    }
}
