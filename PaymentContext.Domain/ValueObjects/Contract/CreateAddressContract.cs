using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentContext.Domain.ValueObjects.Contract
{
    public class CreateAddressContract : Contract<Address>
    {
        string Rgx = @"^\d{5}-\d{3}$";
        public CreateAddressContract(Address address) 
        {
            Requires()
                .IsNotNullOrEmpty(address.Street, "Address.Street", "Rua é obrigatório")
                .IsLowerOrEqualsThan(3, address.Street.Length, "Address.Street", "Rua precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(10, address.Street.Length, "Address.Street", "Rua precisa ter no maximo 10 caracteres")

                .IsNotNullOrEmpty(address.Numer, "Address.Numer", "Numero é obrigatório")

                .IsNotNullOrEmpty(address.Neighborhood, "Address.Neighborhood", "Bairro é obrigatório")
                .IsLowerOrEqualsThan(3, address.Neighborhood.Length, "Address.Neighborhood", "Bairro precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, address.Neighborhood.Length, "Address.Neighborhood", "Bairro precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(address.City, "Address.City", "Cidade é obrigatório")
                .IsLowerOrEqualsThan(3, address.City.Length, "Address.City", "Cidade precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, address.City.Length, "Address.City", "Cidade precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(address.state, "Address.state", "Estado é obrigatório")
                .IsLowerOrEqualsThan(3, address.state.Length, "Address.state", "Estado precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, address.state.Length, "Address.state", "Estado precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(address.Country, "Address.Country", "Estado é obrigatório")
                .IsLowerOrEqualsThan(3, address.Country.Length, "Address.Country", "Estado precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, address.Country.Length, "Address.Country", "Estado precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(address.ZipCode, "Address.ZipCode", "Cep é obrigatório")
                .Matches(address.ZipCode, Rgx, "Address.ZipCode", "Cep é inválido ou seu formato é invalido");
                ;
        }
    }
}
