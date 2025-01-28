using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Rents.Events;
using CleanArchitecture.Domain.Users;
using MediatR;

namespace CleanArchitecture.Application.Rents.ReserveRent
{
    internal sealed class ReserveRentDomainEventHandler
    (
        IRentRepository rentRepository, 
        IUserRepository userRpository, 
        IEmailService emailService
    ) : INotificationHandler<RentReservedDomainEvent>
    {
        private readonly IRentRepository _rentRepository = rentRepository;
        private readonly IUserRepository _userRpository = userRpository;
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(RentReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetByIdAsync(notification.RentId, cancellationToken);

            if (rent == null)
            {
                return;
            }

            var user = await _userRpository.GetByIdAsync(rent.UserId, cancellationToken);

            if(user == null)
            {
                return;
            }
        
            await _emailService.SendAsync(user.Email!, "Rent Confirmed", "Confirm the rent or it'll be cancelled");
        }
    }
}