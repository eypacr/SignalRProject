using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMenuTableDal : IGenericDal<MenuTable>
    {
        int MenuTableCount();
        void GetMenuTableStatusFull(int id);
        void GetMenuTableStatusEmpty(int id);
        public int ActiveMenuTableCount();
    }
}
