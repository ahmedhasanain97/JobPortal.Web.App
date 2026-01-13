using JobPortal.Application.Abstractions;
using JobPortal.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ApplicationUser>();
            var user = await repo.FindAsync(u => u.Id == request.userId);
            if (user == null)
                return Result.Failure<UserDto>(Error.NotFound("User Not Found"));
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                UserName = user.UserName!
            };
        }
    }
}
