using UnityEngine;
using System.IO;
using SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class DatabaseManager : MonoBehaviour
{
    public static SQLiteConnection db;

    void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "users.db");
        db = new SQLiteConnection(path);
        db.CreateTable<User>();

        var usersToAdd = new[]
        {
          
            new User { FullName = "Abeer Smith", PassHash = Hash("test123"), LastReading = 900, LastDiff = 0, Points = 0 },
            new User { FullName = "Samira Cole", PassHash = Hash("sunflower"), LastReading = 1200, LastDiff = 100, Points = 0 },
            new User { FullName = "Ray Jackson", PassHash = Hash("matrix99"), LastReading = 800, LastDiff = 0, Points = 0 },
            new User { FullName = "Nyla Reece", PassHash = Hash("unicorn7"), LastReading = 1100, LastDiff = 50, Points = 0 },
            new User { FullName = "Jasper Walker", PassHash = Hash("piano88"), LastReading = 950, LastDiff = 25, Points = 0 },
            new User { FullName = "Lena Orbit", PassHash = Hash("moonbeam12"), LastReading = 1020, LastDiff = 40, Points = 0 },
            new User { FullName = "Theo Current", PassHash = Hash("hydroflow"), LastReading = 870, LastDiff = 20, Points = 0 },
            new User { FullName = "Ivy Ripple", PassHash = Hash("waterfall3"), LastReading = 950, LastDiff = 10, Points = 0 },
            new User { FullName = "Max Geyser", PassHash = Hash("pressure77"), LastReading = 1130, LastDiff = 80, Points = 0 },
            new User { FullName = "Nova Lagoon", PassHash = Hash("oceanic1"), LastReading = 990, LastDiff = 15, Points = 0 },
            new User { FullName = "Arlo Stream", PassHash = Hash("depth44"), LastReading = 1080, LastDiff = 20, Points = 0 },
            new User { FullName = "Zara Delta", PassHash = Hash("splashy6"), LastReading = 970, LastDiff = 5, Points = 0 },
            new User { FullName = "Kai Drift", PassHash = Hash("driftwood"), LastReading = 890, LastDiff = 0, Points = 0 },
            new User { FullName = "Mira Cascade", PassHash = Hash("cascade17"), LastReading = 1250, LastDiff = 120, Points = 0 },
            new User { FullName = "Sage Blue", PassHash = Hash("blueleaf"), LastReading = 1050, LastDiff = 30, Points = 0 },
            new User { FullName = "Tariq Aqua", PassHash = Hash("freshdrop"), LastReading = 980, LastDiff = 5, Points = 0 },
            new User { FullName = "Elle Streamline", PassHash = Hash("stream88"), LastReading = 910, LastDiff = 25, Points = 0 },
            new User { FullName = "Leo Marsh", PassHash = Hash("marshland"), LastReading = 1000, LastDiff = 0, Points = 0 },
            new User { FullName = "Ruby Brook", PassHash = Hash("brookside"), LastReading = 950, LastDiff = 15, Points = 0 },
            new User { FullName = "Finn Tide", PassHash = Hash("tidepool"), LastReading = 960, LastDiff = -10, Points = 0 },
            new User { FullName = "Bea Mist", PassHash = Hash("misty101"), LastReading = 920, LastDiff = 10, Points = 0 },
            new User { FullName = "Ravi Cloud", PassHash = Hash("cloudy33"), LastReading = 940, LastDiff = 20, Points = 0 },
            new User { FullName = "Skye Rain", PassHash = Hash("raindrop"), LastReading = 1100, LastDiff = 45, Points = 0 },
            new User { FullName = "Nico Surf", PassHash = Hash("surferx"), LastReading = 1060, LastDiff = 5, Points = 0 },
            new User { FullName = "Coral Bay", PassHash = Hash("coralreef"), LastReading = 1090, LastDiff = 60, Points = 0 },
            new User { FullName = "Dax River", PassHash = Hash("riverwalk"), LastReading = 970, LastDiff = 0, Points = 0 },
            new User { FullName = "Hazel Spring", PassHash = Hash("springy7"), LastReading = 890, LastDiff = 15, Points = 0 },
            new User { FullName = "Vera Stream", PassHash = Hash("verastream"), LastReading = 1010, LastDiff = 35, Points = 0 },
            new User { FullName = "Noor Oasis", PassHash = Hash("desertdew"), LastReading = 850, LastDiff = 5, Points = 0 },
            new User { FullName = "Emil Tide", PassHash = Hash("flowing22"), LastReading = 940, LastDiff = 10, Points = 0 },
            new User { FullName = "Milan Wave", PassHash = Hash("waveform"), LastReading = 1120, LastDiff = 55, Points = 0 },
            new User { FullName = "Kira Lake", PassHash = Hash("laketown"), LastReading = 930, LastDiff = -5, Points = 0 },
            new User { FullName = "Harper Flow", PassHash = Hash("go2flow"), LastReading = 1000, LastDiff = 20, Points = 0 },
            new User { FullName = "Amir Delta", PassHash = Hash("delta99"), LastReading = 980, LastDiff = 0, Points = 0 },
            new User { FullName = "Isla Pebble", PassHash = Hash("pebble9"), LastReading = 960, LastDiff = 15, Points = 0 },
            new User { FullName = "Jude Surf", PassHash = Hash("surf88"), LastReading = 970, LastDiff = 10, Points = 0 },
            new User { FullName = "Ayla Splash", PassHash = Hash("splash22"), LastReading = 990, LastDiff = 30, Points = 0 },
            new User { FullName = "Rowan Mist", PassHash = Hash("mistwave"), LastReading = 940, LastDiff = -25, Points = 0 },
            new User { FullName = "Celeste Moon", PassHash = Hash("lunaflow"), LastReading = 960, LastDiff = 5, Points = 0 },
            new User { FullName = "Zion Brook", PassHash = Hash("brooklane"), LastReading = 980, LastDiff = 10, Points = 0 }


        };

        Debug.Log("DB Path: " + Application.persistentDataPath);


        foreach (var user in usersToAdd)
        {
            var existing = db.Table<User>().FirstOrDefault(u => u.FullName == user.FullName);
            if (existing == null)
            {
                db.Insert(user);
            }
        }
    }

    string Hash(string input)
    {
        using var sha = SHA256.Create();
        return System.BitConverter.ToString(
            sha.ComputeHash(Encoding.UTF8.GetBytes(input))
        ).Replace("-", "").ToLower();
    }
    
}