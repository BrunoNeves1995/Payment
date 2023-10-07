using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities.Contract
{
    public class CreateSubscriptionContract : Contract<Subscription>
    {
        public CreateSubscriptionContract(Subscription subscription) 
        {
            Requires()
                .IsTrue(subscription.Payments.Any(), "Subscription.Payments", "Esta assinatura não possui pagamentos");
                

        }


    }
}
