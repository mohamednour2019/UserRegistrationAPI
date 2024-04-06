using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace RegistrationWebApplication.Presentation.API.Controllers
{
    public class ErrorController:Controller
    {
        private ContentResult _contentResult;
        public ErrorController()
        {
            _contentResult = new ContentResult()
            {
                Content = "an error occured!"
            };
        }


        [Route("/Error")]
        public async Task<IActionResult> Error()
        {
            _contentResult.StatusCode = (int)HttpStatusCode.InternalServerError;
            IExceptionHandlerPathFeature? exception =
           HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exception is not null&& exception.Error is not null)
            {
                _contentResult.Content= exception.Error.Message;
            }

            return _contentResult;
        }
    }
}
