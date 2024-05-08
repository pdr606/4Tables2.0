using _4Tables2._0.Domain.Base.Common;

namespace _4Tables2._0.Domain.Base.Entity
{
    public abstract class BaseEntity
    {
        List<Notifcation> _notifcations = new();

        public DateTime Created_At { get; private set; } = DateTime.Now;
        public DateTime? Updated_At { get; private set; }
        public bool Available { get; private set; } = true;
        public IReadOnlyCollection<Notifcation> Notifcations => _notifcations;

        public BaseEntity IsAvailable(bool available)
        {
            if (available) Available = true; else Available = false; return this;
        }

        public BaseEntity Update()
        {
            Updated_At = DateTime.UtcNow.AddHours(-3); 
            return 
                this;
        }

        public void PullNotification(Notifcation notification)
        {
            _notifcations.Add(notification);
        }
    }
}
