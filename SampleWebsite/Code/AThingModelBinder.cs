using System;
using System.Web.Mvc;

namespace SampleWebsite.Code
{
    public class AThingModelBinder : DefaultModelBinder
    {
        public AThingModelBinder(IBar bar)
        {
            _bar = bar;
        }

        private IBar _bar;

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            return new AThing() 
            { 
                SomeRandomValue = _bar.IPityTheFoo() 
            };
        }
    }
}