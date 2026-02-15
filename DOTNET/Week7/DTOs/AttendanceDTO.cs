namespace StudentAttendanceAPI.DTOs
{
    public class AttendanceDTO
    {
        public int StudentId { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }
    }
}
