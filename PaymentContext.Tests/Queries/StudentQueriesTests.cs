using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _student = new List<Student>();

        public StudentQueriesTests()
        {

            for (int i = 0; i <= 10; i++)
            {
                _student.Add(new Student(new Name("Aluno", "sobre" + i.ToString()), new Document("1234567891" + i.ToString(), EDocumentType.CPF), new Email("novo" + i.ToString() +"@teste.com")));
            }

            
            



        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistirNot()
        {
            var expression = StudentQueries.Getstudentdocument("99999999999");

            var student = _student.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistir()
        {
            var expression = StudentQueries.Getstudentdocument("12345678912");

            var student = _student.AsQueryable().Where(expression).FirstOrDefault();

            Assert.IsNotNull(student);
        }
    }
}
