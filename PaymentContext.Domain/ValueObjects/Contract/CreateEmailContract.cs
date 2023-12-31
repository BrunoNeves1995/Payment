﻿using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects.Contract
{
    public class CreateEmailContract : Contract<Email>
    {
        public CreateEmailContract(Email email) 
        {
            Requires()
                .IsEmail(email.Address, "Email.Address", "E-mail invalido");
        }

    }
}
