using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;
using LEGOINNOVATIVE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LEGOINNOVATIVE.Pages.Orders
{
    public class OrderEditModel : PageModel
    {
        private IOrderService _orderService;
        private ILoginService _loginService;
        private MockPlans mockPlans = new MockPlans();
        public Order OrderRequest { get; set; }

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string PersonalMessage { get; set; }
        [BindProperty]
        public bool Publish { get; set; }

        [BindProperty]
        public int Id { get; set; }
        public List<string> Plans { get; set; }
        [BindProperty]
        public string ChosenPlan { get; set; }
        public void OnGet(int id)
        {
            Order o = _orderService.FindOrder(id);
            Id = o.Id;
            Title = o.Title;
            Description = o.Description;
            ChosenPlan = o.Plan;

            Plans = new List<string>();

            foreach (var pl in mockPlans.GetMockPlans())
            {
                Plans.Add(pl.Type);
            }
        }
    
        public IActionResult OnPostEdit()
        {

            Order newValues = new Order(Title, Description, PersonalMessage, Id, Publish, ChosenPlan, _loginService.Profiles.Email);

            _orderService.EditOrder(newValues.Id, newValues);
            return RedirectToPage("/Sites/MasterProfile");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Sites/MasterProfile");
        }

        public OrderEditModel(IOrderService orderService, ILoginService loginService)
        {
            _orderService = orderService;
            _loginService = loginService;
        }

    }
}
