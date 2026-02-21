using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Models;
using Application.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceDbContext _context;

        public StudentRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllWithAttendanceAsync()
        {
            return await _context.Students.Include(s => s.Attendances).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> GetByIdWithAttendanceAsync(int id)
        {
            return await _context.Students.Include(s => s.Attendances).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
