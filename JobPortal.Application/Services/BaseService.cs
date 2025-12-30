using JobPortal.Application.Abstractions;

namespace JobPortal.Application.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    }
}