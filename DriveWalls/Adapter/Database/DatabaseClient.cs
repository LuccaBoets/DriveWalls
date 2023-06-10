using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Database
{
    public static class DatabaseClient
    {
        public static FirebaseClient GetClient()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "kFvFqu5XcTLc9fyVDIVN3zbMVsHdTYMUg7U7wd7T",
                BasePath = "https://drivewalls-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            return new FirebaseClient(config);
        }
    }
}
