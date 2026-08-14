namespace JobPortal.Application.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Result<SkillDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SkillDto>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Skill>();
            var existingSkill = await repo.FindIncludingDeletedAsync(s => s.Name.ToLower() == request.Name.ToLower());
            if (existingSkill != null)
            {
                if (existingSkill.IsDeleted)
                {
                    existingSkill.IsDeleted = false;
                    repo.Update(existingSkill);
                    var restore = await _unitOfWork.SaveChangesAsync();
                    if (restore == -1)
                        return Result.Failure<SkillDto>(Error.BadRequest("Failed to restore skill"));
                    return Result.Success(new SkillDto { Id = existingSkill.Id, Name = existingSkill.Name });
                }
                else
                {
                    return Result.Failure<SkillDto>(Error.BadRequest("Skill already exists"));
                }
            }

            var newSkill = await repo.PostAsync(new Skill { Name = request.Name });
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == -1)
                return Result.Failure<SkillDto>(Error.BadRequest("Failed to create skill"));
            return Result.Success(new SkillDto { Id = newSkill.Id, Name = newSkill.Name });
        }
    }
}
