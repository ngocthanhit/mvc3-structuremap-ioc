using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc3StructureMapIoc;
using StructureMap;
using SampleWebsite.Code;

namespace SampleWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var modelBinderTypeMappingDictionary = new ModelBinderTypeMappingDictionary();
            modelBinderTypeMappingDictionary.Add(typeof(AThing), typeof(AThingModelBinder));

            var globalFilterRegistrationList = new GlobalFilterRegistrationList();
            globalFilterRegistrationList.Add(new GlobalFilterRegistration { Type = typeof(YourMomGlobalFilter), Order = 2 });

            IContainer container = new Container(x =>
            {
                x.For<IControllerActivator>().Use<StructureMapControllerActivator>();
                x.For<IModelBinderProvider>().Use<StructureMapModelBinderProvider>();
                x.For<ModelBinderTypeMappingDictionary>().Use(modelBinderTypeMappingDictionary);
                x.For<IFilterProvider>().Use<StructureMapFilterProvider>();
                x.For<IFilterProvider>().Use<StructureMapGlobalFilterProvider>();
                x.For<GlobalFilterRegistrationList>().Use(globalFilterRegistrationList);
                x.For<IBar>().Use<Bar>();
                x.For<ILogger>().Use<Logger>();
                x.SetAllProperties(p =>
                    {
                        p.OfType<ILogger>();
                    });
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }
    }
}