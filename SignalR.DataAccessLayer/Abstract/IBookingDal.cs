using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
        int BookingStatusApprovedCount();
        void BookingStatusCanceled(int id);
        List<Booking> GetBookingStatusApproved();
        List<Booking> GetBookingStatusCanceled();
        List<Booking> GetBookingStatusReceived();
    }
}
