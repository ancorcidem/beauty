using System;
using System.Collections.Generic;
using System.Web;
using StructureMap;

namespace Beauty.Business.Specs
{
    public class SiteBrowserMock : ISiteBrowser
    {
        private readonly List<BeautyProfile> _beauties = new List<BeautyProfile>();
        public string MakeRequestBy(string url)
        {
            var uri = new Uri(url);
            var parameters = HttpUtility.ParseQueryString(uri.Query);
            //var ageFrom = parameters["AgeFrom"]
            return string.Empty;
        }

        public void RegisterBeauty(Age age)
        {
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            _beauties.Add(factory.CreateHtml(age));
        }
    }
}