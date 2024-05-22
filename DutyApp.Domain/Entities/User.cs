namespace DutyApp.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
