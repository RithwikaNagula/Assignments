using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAllWithStudentAsync();
        Task<Attendance> GetByIdWithStudentAsync(int id);
    }
}
