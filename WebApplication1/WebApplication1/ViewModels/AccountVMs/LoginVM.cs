using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.AccountVMs
{
    public class LoginVM
    {
        public string UserName { get; set; } = null!;
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
