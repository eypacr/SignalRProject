using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly SignalRContext context;
        public EfDiscountDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

    }
}
