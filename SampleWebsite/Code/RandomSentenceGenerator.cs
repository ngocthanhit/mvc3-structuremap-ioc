using System;
using System.Collections.Generic;

namespace SampleWebsite.Code
{
    public class RandomSentenceGenerator
    {
        static RandomSentenceGenerator()
        {
            _beginnings.Add("Jack ate");
            _beginnings.Add("Violet whalloped");
            _beginnings.Add("Bart shot");
            _beginnings.Add("Vince mutilated");
            _beginnings.Add("Lorie slathered");
            _beginnings.Add("Mike talked to");

            _endings.Add("enemies yet loved the lady of the lake still.");
            _endings.Add("kittens before demanding a cherry pie from his wife.");
            _endings.Add("monks because he liked Avatar so much.");
            _endings.Add("ants because they were clearly planning to take over the world.");
            _endings.Add("bottles of rum due to intense hatred of pirates. Argggh ye matey!");
            _endings.Add("a box of gum. After all, he was a nice person.");
        }

        public string GetRandomSentence()
        {
            var random = new Random();
            return _beginnings[random.Next(0, 6)]
                + " "
                + random.Next(5, 5000)
                + " "
                + _endings[random.Next(0, 6)];
        }

        public static List<string> _beginnings = new List<string>();
        public static List<string> _endings = new List<string>();
    }
}