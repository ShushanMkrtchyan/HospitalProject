namespace HospitalProject.Models.Responses.PatResponses
{
    public class UpdPateResponse
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoomID { get; set; }
        public int DoctorID { get; set; }
        public DateTime? TreatStartDate { get; set; }
        public DateTime? TreatEndDate { get; set; }
        public string? ErrMsg { get; set; }

    }
}
