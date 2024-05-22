using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class OrderConfirmationModel : PageModel
    {
        private readonly OrderService _orderService;

        public Models.Order Order { get; set; }

        public OrderConfirmationModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGetAsync(int orderId)
        {
            Order = _orderService.GetOrders().FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
