using RegistrationWebApplication.Core.Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Domain.Entitites
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Provide a Name")]
        [StringLength(30,ErrorMessage ="Name Should be Less Than 30 Character")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Provide an Email")]
        public string Email { get; set; }
        [Range(20,30,ErrorMessage ="Age Range Should be Between 20 & 30")]
        public int Age {  get; set; }
        public DateTime DateTime { get; set; }

    }

    public static class UserExtension
    {
        public static UserOutputDto ToUserOutputDto(this User user)
        {
            return new UserOutputDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                DateTime = user.DateTime,

            };
        }
    }
}
