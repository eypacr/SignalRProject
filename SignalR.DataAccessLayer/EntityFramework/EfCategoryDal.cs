using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext context;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public int ActiveCategoryCount()
        {
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int CategoryCount()
        {
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
