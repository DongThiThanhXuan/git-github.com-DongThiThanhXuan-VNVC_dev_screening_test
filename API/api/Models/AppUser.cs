

namespace api.Models
{
    /// Bảng lưu thông tin user
    public class AppUser
    {
       
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
    }
}