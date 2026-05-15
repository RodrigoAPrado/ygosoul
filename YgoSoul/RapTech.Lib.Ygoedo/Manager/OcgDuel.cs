using System.Runtime.InteropServices;
using YgoSoul.RapTech.Lib.Ygoedo.Api;
using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface.Enum;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Manager;

public class OcgDuel : IOcgDuel
{
    public OcgDuelState State => _state;
    
    public IReadOnlyList<IDuelMessage> Messages => _messages.Select(IDuelMessage (x) => x).ToList().AsReadOnly();
    public int CurrentMessageIndex { get; private set; }
    public int RetryCount { get; private set; }
    private IntPtr _pDuel;
    private OCG_DuelOptions _options;
    private OcgDuelState _state = OcgDuelState.NotStarted;
    private readonly List<IOcgMessage> _messages;

    private readonly Func<OcgResponse, bool> _processMessage;
    
    public OcgDuel(Func<OcgResponse, bool> processMessage)
    {
        _processMessage = processMessage;
        _messages = [];
        CurrentMessageIndex = 0;
        RetryCount = 0;
    }
    
    public Tuple<int, int> GetOcgVersion()
    {
        OCG_Api.Info.OCG_GetVersion(out var major, out var minor);
        return new Tuple<int, int>(major, minor);
    }

    public bool SetupDuelOptions(
        DuelMode duelMode, 
        uint player1Lp, 
        uint player1Hand, 
        uint player1Draw, 
        uint player2Lp, 
        uint player2Hand, 
        uint player2Draw
        )
    {
        if (_state != OcgDuelState.NotStarted)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }
        _options = new OCG_DuelOptions
        {
            seed0 = 0x12345,
            flags = (ulong)(duelMode.FromDuelMode()),
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
        _state = OcgDuelState.DuelOptionsSet;
        return true;
    }

    public bool CreateDuel()
    {
        if (_state != OcgDuelState.DuelOptionsSet)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }

        if (OCG_Api.Setup.OCG_CreateDuel(out var pDuel, ref _options) != 0)
        {
            throw new Exception("Failed to create duel.");
        }
        
        _pDuel = pDuel;
        LoadBaseScripts();
        _state = OcgDuelState.DuelCreated;
        return true;
    }

    public bool SetDecks(
        IReadOnlyList<ICardData> mainDeck0, 
        IReadOnlyList<ICardData> extraDeck0, 
        IReadOnlyList<ICardData> mainDeck1, 
        IReadOnlyList<ICardData> extraDeck1
        )
    {
        if (_state != OcgDuelState.DuelCreated)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }
        
        SetDeck(mainDeck0, false, 0);
        SetDeck(extraDeck0, true, 0);
        SetDeck(mainDeck1, false, 1);
        SetDeck(extraDeck1, true, 1);
        _state = OcgDuelState.DecksSet;
        return true;
    }

    public bool StartDuel()
    {
        if (_state != OcgDuelState.DecksSet)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }
        OCG_Api.Setup.OCG_StartDuel(_pDuel);
        _state = OcgDuelState.DuelReady;
        return true;
    }

    public bool ProceedDuel()
    {
        if (_state != OcgDuelState.DuelReady)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }

        var result = (OCG_DuelStatus)OCG_Api.Run.OCG_DuelProcess(_pDuel);

        _state = result switch
        {
            OCG_DuelStatus.OcgDuelStatusEnd => OcgDuelState.DuelFinished,
            OCG_DuelStatus.OcgDuelStatusAwating => OcgDuelState.WaitingInput,
            OCG_DuelStatus.OcgDuelStatusContinue => OcgDuelState.DuelReady,
            _ => throw new ArgumentOutOfRangeException()
        };

        var messagePtr = OCG_Api.Run.OCG_DuelGetMessage(_pDuel, out var length);
        
        return _processMessage.Invoke(new OcgResponse(messagePtr, length));
    }

    public bool SetResponse(List<int> playerInput)
    {
        if (_state != OcgDuelState.WaitingInput)
        {
            Console.WriteLine($"Current state is: {_state}.");
            return false;
        }

        if (_messages.Count == 0)
            return false;

        var currentMessage = _messages[CurrentMessageIndex];
        
        if (currentMessage.Input is InputType.None or InputType.Unknown or InputType.Win)
        {
            return false;
        }

        var response = currentMessage.GetResponse(playerInput);
        
        OCG_Api.Run.OCG_DuelSetResponse(_pDuel, response, (uint) response.Length);
        
        _state = OcgDuelState.DuelReady;
        return true;
    }

    public bool NextMessage()
    {
        if (_messages.Count == 0)
            return false;

        if (_messages[CurrentMessageIndex].Input is not InputType.None)
            return false;

        if (CurrentMessageIndex + 1 >= _messages.Count)
            return false;
        
        CurrentMessageIndex++;
        
        
        return true;
    }

    public bool SetNewMessages(List<IOcgMessage> messages)
    {
        if (messages is [{ Input: InputType.Retry }])
        {
            RetryCount++;
            return false;
        }
        
        _messages.Clear();
        _messages.AddRange(messages);
        CurrentMessageIndex = 0;
        RetryCount = 0;
        return true;
    }
    
    private void SetDeck(IReadOnlyList<ICardData> deck, bool isExtra, byte team)
    {
        foreach (var card in deck)
        {
            var ocgNewCardInfo = GetNewCardInfo(card, isExtra, team);
            OCG_Api.Setup.OCG_DuelNewCard(_pDuel, ref ocgNewCardInfo);
        }
    }

    private OCG_NewCardInfo GetNewCardInfo(ICardData cardData, bool isExtra, byte team)
    {
        return new OCG_NewCardInfo()
        {
            team = team,
            duelist = 0,
            code = cardData.Code,
            con = team,
            loc = (uint) (isExtra ? CardLocation.Extra : CardLocation.Deck),
            pos = (uint) CardPosition.FaceDown
        };
    }
    
    private void LoadBaseScripts()
    {
        OcgDuelBridge.LoadScript(_pDuel, "constant.lua");
        OcgDuelBridge.LoadScript(_pDuel, "utility.lua");
        OcgDuelBridge.LoadScript(_pDuel, "rankup_functions.lua");
    }
}