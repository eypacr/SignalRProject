using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
        void TGetMenuTableStatusFull(int id);
        void TGetMenuTableStatusEmpty(int id);
        public int TActiveMenuTableCount();
    }
}
