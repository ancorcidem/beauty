using System;
using System.ComponentModel.DataAnnotations;

namespace Beauty.Business
{
    public class Beauty
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public Uri Uri { get; set; }

        public static implicit operator Beauty(BeautyProfile profile)
        {
            return new Beauty
                {
                    Name = profile.Name,
                    Age = profile.Age,
                    Weight = profile.Weight,
                    Uri = profile.Uri
                };
        }
    }
}