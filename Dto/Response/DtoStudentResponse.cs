/* Dto class avoids exposing the original classes located in Entities
when consuming the API. Improve security.*/

namespace Dto.Response
{
    public class DtoStudentResponse
    {
        public int Id { get; set; }

        public int HouseId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public long Identification { get; set; }

        public int Age { get; set; }
    }
}