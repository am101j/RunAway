using UnityEngine;
using SQLite;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public static SQLiteConnection db;

    void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "users.db");
        db = new SQLiteConnection(path);
        db.CreateTable<User>();
    }
}