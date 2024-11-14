using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRContext context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
            this.context = context;
        }

        public void BookingStatusApproved(int id)
        {
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public int BookingStatusApprovedCount()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").Count();
            return values;
        }

        public void BookingStatusCanceled(int id)
        {
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public List<Booking> GetBookingStatusApproved()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusCanceled()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusReceived()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
            return values;
        }
    }
}
