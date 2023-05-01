using LEGOINNOVATIVE.Model;
using Microsoft.AspNetCore.Identity;

namespace LEGOINNOVATIVE.MockData
{
    public class MockProfiles
    {
        private static List<Profiles> ProfileList = new List<Profiles>()
            {
            new CustomerProfile("Hasse", "333", "hassethore@gmail.com", "+45 55 55 55 55", "hasse"),
            new Profiles("Karzan", "333", "22", "+45 55 55 55 55", "jksdksd"),
            new Profiles("Kidi", "333", "22", "+45 55 55 55 55", "aaaa"),
            new MasterProfile("Peter", "Petervej", "peter@gmail.com", "+45 55 55 55 55", "1234"),
            new CustomerProfile("Jacob", "Jacobsvej", "jacob@hotmail.dk", "+45 44 44 44 44", "5678")
        };

        public List<Profiles> GetMockProfileList()
        {
            return new List<Profiles>(ProfileList);
        }

        public void Add(Profiles aProfile)
        {
            ProfileList.Add(aProfile);
        }

        public Profiles FindProfile(string email)
        {
            foreach (Profiles profiles in ProfileList)
            {
                if (profiles.Email == email)
                {
                    return profiles;
                }
            }
            return null;
        }
    }
}
