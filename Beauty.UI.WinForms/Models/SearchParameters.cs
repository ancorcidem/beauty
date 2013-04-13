using Beauty.Business.Criterias;

namespace Beauty.UI.WinForms.Models
{
    public class SearchParameters
    {
        public SearchParameters()
        {
            AgeFrom = 19;
            AgeTo = 25;
        }

        public AgeFrom AgeFrom { get; set; }

        public AgeTo AgeTo { get; set; }
    }
}