namespace StudentAttendanceAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation property
        public List<Attendance>? Attendances { get; set; }
    }
}
