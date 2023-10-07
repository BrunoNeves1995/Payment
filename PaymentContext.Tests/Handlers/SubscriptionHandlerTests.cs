using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistirNot()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "Bruno";
            command.LastName = "Neves";
            command.Email = "teste@teste.com";
            command.DocumentNumber = "99999999999";
            command.EDocumentType = EDocumentType.CPF;
            command.TransactionCode = "123456";
            command.TransactionNumber = "123456";
            command.PaidDate = DateTime.UtcNow;
            command.ExpireDate = DateTime.UtcNow.AddYears(1); 
            command.Total = 100;
            command.TotalPaid = 100;
            command.OwnerPayer = "Fabiula magalhaes";
            command.PaidNumber = "12345608910";
            command.PaidEDocumentType = EDocumentType.CPF;
            command.PaidStreet = "Rua 1";
            command.PaidNumer = "1020";
            command.PaidNeighborhood = "bairro 1";
            command.PaidCity = "Mirassol";
            command.Paidstate = "MaTo Grosso";
            command.PaidCountry = "Brasil";
            command.PaidZipCode = "78280-000";
            command.PaidAddress = "fabiula@gmail.com";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistir()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "Bruno";
            command.LastName = "Neves";
            command.Email = "novo@teste.com";
            command.DocumentNumber = "99999999998";
            command.EDocumentType = EDocumentType.CPF;
            command.TransactionCode = "123456";
            command.TransactionNumber = "123456";
            command.PaidDate = DateTime.UtcNow;
            command.ExpireDate = DateTime.UtcNow.AddYears(1);
            command.Total = 100;
            command.TotalPaid = 100;
            command.OwnerPayer = "Fabiula magalhaes";
            command.PaidNumber = "12345608910";
            command.PaidEDocumentType = EDocumentType.CPF;
            command.PaidStreet = "Rua 1";
            command.PaidNumer = "1020";
            command.PaidNeighborhood = "bairro 1";
            command.PaidCity = "Mirassol";
            command.Paidstate = "MaTo Grosso";
            command.PaidCountry = "Brasil";
            command.PaidZipCode = "78280-000";
            command.PaidAddress = "fabiula@gmail.com";

            handler.Handle(command);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}

