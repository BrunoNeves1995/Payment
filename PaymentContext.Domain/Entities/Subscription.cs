using PaymentContext.Domain.Entities.Contract;
using PaymentContext.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {   
        private readonly IList<PayPalPayment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<PayPalPayment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<PayPalPayment> Payments => _payments.ToArray(); 

        public void AddPayment(PayPalPayment payment)
        {
            _payments.Add(payment);
            AddNotifications(new CreatePaymentContract(payment));
        }

        public void ActiveSubscription()
        {
            Active = true;
            LastUpdateDate = DateTime.UtcNow;
           
        }

        public void InactiveSubscription()
        {
            Active = false;
            LastUpdateDate = DateTime.UtcNow;
            
        }

    }
}
