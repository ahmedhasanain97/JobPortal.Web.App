namespace JobPortal.Application.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Result<SkillDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SkillDto>> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Skill>();
            var skill = await repo.FindByIdAsync(request.skillId);
            if (skill == null)
                return Result.Failure<SkillDto>(Error.NotFound("Skill not found"));
            var existingSkill = await repo.FindAsync(s => s.Name.ToLower() == request.name.ToLower() && s.Id != request.skillId);
            if (existingSkill != null)
                return Result.Failure<SkillDto>(Error.BadRequest("Skill with the same name already exists"));
            skill.Name = request.name;
            repo.Update(skill);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == -1)
                return Result.Failure<SkillDto>(Error.BadRequest("Failed to update skill"));
            return Result.Success(new SkillDto { Id = skill.Id, Name = skill.Name });
        }
    }
}
