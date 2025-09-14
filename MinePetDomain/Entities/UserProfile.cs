namespace Domain.Entities;

public class UserProfile
{
        public int UserId { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Alias { get; private set; }
        public string? Phone { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? IdentityNumber { get; private set; }

        public UserProfile()
        {
        }

        public UserProfile(string name, string lastName)
        {
                this.Name = name;
                this.LastName = lastName;
                Alias = $"{name} {lastName}";
        }

        



}