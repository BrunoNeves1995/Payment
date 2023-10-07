using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentContext.Domain.Entities.Contract
{
    public class CreatePayPalSubscriptionCommandContract : Contract<CreatePayPalSubscriptionCommand>
    {
        string Rgx = @"^\d{5}-\d{3}$";
        public CreatePayPalSubscriptionCommandContract(CreatePayPalSubscriptionCommand command) 
        {
            Requires()
                .IsNotNullOrEmpty(command.FirstName, "command.FirstName", "Nome é obrigatório")
                .IsLowerOrEqualsThan(3, command.FirstName.Length, "command.FirstName", "Nome precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.FirstName.Length, "command.FirstName", "Nome precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(command.LastName, "command.LastName", "Sobre nome é obrigatório")
                .IsLowerOrEqualsThan(3, command.LastName.Length, "command.LastName", "Nome precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.LastName.Length, "command.LastName", "Nome precisa ter no maximo 20 caracteres")
               
                .IsEmail(command.Email, "command.Email", "E-mail é invalido")

                .IsNotNullOrEmpty(command.PaidStreet, "command.PaidStreet", "Rua é obrigatório")
                .IsLowerOrEqualsThan(3, command.PaidStreet.Length, "command.PaidStreet", "Rua precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(10, command.PaidStreet.Length, "command.PaidStreet", "Rua precisa ter no maximo 10 caracteres")

                .IsNotNullOrEmpty(command.PaidNumer, "command.PaidNumer", "Numero é obrigatório")

                .IsNotNullOrEmpty(command.PaidNeighborhood, "command.PaidNeighborhood", "Bairro é obrigatório")
                .IsLowerOrEqualsThan(3, command.PaidNeighborhood.Length, "command.PaidNeighborhood", "Bairro precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.PaidNeighborhood.Length, "command.PaidNeighborhood", "Bairro precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(command.PaidCity, "Address.City", "Cidade é obrigatório")
                .IsLowerOrEqualsThan(3, command.PaidCity.Length, "Address.City", "Cidade precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.PaidCity.Length, "Address.City", "Cidade precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(command.Paidstate, "command.PaidCity", "Estado é obrigatório")
                .IsLowerOrEqualsThan(3, command.Paidstate.Length, "command.PaidCity", "Estado precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.Paidstate.Length, "command.PaidCity", "Estado precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(command.PaidCountry, "command.PaidCountry", "Estado é obrigatório")
                .IsLowerOrEqualsThan(3, command.PaidCountry.Length, "command.PaidCountry", "Estado precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, command.PaidCountry.Length, "command.PaidCountry", "Estado precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(command.PaidZipCode, "command.PaidZipCode", "Cep é obrigatório")
                .Matches(command.PaidZipCode, Rgx, "command.PaidZipCode", "Cep é inválido ou seu formato é invalido")
                
                .IsNotNullOrEmpty(command.DocumentNumber, "Document.DocumentNumber", "Documento é obrigatório");
                
        }
       
    }
}
