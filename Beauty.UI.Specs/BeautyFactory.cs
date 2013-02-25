using System;
using Beauty.Business;

namespace Beauty.UI.Specs
{
    public class BeautyFactory
    {
        private int _ageCounter;
        private int _weightCounter;
        private int _beautyCounter;

        public BeautyFactory()
        {
            _beautyCounter = 0;
        }

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