using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities.Contract
{
    public class CreatePaymentContract : Contract<PayPalPayment>
    {
        public CreatePaymentContract(PayPalPayment payment)
        {
            Requires()
               .IsGreaterOrEqualsThan(DateTime.UtcNow, payment.PaidDate, "Payment.PaidDate", "A data de pagamento não pode estar no passado")
               .IsGreaterThan(payment.ExpireDate, DateTime.UtcNow, "Payment.PaidDate", "A data de expiração não pode estar no passado")
               .IsLowerOrEqualsThan(0, payment.Total, "Payment.Total", "O total não pode ser zero")
               .IsGreaterOrEqualsThan(payment.Total, payment.TotalPaid, "Payment.Total", "O valor pago, não pode ser menor que o total");
        }
    }
}
