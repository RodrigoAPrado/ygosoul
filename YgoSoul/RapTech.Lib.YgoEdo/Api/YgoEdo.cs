using YgoSoul.RapTech.Lib.YgoEdo.Factory;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Manager.Interface;

namespace YgoSoul.RapTech.Lib.YgoEdo.Api;

public static class YgoEdo
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
        OcgBridge.Init(_dataPath);
        CardDatabase.Init(_dataPath + "cards.cdb");
        CardDatabase.LoadCards();
        CardLibrary.CreateInstance();
        _manager = new DuelManager(CardLibrary.Instance, MessageParserFactory.CreateParsers());
        _initialized = true;
        return _manager;
    }
}