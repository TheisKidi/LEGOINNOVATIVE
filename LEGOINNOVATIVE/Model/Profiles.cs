namespace LEGOINNOVATIVE.Model
{
    public class Profiles
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

        public Profiles(string name, string adress, string email, string phone, string password)
        {
            Name = name;
            Adress = adress;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}
