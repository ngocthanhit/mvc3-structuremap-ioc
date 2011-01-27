using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StructureMap;

namespace Mvc3StructureMapIoc
{
    public class StructureMapFilterProvider : FilterAttributeFilterProvider
    {
        public StructureMapFilterProvider(IContainer container)
        {
            _container = container;
        }

        private IContainer _container;

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                _container.BuildUp(filter.Instance);
            }

            return filters;
        }
    }
}
