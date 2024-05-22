namespace DutyApp.Domain;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
}
