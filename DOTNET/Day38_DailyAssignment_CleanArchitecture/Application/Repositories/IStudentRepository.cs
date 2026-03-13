using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllWithAttendanceAsync();
        Task<Student> GetByIdWithAttendanceAsync(int id);
    }
}
