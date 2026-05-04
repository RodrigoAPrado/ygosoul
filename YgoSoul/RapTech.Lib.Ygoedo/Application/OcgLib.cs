using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Factory;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

namespace YgoSoul.RapTech.Lib.Ygoedo.Application;

public static class OcgLib
{
    private static IDuelManager _manager;
    private static string _dataPath;
    private static bool _initialized;
    
    public static IDuelManager Init(string dataPath)
    {
        if (_initialized)
        {
            return _manager;
        }
        
        _dataPath = dataPath;
        OcgDuelBridge.Init(_dataPath);
        CardDatabase.Init(_dataPath + "cards.cdb");
        CardDatabase.LoadCards();
        CardLibrary.CreateInstance();
        _manager = new DuelManager(CardLibrary.Instance, MessageParserFactory.CreateParsers());
        _initialized = true;
        return _manager;
    }
}