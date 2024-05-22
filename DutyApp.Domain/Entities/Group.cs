namespace DutyApp.Domain;

public class Group
{
       public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreatorId { get; set; }
        public User Creator { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<Task> Tasks { get; set; }

}
