using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.ViewModels.IdentityViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username (Login)")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = true;

        public string ReturnUrl { get; set; }
    }
}
