namespace JobPortal.Application.Features.EmployerProfile.Queries
{
    public class GetEmployerProfileQueryHandler : IRequestHandler<GetEmployerProfileQuery, Result<EmployerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEmployerProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<EmployerDto>> Handle(GetEmployerProfileQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ApplicationUser>();
            var EmployerProfile = await repo.FindByIdAsync(request.userId);
            if (EmployerProfile == null)
                return Result.Failure<EmployerDto>(Error.NotFound("Employer Not Found"));
            return Result.Success(new EmployerDto
            {
                Id = EmployerProfile.Id,
                FirstName = EmployerProfile.FirstName,
                LastName = EmployerProfile.LastName,
                Email = EmployerProfile.Email!,
                CompanyName = EmployerProfile.CompanyName
            });
        }
    }
}
