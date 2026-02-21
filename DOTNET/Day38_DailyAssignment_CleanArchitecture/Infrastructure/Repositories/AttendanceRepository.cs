using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Models;
using Application.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllWithStudentAsync()
        {
            return await _context.Attendances.Include(a => a.Student).ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<Attendance> GetByIdWithStudentAsync(int id)
        {
            return await _context.Attendances.Include(a => a.Student).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Attendance entity)
        {
            await _context.Attendances.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
