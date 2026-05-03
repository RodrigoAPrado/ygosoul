using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

namespace YgoSoul.RapTech.Lib.Ygoedo.Application;

public static class OcgLib
{
    private static IDuelManager _manager;
    private static ICardLibrary _library;
    private static string _dataPath;
    private static bool _initialized;
    
    public static void Init(string dataPath)
    {
        if (!_initialized)
        {
            Console.WriteLine("OcgLib Already Initialized");
            return;   
        }
        
        _dataPath = dataPath;
        OcgDuelBridge.Init(_dataPath);
        CardDatabase.Init(_dataPath + "cards.cdb");
        CardDatabase.LoadCards();
        CardLibrary.CreateInstance();
        _library = CardLibrary.Instance;
        _manager = new DuelManager();
        _initialized = true;
    }

    public static IDuelManager GetManager()
    {
        if (!_initialized)
            throw new InvalidOperationException("Not Initialized");
        return _manager;
    }

    public static ICardLibrary GetLibrary()
    {
        if (!_initialized)
            throw new InvalidOperationException("Not Initialized");
        return _library;
    }
}