using System;
using Beauty.Business;
using Beauty = Beauty.Business.Beauty;

namespace Beauty.Specs.UI.StepDefinitions
{
    public class BeautyFactory
    {
        private int _ageCounter = 0;
        private int _weightCounter = 0;
        private int _beautyCounter = 0;

        public Business.Beauty Create(int age)
        {
            var result = Create();
            result.Age = age;
            return result;
        }

        private Business.Beauty Create()
        {
            return new Business.Beauty
                {
                    Name = String.Format("Beauty {0}", _beautyCounter++),
                    Age = _ageCounter++,
                    Weight = _weightCounter++
                };
        }

        public Business.Beauty Create(Weight weight)
        {
            var result = Create();
            result.Weight = weight.Value;
            return result;
        }
    }
}