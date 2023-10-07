using PaymentContext.Domain.Entities.Contract;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {   
        private readonly IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
           
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);

        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address? Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions =>  _subscriptions.ToArray(); 

        //Cancela todas as outras assinatura, e coloca esta como principal
        public void AddSubscription(Subscription Subscription)
        {
            foreach (var sub in Subscriptions)
            {
                sub.InactiveSubscription();
            }

            _subscriptions.Add(Subscription);

            AddNotifications(new CreateSubscriptionContract(Subscription));


        }
    }
}
