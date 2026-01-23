namespace JobPortal.Application.Features.JobSeekerProfiles.Commands.UpdateJobSeekerProfile
{
    public record UpdateJobSeekerProfileCommand(
        string Id,
        string? firstName,
        string? lastName,
        string? cvURL,
        List<SkillDto>? skillset) : IRequest<Result<UpdateJobSeekerProfileDto>>;
}
