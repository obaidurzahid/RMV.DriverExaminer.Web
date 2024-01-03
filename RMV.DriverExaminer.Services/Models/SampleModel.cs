namespace RMV.DriverExaminer.Services.Models
{
    public class SampleModel
    {
        public long Id { get; set; }
        public required string Code { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
