using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        public int TNotificationCountByStatusFalse();
        public List<Notification> TGetAllNotificationByFalse();
        public void TNotificationStatusChangeToTrue(int id);
        public void TNotificationStatusChangeToFalse(int id);
    }
}
