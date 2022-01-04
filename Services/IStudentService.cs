using Dto.Response;
using Dto.Request;

namespace Services
{
    public interface IStudentService
    {
        Task<ICollection<DtoStudentResponse>> ListAsync();

        Task<DtoStudentResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(DtoStudentRequest request);

        Task<int> UpdateAsync(int id, DtoStudentRequest request);

        Task DeleteAsync(int id);
    }
}