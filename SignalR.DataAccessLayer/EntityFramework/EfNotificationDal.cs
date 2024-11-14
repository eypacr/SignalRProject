using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            return context.Notifications.Where(x => x.Status == false).Count();
        }
        public void NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
        public void NotificationStatusChangeToFalse(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

    }
}
