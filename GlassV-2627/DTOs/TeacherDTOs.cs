namespace GlassV_2627.DTOs
{
    public class TeacherResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }

    public class CreateTeacherDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }

    public class UpdateTeacherDto
    {
        public int TeacherId { get; set; }
        public string NewSubject { get; set; } = string.Empty;
    }
}