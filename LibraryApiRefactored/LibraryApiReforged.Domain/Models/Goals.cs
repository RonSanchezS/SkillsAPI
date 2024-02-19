namespace LibraryApiReforged.Domain.Models
{
    public class Goal
    {
        public Guid GoalID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UserID { get; set; }

        // Navigation property
        public User? User { get; set; }
    }
}
