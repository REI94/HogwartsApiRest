using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/* Dto class avoids exposing the original classes located in Entities
when consuming the API. Improve security.*/

namespace Dto.Request
{
    public class DtoStudentRequest
    {
        public int HouseId { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [Column(TypeName = "nvarchar(20)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Last Name")]
        [Column(TypeName = "nvarchar(20)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Identification")]
        [Column(TypeName = "int")]
        [Range(0, 9999999999)]
        public long Identification { get; set; }

        [Required(ErrorMessage = "Please enter Age")]
        [Column(TypeName = "int")]
        [Range(0, 99)]
        public int Age { get; set; }
    }
}