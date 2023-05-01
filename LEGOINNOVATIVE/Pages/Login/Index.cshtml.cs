using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;
using LEGOINNOVATIVE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LEGOINNOVATIVE.Pages.Login
{
    public class IndexModel : PageModel
    {
        private ILoginService _loginService;

        [BindProperty, Required(ErrorMessage ="Your password is requeried to log in")]
        public string Password { get; set; }
        [BindProperty, Required(ErrorMessage ="Your email is requeried to log in")]
        public string Email { get; set; }



        public IActionResult OnPost()
        {
            var check = _loginService.Login(Email, Password);
            var checkAdmin = _loginService.Profiles.IsAdmin;
            if (check && !checkAdmin)
            {
                return RedirectToPage("/Sites/CustomerProfile");
            }
            else if (check && checkAdmin)
            {
                return RedirectToPage("/Sites/MasterProfile");
            }
            return Page();
        }

        public IndexModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

    }
}
