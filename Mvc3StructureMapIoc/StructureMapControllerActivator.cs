﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc3StructureMapIoc
{
    public class StructureMapControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
