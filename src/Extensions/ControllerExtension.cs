
using AlphaCompanyWebApi.Exceptions;


namespace Microsoft.AspNetCore.Mvc
{
    public static class ControllerExtension
    {
        /// <summary>
        /// Validate model.
        /// </summary>
        /// <param name="controller"></param>
        public static void ValidateRequest(this Controller controller)
        {
            if (!controller.ModelState.IsValid)
                throw new ValidationException("Some attribute(s) fail to pass validation.", controller.ModelState);
        }

       
    }
}