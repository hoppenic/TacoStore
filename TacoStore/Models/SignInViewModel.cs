using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacoStore.Models;
using System.ComponentModel.DataAnnotations;

namespace TacoStore.Models
{
    public class SignInViewModel
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }

    }
}
