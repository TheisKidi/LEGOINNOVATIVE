namespace LEGOINNOVATIVE.Model
{
    public class Order
    {
        public bool Accepted { get; set; }  
        public bool Completed { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string PersonalMessage { get; set; }
        public int Id { get; set; }
        public bool Publish { get; set; }
        public string Plan { get; set; }
        public string Email { get; set; }

        public Order(string title, string description, string personalMessage, int id, bool publish, string plan, string email)
        {
            Title = title;
            Description = description;
            PersonalMessage = personalMessage;
            Id = id;
            Publish = publish;
            Plan = plan;
            Email = email;
            Accepted = false;
            Completed = false; 
        }
    }
}
