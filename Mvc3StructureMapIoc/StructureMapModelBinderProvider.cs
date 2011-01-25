using System;
using System.Web.Mvc;
using StructureMap;

namespace Mvc3StructureMapIoc
{
    public class StructureMapModelBinderProvider : IModelBinderProvider
    {
        public StructureMapModelBinderProvider(IContainer container)
        {
            _container = container;
        }

        private IContainer _container;

        public IModelBinder GetBinder(Type modelType)
        {
            var typeMappings = _container.GetInstance<ModelBinderTypeMappingDictionary>();
            if (typeMappings.ContainsKey(modelType))
                return _container.GetInstance(typeMappings[modelType]) as IModelBinder;

            return null;
        }
    }
}
