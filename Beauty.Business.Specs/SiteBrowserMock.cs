using System.Collections.Generic;
using StructureMap;

namespace Beauty.Business.Specs
{
    public class SiteBrowserMock : ISiteBrowser
    {
        private readonly List<Beauty> _beauties = new List<Beauty>();
        public string MakeRequestBy(string url)
        {
            return string.Empty;
        }

        public void RegisterBeauty(Age age)
        {
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            _beauties.Add(factory.Create(age));
        }
    }
}