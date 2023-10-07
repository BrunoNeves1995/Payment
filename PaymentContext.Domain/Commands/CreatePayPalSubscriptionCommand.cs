using Flunt.Notifications;
using PaymentContext.Domain.Entities.Contract;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.ValueObjects.Contract;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public EDocumentType EDocumentType { get; set; }

        public string TransactionCode { get; set; } = string.Empty;
        public string TransactionNumber { get; set; } = string.Empty;
        public DateTime PaidDate { get; set; }  
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string OwnerPayer { get; set; } = string.Empty;
        public string PaidNumber { get; set; } = string.Empty;
        public EDocumentType PaidEDocumentType { get; set; }
        public string PaidStreet { get; set; } = string.Empty;
        public string PaidNumer { get; set; } = string.Empty;
        public string PaidNeighborhood { get; set; } = string.Empty;
        public string PaidCity { get; set; } = string.Empty;
        public string Paidstate { get; set; } = string.Empty;
        public string PaidCountry { get; set; } = string.Empty;
        public string PaidZipCode { get; set; } = string.Empty;
        public string PaidAddress { get; set; } = string.Empty;

        public void Validate()
        {
            AddNotifications(new CreatePayPalSubscriptionCommandContract(this));
        }
    }
}
