using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace REZReport.Core.Models
{
    public class ConfirmEmailModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
    }
}
