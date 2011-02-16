using System;
using System.Web.Mvc;

namespace SampleWebsite.Code
{
    public class RandomSentenceValueProvider : IValueProvider
    {
        public RandomSentenceValueProvider(RandomSentenceGenerator randomSentenceGenerator)
        {
            _randomSentenceGenerator = randomSentenceGenerator;
        }

        private RandomSentenceGenerator _randomSentenceGenerator;

        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (key == "getMeASentenceYo")
            {
                string randomSentence = _randomSentenceGenerator.GetRandomSentence();
                var result = new ValueProviderResult(randomSentence, randomSentence, new System.Globalization.CultureInfo(1));
                return result;
            }

            return null;
        }
    }

    public class RandomSentenceValueProviderFactory : ValueProviderFactory
    {
        public RandomSentenceValueProviderFactory(RandomSentenceGenerator gen)
        {
            _randomSentenceGenerator = gen;
        }

        private RandomSentenceGenerator _randomSentenceGenerator;

        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new RandomSentenceValueProvider(_randomSentenceGenerator);
        }
    }
}