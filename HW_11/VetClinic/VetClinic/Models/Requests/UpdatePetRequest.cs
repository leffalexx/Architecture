namespace VetClinic.Models.Requests
{
    public class UpdatePetRequest
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
