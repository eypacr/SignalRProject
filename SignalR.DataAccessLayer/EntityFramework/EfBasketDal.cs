using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext context;

        public EfBasketDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            var values = context.Baskets.Where(x => x.MenuTableId == id).Include(y => y.Product).ToList();
            return values;
        }
    }
}
