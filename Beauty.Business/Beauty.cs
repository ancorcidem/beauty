using System.ComponentModel.DataAnnotations;

namespace Beauty.Business
{
    public class Beauty
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public int Age { get; set; }
    }
}