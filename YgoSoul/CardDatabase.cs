using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;

namespace YgoSoul;

public class CardDatabase
{
    private static string _connString;

    public static void Initialize(string dbPath)
    {
        _connString = $"Data Source={dbPath}";
    }

    public static OCG_CardData GetCardData(uint code)
    {
        using var connection = new SqliteConnection(_connString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM datas JOIN texts ON datas.id = texts.id WHERE datas.id = $id";
        command.Parameters.AddWithValue("$id", code);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            
            ulong setCodeValue = (ulong)reader.GetInt64(3);

            IntPtr setcodePtr = Marshal.AllocHGlobal(sizeof(ulong));
            Marshal.WriteInt64(setcodePtr, (long)setCodeValue);
            var ocgCardData = new OCG_CardData
            {
                code = (uint)reader.GetInt32(0),
                alias = (uint)reader.GetInt32(2),
                setcode = setcodePtr,
                type = (uint)reader.GetInt32(4),
                attack = reader.GetInt32(5),  // Coluna 'atk'
                defense = reader.GetInt32(6), // Coluna 'def'
                level = (uint)reader.GetInt32(7),
                race = (ulong)reader.GetInt64(8),
                attribute = (uint)reader.GetInt32(9),
                lscale = 0,
                rscale = 0,
                link_marker = 0
            };
            
            CardLibrary.AddCard(ocgCardData, reader.GetString(12), reader.GetString(13));
            connection.Close();
            return ocgCardData;
        }
        return new OCG_CardData { code = code }; 
    }
}