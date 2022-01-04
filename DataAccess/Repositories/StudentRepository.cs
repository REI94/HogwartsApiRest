//Repository pattern implementation.

using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HogwartsApiRestDbContext _context;

        public StudentRepository(HogwartsApiRestDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Student>> ListCollectionAsync()
        {
            return await _context.Set<Student>()
                .ToListAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Set<Student>()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Student studentRequest)
        {
            await _context.Set<Student>().AddAsync(studentRequest);
            await _context.SaveChangesAsync();

            return studentRequest.Id;
        }

        public async Task<int> UpdateAsync(Student studentRequest)
        {
            _context.Set<Student>().Attach(studentRequest);
            _context.Entry(studentRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return studentRequest.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Student>().SingleOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _context.Set<Student>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
