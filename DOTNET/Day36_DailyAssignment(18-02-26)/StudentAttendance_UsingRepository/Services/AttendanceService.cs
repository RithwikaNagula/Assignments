using StudentAttendance.Models;
using StudentAttendance.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAttendance.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllWithStudentAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetByIdWithStudentAsync(id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.UpdateAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            await _attendanceRepository.DeleteAsync(id);
        }

        public async Task<bool> AttendanceExistsAsync(int id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            return attendance != null;
        }
    }
}
