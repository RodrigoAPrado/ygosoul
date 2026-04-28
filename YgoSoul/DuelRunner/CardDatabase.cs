using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using YgoSoul.Flag;

namespace YgoSoul.DuelRunner;

public class CardDatabase
{
    private static string _connString;

    public static void Initialize(string dbPath)
    {
        _connString = $"Data Source={dbPath}";
    }

    public static void LoadCards()
    {
        using var connection = new SqliteConnection(_connString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM datas JOIN texts ON datas.id = texts.id";
        using var reader = command.ExecuteReader();
        var cardsLoaded = 0;
        while (reader.Read())
        {
            ulong setCodeValue = (ulong)reader.GetInt64(3);

            IntPtr setcodePtr = Marshal.AllocHGlobal(sizeof(ulong));
            Marshal.WriteInt64(setcodePtr, (long)setCodeValue);
            var rawLevel = (uint)reader.GetInt32(7);
            var type = (uint)reader.GetInt32(4);
            var isLink = (type & (uint)CardType.Link) != 0;
            var rawDefense = (uint)reader.GetInt32(6);
            var ocgCardData = new OCG_CardData
            {
                code = (uint)reader.GetInt32(0),
                alias = (uint)reader.GetInt32(2),
                setcode = setcodePtr,
                type = type,
                attack = reader.GetInt32(5),
                defense = isLink ? 0 : (int)rawDefense,
                level = rawLevel & 0xFF,
                race = (ulong)reader.GetInt64(8),
                attribute = (uint)reader.GetInt32(9),
                lscale = (rawLevel >> 24) & 0xFF,
                rscale = (rawLevel >> 16) & 0xFF,
                link_marker = isLink ? rawDefense : 0
            };

            var strings = new List<string>();
            
            for (int i = 1; i <= 16; i++)
            {
                strings.Add(reader.GetString(13+i));
            }
            
            CardLibrary.AddCard(ocgCardData, reader.GetString(12), reader.GetString(13), strings, (ulong)reader.GetInt64(10));
            cardsLoaded++;
        }
        Console.WriteLine($"{cardsLoaded} cards loaded...");
        connection.Close();
    }

    public static OCG_CardData GetCardData(uint code)
    {
        var card = CardLibrary.GetCard(code);
        return card.Data;
    }
}