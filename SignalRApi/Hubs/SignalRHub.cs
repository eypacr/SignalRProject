using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly ISliderService _sliderService;
        private readonly IContactService _contactService;
        private readonly IAboutService _aboutService;
        private readonly IDiscountService _discountService;
        private readonly ITestoimonialService _testimonialService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService, ISliderService sliderService, IContactService contactService, IAboutService aboutService, IDiscountService discountService, ITestoimonialService testimonialService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _sliderService = sliderService;
            _contactService = contactService;
            _aboutService = aboutService;
            _discountService = discountService;
            _testimonialService = testimonialService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

            var value5 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5.ToString("0.00") + "₺");

            var value6 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6.ToString("0.00") + "₺");

            var value7 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _menuTableService.TActiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveMenuTableCount", value9);

        }
        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
        public async Task GetBookingStatusApproved()
        {
            var values = _bookingService.TGetBookingStatusApproved();
            await Clients.All.SendAsync("ReceiveBookingStatusApproved", values);
        }
        public async Task GetBookingStatusCanceled()
        {
            var values = _bookingService.TGetBookingStatusCanceled();
            await Clients.All.SendAsync("ReceiveBookingStatusCanceled", values);
        }
        public async Task GetBookingStatusReceived()
        {
            var values = _bookingService.TGetBookingStatusReceived();
            await Clients.All.SendAsync("ReceiveBookingStatusReceived", values);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveAllNotificationCountByFalse", notificationListByFalse);

            var value1 = _notificationService.TGetListAll();
            await Clients.All.SendAsync("ReceiveNotificationList", value1);
        }
        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);

            var values2 = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableList", values2);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendProductStatus()
        {
            var values = _productService.TGetProductsWithCategories();
            var result = values.Select(p => new ResultProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                ProductStatus = p.ProductStatus,
                CategoryName = p.Category != null ? p.Category.CategoryName : "Kategori Yok"
            }).ToList();

            await Clients.All.SendAsync("ReceiveProductList", result);
        }
        public async Task GetList()
        {


            var values1 = _sliderService.TGetListAll();
            await Clients.All.SendAsync("ReceiveSliderList", values1);

            var values2 = _categoryService.TGetListAll();
            await Clients.All.SendAsync("ReceiveCategoryList", values2);

            var values3 = _contactService.TGetListAll();
            await Clients.All.SendAsync("ReceiveContactList", values3);

            var values4 = _aboutService.TGetListAll();
            await Clients.All.SendAsync("ReceiveAboutList", values4);

            var values5 = _discountService.TGetListAll();
            await Clients.All.SendAsync("ReceiveDiscountList", values5);

            var values6 = _testimonialService.TGetListAll();
            await Clients.All.SendAsync("ReceiveTestimonialList", values6);

        }
    }
}
