using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public class LoginService : ILoginService
    {

        public static bool isAdmin = false;



        private MockProfiles _mockProfiles = new MockProfiles();
        public Profiles Profiles { get; set; }
        public bool Login(string email, string password)
        {
            foreach (Profiles p in _mockProfiles.GetMockProfileList())
            {
                if (p.Email == email && p.Password == password)
                {
                    Profiles = _mockProfiles.GetMockProfileList().Find(p => p.Email == email);
                    isAdmin = Profiles.IsAdmin;
                    return true;
                }
            }
            return false;
        }
        public List<Profiles> GetProfiles()
        {
            return _mockProfiles.GetMockProfileList();
        }

        public Profiles FindProfile(string email)
        {
            foreach (Profiles p in _mockProfiles.GetMockProfileList())
            {
                if (email == p.Email)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }
    }

}
