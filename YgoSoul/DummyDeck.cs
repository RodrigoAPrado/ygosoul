namespace YgoSoul;

public static class DummyDeck
{
    /*
    private static List<uint> _cards =
    [
        00032864,
        00032864,
        00032864,
        00549481,
        00549481,
        00549481,
        01184620,
        01184620,
        01184620,
        01784619,
        01784619,
        01784619,
        02118022,
        02118022,
        02118022,
        02483611,
        02483611,
        02483611,
        06740720,
        06740720,
        06740720,
        60862676,
        60862676,
        60862676,
        89631139, ---??? 89631139
        89631139,
        89631139,
        96851799,
        96851799,
        96851799,
        97590747,
        97590747,
        97590747,
        46986414,
        46986414,
        46986414,
        80141480,
        80141480,
        80141480,
        80770678
    ];
    */
    
    public static List<OCG_NewCardInfo> CreateDeck(byte team)
    {
        throw new InvalidOperationException();
        //return _cards.Select(card => CreateCard(team, card)).ToList();
    }

    private static OCG_NewCardInfo CreateCard(byte team, uint cardNumber)
    {
        return new OCG_NewCardInfo()
        {
            team = team,
            duelist = team,
            code = cardNumber,
            con = team,
            loc = 0x01,
            pos = 0x8
        };
    }
}



/*


[StructLayout(LayoutKind.Sequential)]
public struct OCG_NewCardInfo
{
    public byte team;    /* 0 ou 1 * /
    public byte duelist; /* Índice do dono original * /
    public uint code;    /* ID da carta (ex: 24096301) * /
    public byte con;     /* Controlador atual (0 ou 1) * /
    public uint loc;     /* LOCATION (Deck, Hand, etc) * /
    public uint seq;     /* Sequência/Slot no campo * /
    public uint pos;     /* POSITION (Face-up, Face-down, etc) * /
}

*/