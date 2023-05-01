namespace LEGOINNOVATIVE.Model
{
    public class MasterProfile : Profiles
    {
        public MasterProfile(string name, string adress, string email, string phone, string password)
            : base(name, adress, email, phone, password)
        {
            IsAdmin = true;

        }
    }
}
