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
        //TodoApp���N��������ŏ��Ɏ��s�����
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Configuration Seedҿ��� ���s
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoesContext, Configuration>());
        }
    }
}
