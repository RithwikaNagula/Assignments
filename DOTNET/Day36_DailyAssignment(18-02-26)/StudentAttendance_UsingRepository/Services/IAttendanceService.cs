using StudentAttendance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAttendance.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
        Task<bool> AttendanceExistsAsync(int id);
    }
}
