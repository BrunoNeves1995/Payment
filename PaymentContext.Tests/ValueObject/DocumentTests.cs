using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObject
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnsErrorWhenCNPJIsInvalid() 
        {
            var doc = new Document("1234567891023", EDocumentType.CNPJ) ;
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJisValid()
        {
            var doc = new Document("04630343000190", EDocumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnsErrorWhenCPFIsInvalid()
        {
            var doc = new Document("0477844014", EDocumentType.CPF);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("04778440145")]
        [DataRow("04778440146")]
        [DataRow("04778440147")]
        [DataRow("04778440148")]
        public void ShouldReturnSuccessWhenCPFisValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.IsValid);
        }
    }
}
