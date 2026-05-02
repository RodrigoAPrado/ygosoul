using System.Runtime.InteropServices;
using YgoSoul.RapTech.Lib.Ygoedo.Api;

namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public class OcgDuel
{
    private IntPtr _pDuel;
    private OCG_DuelOptions _options;
    
    public Tuple<int, int> GetOcgVersion()
    {
        OCG_Api.Info.OCG_GetVersion(out var major, out var minor);
        return new Tuple<int, int>(major, minor);
    }

    public void SetupDuelOptions(
        DuelFlags duelFlags, 
        uint player1Lp, 
        uint player1Hand, 
        uint player1Draw, 
        uint player2Lp, 
        uint player2Hand, 
        uint player2Draw
        )
    {
        _options = new OCG_DuelOptions
        {
            seed0 = 0x12345,
            flags = (ulong)duelFlags,
            team1 = new OCG_Player
            {
                startingLP = player1Lp, 
                startingDrawCount = player1Hand, 
                drawCountPerTurn = player1Draw
            },
            team2 = new OCG_Player
            {
                startingLP = player2Lp, 
                startingDrawCount = player2Hand, 
                drawCountPerTurn = player2Draw
            },
            cardReader = Marshal.GetFunctionPointerForDelegate(OcgDuelBridge.CardReader),
            scriptReader = Marshal.GetFunctionPointerForDelegate(OcgDuelBridge.ScriptReader),
            logHandler = Marshal.GetFunctionPointerForDelegate(OcgDuelBridge.LogHandler),
            cardReaderDone = Marshal.GetFunctionPointerForDelegate(OcgDuelBridge.ReaderDone),
            enableUnsafeLibraries = 0
        };
    }

    public bool CreateDuel()
    {
        if (_options is { seed0: 0, seed1: 0, seed2: 0, seed3: 0 })
        {
            return false;
        }

        if (OCG_Api.Setup.OCG_CreateDuel(out var pDuel, ref _options) != 0) 
            return false;
        
        _pDuel = pDuel;
        LoadBaseScripts();
        return true;

    }

    public bool SetDecks()
    {
        
    }
    
    private void LoadBaseScripts()
    {
        OcgDuelBridge.LoadScript(_pDuel, "constant.lua");
        OcgDuelBridge.LoadScript(_pDuel, "utility.lua");
        OcgDuelBridge.LoadScript(_pDuel, "rankup_functions.lua");
    }
}