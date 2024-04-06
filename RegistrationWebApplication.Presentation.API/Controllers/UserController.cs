using Microsoft.AspNetCore.Mvc;
using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.ServicesContracts;
using System.Net;
using System.Text.Json;

namespace RegistrationWebApplication.Presentation.API.Controllers
{
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private ContentResult _contentResult;
        public UserController()
        {
            _contentResult = new ContentResult();
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Add(UserInputDto user,
            [FromServices] IAddUserService addUserService)
        {
            UserOutputDto response = await addUserService.AddUser(user);
            _contentResult.StatusCode = (int)HttpStatusCode.OK;
            _contentResult.Content = JsonSerializer.Serialize(response);
            return _contentResult;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> Search(string name,
            [FromServices] IGetUserByNameService getUserByName)
        {
            UserOutputDto response = await getUserByName.GetUserByName(name);
            _contentResult.StatusCode = (int)HttpStatusCode.OK;
            _contentResult.Content = JsonSerializer.Serialize(response);
            return _contentResult;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> SearchBy(string key,int ascDesc,
            [FromServices] IGetUserSortedService getUserSortedService)
        {
           List<UserOutputDto>response= await getUserSortedService.GetAllUsersSortedBy(key,ascDesc);
            _contentResult.StatusCode = (int)HttpStatusCode.OK;
            _contentResult.Content = JsonSerializer.Serialize(response);
            return _contentResult;
        }
    }
    
}
