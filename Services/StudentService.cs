using DataAccess.Repositories;
using Dto.Response;
using Dto.Request;
using Entities;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoStudentResponse>> ListAsync()
        {
            var collection = await _repository.ListCollectionAsync();

            return collection.Select(x => new DtoStudentResponse
            {

                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Identification = x.Identification,
                Age = x.Age,
                HouseId = x.HouseId

            }).ToList();
        }

        public async Task<DtoStudentResponse> GetByIdAsync(int id)
        {
            var studentRequest = await _repository.GetAsync(id);

            if (studentRequest == null)
                return null;

            return new DtoStudentResponse
            {
                Id = studentRequest.Id,
                Name = studentRequest.Name,
                LastName = studentRequest.LastName,
                Identification = studentRequest.Identification,
                Age = studentRequest.Age,
                HouseId = studentRequest.HouseId
            };
        }

        public async Task<int> CreateAsync(DtoStudentRequest request)
        {
            return await _repository.CreateAsync(new Student
            {
                Name = request.Name,
                LastName = request.LastName,
                Identification = request.Identification,
                Age = request.Age,
                HouseId = request.HouseId
            });
        }

        public async Task<int> UpdateAsync(int id, DtoStudentRequest request)
        {
            return await _repository.UpdateAsync(new Student
            {
                Id = id,
                Name = request.Name,
                LastName = request.LastName,
                Identification = request.Identification,
                Age = request.Age,
                HouseId = request.HouseId
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}