using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;
using LEGOINNOVATIVE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LEGOINNOVATIVE.Pages.Orders
{
    public class MakeOrderModel : PageModel
    {

        private IOrderService _orderService;
        private ILoginService _loginService;

        private MockPlans mockPlans = new MockPlans();

        public Profiles ProfileLoggedIn { get; set; }

        [BindProperty, Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [BindProperty, Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [BindProperty]
        public string PersonalMessage { get; set; }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public bool Publish { get; set; }

        public List<string> Plans { get; set; }
        [BindProperty]
        public string ChosenPlan { get; set; }
        public void OnGet()
        {
            Plans = new List<string>();

            foreach (var pl in mockPlans.GetMockPlans())
            {
                Plans.Add(pl.Type);
            }
        }

        public int MakeId()
        {
                Id = _orderService.GetOrders().Count + 1;
                return Id;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ProfileLoggedIn = _loginService.FindProfile(_loginService.Profiles.Email);
            Order newOrder = new Order(Title, Description, PersonalMessage, MakeId(), Publish, ChosenPlan, ProfileLoggedIn.Email);

            MockOrders mockOrders = new MockOrders();
            mockOrders.Add(newOrder);
            _orderService.Add(newOrder);
            return RedirectToPage("/Sites/CustomerProfile");
        }

        public MakeOrderModel(IOrderService service, ILoginService loginService)
        {
            _orderService = service;
            _loginService = loginService;
        }


    }
}
