using System;
using Beauty.Business;
using Beauty.Business.Dal;

namespace Beauty.UI.Specs
{
    public class BeautyFactory
    {
        private readonly IImageDownloader _loader;
        private int _ageCounter;
        private int _weightCounter;
        private int _beautyCounter;

        public BeautyFactory(IImageDownloader loader)
        {
            _loader = loader;
            _beautyCounter = 0;
        }

        public Business.Beauty Create(Age age)
        {
            var result = Create();
            result.Age = age.Value;
            return result;
        }

        private Business.Beauty Create()
        {
            return new Business.Beauty
                {
                    Name = String.Format("Beauty {0}", _beautyCounter++),
                    Age = _ageCounter++,
                    Weight = _weightCounter++,
                    AvatarImageBlob = _loader.Download(null)
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