using System;
using System.Web.Mvc;
using StructureMap;
using System.Collections.Generic;

namespace Mvc3StructureMapIoc
{
    public class StructureMapGlobalFilterProvider : IFilterProvider
    {
        public StructureMapGlobalFilterProvider(IContainer container, GlobalFilterRegistrationList filterList)
        {
            _container = container;
            _filterList = filterList;
        }

        private IContainer _container;
        private GlobalFilterRegistrationList _filterList;

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = new List<Filter>();
            if (_filterList == null || _filterList.Count == 0)
                return filters;

            foreach (GlobalFilterRegistration registration in _filterList)
            {
                var actionFilter = _container.GetInstance(registration.Type);
                var filter = new Filter(actionFilter, FilterScope.Global, registration.Order);
                filters.Add(filter);
            }

            return filters;
        }
    }
}
