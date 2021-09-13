using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalAPI{

    class ImageModel{
        [Key]
        public int ImageId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string ImageName { get; set; }
    }
}