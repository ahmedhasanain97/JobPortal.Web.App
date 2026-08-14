namespace JobPortal.Application.Features.Skills.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, Result<List<SkillDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<SkillDto>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Skill>();
            var result = repo.GetAll();
            if (result == null || !result.Any())
                return Result.Failure<List<SkillDto>>(Error.NotFound("No skills found"));
            var skillDtos = result.Select(s => new SkillDto { Id = s.Id, Name = s.Name }).ToList();
            return Result.Success(skillDtos);
        }
    }
}
