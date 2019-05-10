namespace LoginCodeFirst.ViewModels.User
{
    public class EditViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int StoreId { get; set; }
        public bool IsActive { get; set; }
    }
}