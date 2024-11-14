using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Mapping;

namespace SignalRApi.Extensions
{
    public static class BusinessModule
    {
        public static void ConfigureDbContext(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<SignalRContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SignalRConnection"),
                    b => b.MigrationsAssembly("SignalR.DataAccessLayer"));

                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void DataAccessLayerExtensions(IServiceCollection services)
        {
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
            services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();
            services.AddScoped<IMenuTableDal, EfMenuTableDal>();
            services.AddScoped<ISliderDal, EfSliderDal>();
            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<INotificationDal, EfNotificationDal>();
        }
        public static void BusinessLayerExtensions(IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ITestoimonialService, TestimonialManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<IMenuTableService, MenuTableManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<INotificationService, NotificationManager>();
        }
        public static void AutoMapperExtensions(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AboutMapping).Assembly);
            services.AddAutoMapper(typeof(CategoryMapping).Assembly);
            services.AddAutoMapper(typeof(BookingMapping).Assembly);
            services.AddAutoMapper(typeof(CategoryMapping).Assembly);
            services.AddAutoMapper(typeof(DiscountMapping).Assembly);
            services.AddAutoMapper(typeof(ProductMapping).Assembly);
            services.AddAutoMapper(typeof(SocialMediaMapping).Assembly);
            services.AddAutoMapper(typeof(TestimonialMapping).Assembly);
            services.AddAutoMapper(typeof(BasketMapping).Assembly);
            services.AddAutoMapper(typeof(NotificationMapping).Assembly);
            services.AddAutoMapper(typeof(SliderMapping).Assembly);
        }
        public static void ValidationExtensions(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();
        }
        public static void CORSExtensions(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
                });
            });

            services.AddSignalR();
        }
    }
}
