using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects.Contract;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType eDocumentType)
        {
            Number = number;
            EDocumentType = eDocumentType;

            AddNotifications(new CreateDocumentContract(this));
        }

        public string Number { get; private set; }
        public EDocumentType EDocumentType { get; private set; }


        public bool Validate()
        {
            if (EDocumentType == EDocumentType.CNPJ && Number.Length == 14)
            {
                return true;
            }

            if (EDocumentType == EDocumentType.CPF && Number.Length == 11)
            {
                return true;
            }

            return false;
        }
    }
}
