using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface.Enum;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

public interface IOcgDuel
{
    public OcgDuelState State { get; }
    IReadOnlyList<IDuelMessage> Messages { get; }
    int CurrentMessageIndex { get; }
    int RetryCount { get; }

    public Tuple<int, int> GetOcgVersion();

    public bool SetupDuelOptions(
        DuelMode duelMode,
        uint player1Lp,
        uint player1Hand,
        uint player1Draw,
        uint player2Lp,
        uint player2Hand,
        uint player2Draw
    );

    public bool CreateDuel();

    public bool SetDecks(
        IReadOnlyList<ICardData> mainDeck0,
        IReadOnlyList<ICardData> extraDeck0,
        IReadOnlyList<ICardData> mainDeck1,
        IReadOnlyList<ICardData> extraDeck1
    );

    public bool StartDuel();

    public bool ProceedDuel();
    
    bool SetResponse(List<int> playerInput);
    
    bool NextMessage();
}