namespace LEGOINNOVATIVE.Model
{
    public class CustomerProfile : Profiles
    {

        public CustomerProfile(string name, string adress, string email, string phone, string password)
            : base(name, adress, email, phone, password)
        {
            IsAdmin = false;
        }
    }
}