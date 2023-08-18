using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services {
    internal class DateTimeProvider : IDateTimeProvider {
        // Expression-Bodied Property
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
