using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly SignalRContext context;
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public int ActiveMenuTableCount()
        {
            return context.MenuTables.Count(x => x.Status == true);
        }

        public void GetMenuTableStatusEmpty(int id)
        {
            var value = context.MenuTables.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void GetMenuTableStatusFull(int id)
        {
            var value = context.MenuTables.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
            return context.MenuTables.Count();
        }
    }
}
