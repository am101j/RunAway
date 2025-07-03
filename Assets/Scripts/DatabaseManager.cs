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
            new User { FullName = "Abeer", PassHash = Hash("test123"), LastReading = 900, LastDiff = 0 },
            new User { FullName = "Samira", PassHash = Hash("sunflower"), LastReading = 1200, LastDiff = 100 },
            new User { FullName = "Ray", PassHash = Hash("matrix99"), LastReading = 800, LastDiff = 0 },
            new User { FullName = "Nyla", PassHash = Hash("unicorn7"), LastReading = 1100, LastDiff = 50 },
            new User { FullName = "Jasper", PassHash = Hash("piano88"), LastReading = 950, LastDiff = 25 }
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