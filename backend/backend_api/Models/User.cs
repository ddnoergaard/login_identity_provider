namespace backend_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string? DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }

        //Email and password are stored in Firebase, so no need to obtain that.
    }
}
