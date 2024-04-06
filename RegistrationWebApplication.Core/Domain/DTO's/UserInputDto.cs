using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Domain.DTO_s
{
    public class UserInputDto
    {
        [Required(ErrorMessage = "Provide a Name")]
        [StringLength(30, ErrorMessage = "Name Should be Less Than 30 Character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide an Email")]
        public string Email { get; set; }
        [Range(20, 30, ErrorMessage = "Age Range Should be Between 20 & 30")]
        public int Age { get; set; }

        public string Contenital {  get; set; }
        public string Country {  get; set; }

        public User ToUser()
        {
            return new User
            {
                Name = Name,
                Email = Email,
                Age = Age,
            };
        }
    }
}
