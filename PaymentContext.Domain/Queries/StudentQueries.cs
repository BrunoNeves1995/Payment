using PaymentContext.Domain.Entities;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Queries
{
    public class StudentQueries
    {
        public static Expression<Func<Student, bool>> Getstudentdocument(string document)
        {
            return x => x.Document.Number == document;
        }

        public static Expression<Func<Student, bool>> Getstudentemail(string email)
        {
            return x => x.Email.Address == email;
        }
    }
}
