namespace ServiceHub.Api.Models
{
    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        public Guid ServiceId { get; set; }

        public Guid ServiceProviderId { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public Customer Customer { get; set; } = null!;

        public Service Service { get; set; } = null!;

        public ServiceProvider ServiceProvider { get; set; } = null!;
    }
}
