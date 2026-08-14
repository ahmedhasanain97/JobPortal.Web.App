namespace JobPortal.Application.Features.Skills.Commands.SoftDeleteSkill
{
    public class SoftDeleteSkillCommandHandler : IRequestHandler<SoftDeleteSkillCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SoftDeleteSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(SoftDeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Skill>();
            var skill = await repo.FindByIdAsync(request.skillId);
            if (skill == null)
                return Result.Failure(Error.NotFound("Skill Not Found"));
            repo.SoftDelete(skill);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == -1)
                return Result.Failure(Error.BadRequest("Failed to delete skill"));
            return Result.Success();
        }
    }
}
