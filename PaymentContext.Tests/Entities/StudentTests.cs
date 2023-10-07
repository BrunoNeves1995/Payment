using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{   
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Payment _payment;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;

     public StudentTests()
        {
            _name = new Name("Bruno", "Neves");
            _document = new Document("04778440145", EDocumentType.CPF);
            _email = new Email("nevesbrino@gmail.com");
            _address = new Address("Rua4567891", "12345", "bairro 1", "cidade 1", "MT", "Brasil", "78280-000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _payment = new PayPalPayment("123456789", DateTime.UtcNow, DateTime.UtcNow.AddDays(5), 10, 11, "Fabiula", _document, _address, _email);
            
        }


        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionPaymentIsInvalid() 
        {
     
            _student.AddSubscription(_subscription);

            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccesWhenSubscriptionPaymentIsValid()
        {
            _subscription.AddPayment( (PayPalPayment) _payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.IsValid);

        }
    }
}
