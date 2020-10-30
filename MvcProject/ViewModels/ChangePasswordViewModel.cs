namespace MvcProject.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}