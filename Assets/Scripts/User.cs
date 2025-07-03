using SQLite;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string FullName { get; set; }
    public string PassHash { get; set; }

    public int LastReading { get; set; }
    public int LastDiff { get; set; }
    
    public int Points { get; set; } 

}

