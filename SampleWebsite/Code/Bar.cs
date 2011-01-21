using System;

namespace SampleWebsite.Code
{
    public class Bar : IBar
    {
        public string IPityTheFoo()
        {
            return "Foo, I pity you!";
        }
    }

    public interface IBar
    {
        string IPityTheFoo();
    }
}