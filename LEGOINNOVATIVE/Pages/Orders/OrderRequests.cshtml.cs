using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;
using LEGOINNOVATIVE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace LEGOINNOVATIVE.Pages.Orders
{
    public class OrderRequestsModel : PageModel
    {
        private IOrderService _orderService;
        private ILoginService _loginService;
        private IPlanService _planService;

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string PlanType { get; set; }
        [BindProperty]
        public int Bricks { get; set; }
        [BindProperty]
        public bool Accepted { get; set; }

        public void OnGet(int id)
        {
            Order o = _orderService.FindOrder(id);
            Email = o.Email;
            Name = _loginService.FindProfile(Email).Name;
            Phone = _loginService.FindProfile(Email).Phone;
            Id = o.Id;
            Title = o.Title;
            Description = o.Description;
            PlanType = o.Plan;
            Bricks = _planService.FindPlan(PlanType).BrickAmount;
        }

        public OrderRequestsModel(IOrderService orderService, ILoginService loginService, IPlanService planService)
        {
            _orderService = orderService;
            _loginService = loginService;
            _planService = planService;
        }

        public IActionResult OnPostEdit()
        {
            return RedirectToPage("/Orders/OrderEdit");
        }

        public IActionResult OnPostDecline(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToPage("/Sites/MasterProfile");
        }

        public IActionResult OnPostAccept(int id)
        {
            Order o = _orderService.FindOrder(id);
            o.Accepted = true;

            _orderService.EditOrder(o.Id, o);
            return RedirectToPage("/Sites/MasterProfile");
        }

    }
}
