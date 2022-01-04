//Definition of the repository pattern.

using Entities;

namespace DataAccess.Repositories
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> ListCollectionAsync();

        Task<Student> GetAsync(int id);

        Task<int> CreateAsync(Student studentRequest);

        Task<int> UpdateAsync(Student studentRequest);

        Task DeleteAsync(int id);
    }
}