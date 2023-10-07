using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Shared.Entity
{
    public abstract class Entity : Notifiable<Notification>
    {
        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; private set; }
    }
}
