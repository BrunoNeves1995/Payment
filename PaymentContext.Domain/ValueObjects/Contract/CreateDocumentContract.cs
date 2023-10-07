using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects.Contract
{
    public class CreateDocumentContract : Contract<Document>
    {
        public CreateDocumentContract(Document document) 
        {
            Requires()
                .IsNotNullOrEmpty(document.Number, "Document.Number", "Documento é obrigatório")
                .IsTrue(document.Validate(), "Document.Number", "Documento inválido");
                
        }
    }
}
