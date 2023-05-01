using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public interface ILoginService
    {
        public List<Profiles> GetProfiles();
        public bool Login(string email, string password);
        public Profiles Profiles { get; set; }
        public Profiles FindProfile(string email);

    }
}
