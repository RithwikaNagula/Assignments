using StudentAttendance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAttendance.Repositories
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAllWithStudentAsync();
        Task<Attendance> GetByIdWithStudentAsync(int id);
    }
}
