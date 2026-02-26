namespace BusinessLayer.Interface
{
    public class ChangePasswordDTO
    {
        public int Id { get; set; }

        public string OldPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}