namespace StudentAttendance.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }

        // Foreign Key
        public int StudentId { get; set; }


        public Student? Student { get; set; }
    }
}
