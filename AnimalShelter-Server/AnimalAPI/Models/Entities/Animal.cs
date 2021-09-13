
using System.ComponentModel.DataAnnotations;

namespace AnimalAPI
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string IMGUrl { get; set; }
        public string Description { get; set; }
    }
}

