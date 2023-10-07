
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable<Notification>,
        IHandler<CreatePayPalSubscriptionCommand, CommandResult>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService) 
        {   
            _repository = repository;
            _emailService = emailService;
        }

        public CommandResult Handle(CreatePayPalSubscriptionCommand command)
        {   
            // fail fast validate
            command.Validate();
            if (!command.IsValid)
            {   
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar asssinatura");
            }


            // verirficar se o documento já esta cadastrado
            if (_repository.DocumentExists(command.DocumentNumber))
                AddNotification("command.DocumentNumber", "Este documento já esta em uso");


            // verificar se email já esta cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("command.Email", "Este e-mail já esta em uso");


            // gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.DocumentNumber, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.PaidStreet, command.PaidNumer, command.PaidNeighborhood, command.PaidCity, command.Paidstate, command.PaidCountry, command.PaidZipCode);


            // gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(command.ExpireDate);
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate,command.Total, command.TotalPaid, command.OwnerPayer, document, address, email);


            // relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);


            // agrupar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // checar as notificaçoes
            if (!IsValid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            // salvar as informações
            _repository.CreateSubscription(student);


            // enviar e-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo ao balta.oi", "Sua assinatura foi criada");

            // retorna as informações 
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
