namespace HospitalProject.Models.Responses.DocResponses
{
    public class UpdateResponse
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

    }
}
