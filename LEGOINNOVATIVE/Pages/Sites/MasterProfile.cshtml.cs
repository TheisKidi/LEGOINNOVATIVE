using LEGOINNOVATIVE.Model;
using LEGOINNOVATIVE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LEGOINNOVATIVE.Pages.Sites
{
    public class MasterProfileModel : PageModel
    {
        private ILoginService _loginService;
        private IOrderService _orderService;
        public Profiles Profiles { get; set; }
        public List<Order> Orders { get; set; }

        public void OnGet()
        {
            Profiles = _loginService.Profiles;
            Orders = _orderService.GetOrders();
        }

        public IActionResult OnPostRemove(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToPage("/Sites/MasterProfile");
        }

        public MasterProfileModel(ILoginService loginService, IOrderService orderService)
        {
            _loginService = loginService;
            _orderService = orderService;
        }
    }
}
