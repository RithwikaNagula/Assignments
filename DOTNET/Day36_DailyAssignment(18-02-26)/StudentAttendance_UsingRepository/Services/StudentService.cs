using StudentAttendance.Models;
using StudentAttendance.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAttendance.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllWithAttendanceAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdWithAttendanceAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student != null;
        }
    }
}
