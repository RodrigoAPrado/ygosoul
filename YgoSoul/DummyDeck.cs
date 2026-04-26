using YgoSoul.Flag;

namespace YgoSoul;

public static class DummyDeck
{
    private static List<uint> _brandedMain =
    [
        68468459, // 01 Albaz
        19304410, // 02 Tri Springans Kitt
        73819701, // 03 Albaz Branco
        73819701, // 04 Albaz branco
        62962630, // 05 Aluber
        62962630, // 06 Aluber
        62962630, // 07 Aluber
        55273560, // 08 Ecclesia
        45883110, // 09 Quem
        95515789, // 10 Cartesia
        95515789, // 11 Cartesia
        30271097, // 12 F&V
        30271097, // 13 F&V
        30271097, // 14 F&V
        29948294, // 15 High Spirits
        29948294, // 16 High Spirits
        29948294, // 17 High Spirits
        44362883, // 18 Branded Fusion
        44362883, // 19 Branded Fusion
        32731036, // 20 Bystial Lubellion
        33854624, // 21 Magna
        6637331, // 22 Druis
        60242223, // 23 Saronir
        36577931, // 24 Despian Tragedy
        25451383, // 26 Albion Preto
        19096726, // 27 Mercourier
        36637374, // 28 Branded Opening
        36637374, // 29 Branded Opening
        36637374, // 29 Branded Opening
        18973184, // 30 Branded Lost
        6763530, // 31 Branded Banishment
        17751597, // 32 Branded Retribution
        6498707, // 33 Fusion Deployment
        6498707, // 34 Fusion Deployment
        6498707, // 35 Fusion Deployment
        48130397, // 36 Superpoly
        48130397, // 37 Superpoly
        48130397, // 38 Superpoly
        81439173, // 39 Foolish Burial
        75500286, // 40 Gold Sarcophagus
    ];
    
    private static List<uint> _brandedExtra =
    [
        87746184, // 01 Albion Vermelho
        87746184, // 02 Albion Vermelho
        87746184, // 03 Albion Vermelho
        70534340, // 04 Lubellion
        44146295, // 05 Mirrorjade
        41373230, // 06 Titaniklad
        51409648, // 07 Rindbrumm
        24915933, // 08 Granguignol
        11765832, // 09 Garura
        69946549, // 10 Dragostapelia
        19652159, // 11 L & D Dragonlord
        76666602, // 12 Dogma
        72272462, // 13 Quaeritis
        78397661, // 14 Ecclesia
        53971455, // 15 Lulu
    ];

    private static List<uint> _kewlTuneMain =
    [
        16387555, // 01 Kewl Tune Cue
        16387555, // 02 Kewl Tune Cue
        16387555, // 03 Kewl Tune Cue
        16509007, // 04 Kewl Tune Mix
        16509007, // 05 Kewl Tune Mix
        16509007, // 06 Kewl Tune Mix
        89392810, // 07 Kewl Tune Reco
        89392810, // 08 Kewl Tune Reco
        89392810, // 09 Kewl Tune Reco
        43904702, // 10 Kewl Tune Clip
        43904702, // 11 Kewl Tune Clip
        43904702, // 12 Kewl Tune Clip
        78058681, // 13 Kewl Tune Synchro
        78058681, // 14 Kewl Tune Synchro
        78058681, // 15 Kewl Tune Synchro
        14442329, // 16 JJ "Kewl Tune"
        14442329, // 17 JJ "Kewl Tune"
        14442329, // 18 JJ "Kewl Tune"
        40847034, // 19 Kewl Tune Playlist
        40847034, // 20 Kewl Tune Playlist
        77202120, // 21 Assault Synchron
        21142671, // 22 Red Nova
        38814750, // 23 Gamma
        38814750, // 24 Gamma
        49036338, // 25 Driver
        97268402, // 26 Veiler
        97268402, // 27 Veiler
        97268402, // 28 Veiler
        59438930, // 29 Ghost Ogre
        59438930, // 30 Ghost Ogre
        59438930, // 31 Ghost Ogre
        52038441, // 32 Mourner
        52038441, // 33 Mourner
        52038441, // 34 Mourner
        99243014, // 35 Overtake
        99243014, // 36 Overtake
        99243014, // 37 Overtake
        97474300, // 38 Duelist Genesis
        97474300, // 39 Duelist Genesis
        18158393, // 40 Mannadium
    ];
    
    private static List<uint> _kewlTuneExtra =
    [
        42781164, // 01 Track Maker
        42781164, // 02 Track Maker
        42781164, // 03 Track Maker
        15665977, // 04 RS
        15665977, // 05 RS
        15665977, // 06 RS
        88170262, // 07 Remix
        88170262, // 08 Remix
        88170262, // 09 Remix
        41069676, // 10 Loudness War
        41069676, // 11 Loudness War
        41069676, // 12 Loudness War
        4891376, // 13 Zalen
        4891376, // 14 Zalen
        821049, // 15 Visas Amritara
    ];

    private static List<uint> _utopiaMain = 
    [
        62880279, // 01 W. Dodododo
        62880279, // 02 W. Dodododo
        62880279, // 03 W. Dodododo
        9491461, // 04 Gagaga Ganbara
        9491461, // 05 Gagaga Ganbara
        9491461, // 06 Gagaga Ganbara
        62006866, // 07 Zubababa Knight
        62006866, // 08 Zubababa Knight
        62006866, // 09 Zubababa Knight
        35886170, // 10 Gogogo Goblin
        35886170, // 11 Gogogo Goblin
        35886170, // 12 Gogogo Goblin
        55088578, // 13 Onomatokage
        55088578, // 14 Onomatokage
        55088578, // 15 Onomatokage
        59724555, // 16 Dodododwarf
        59724555, // 17 Dodododwarf
        8512558, // 18 Utopic Onomat
        8512558, // 19 Utopic Onomat
        23720856, // 20 Zubababancho
        19667590, // 21 Gogogo Gigas
        4647954, // 22 ZS Sage
        6595475, // 23 Onomatopaira
        6595475, // 24 Onomatopaira
        6595475, // 25 Onomatopaira
        85119159, // 26 Onomatopickup
        85119159, // 27 Onomatopickup
        85119159, // 28 Onomatopickup
        11705261, // 29 Xyz Tactics
        67517351, // 30 Rank-up
        96004535, // 31 Barrier
        59438930, // 32 Ghost Ogre
        59438930, // 33 Ghost Ogre
        14558127, // 34 Ash Blossom
        14558127, // 35 Ash Blossom
        94145021, // 36 Droll & Lock Bird
        94145021, // 37 Droll & Lock Bird
        32807846, // 38 ROTA
        24224830, // 39 Called by
        65681983, // 40 Crossout Designator
    ];

    private static List<uint> _utopiaExtra =
    [
        88917691, // 01 Gagagaga Girl
        88917691, // 02 Gagagaga Girl
        86331741, // 03 Gagagaga Magician
        66011101, // 04 Dugares
        16643334, // 05 Starliege
        8165596, // 06 Number 90
        26973555, // 07 F0 Draco
        65305468, // 08 F0 
        41522092, // 09 F0 Zexal
        45852939, // 10 Eclipse Twins
        86532744, // 11 Utopia Prime
        31123642, // 12 ZS Utopic Sage
        84013237, // 13 Utopia
        95134948, // 14 Dragonar Utopia
        63767246, // 15 38 Habinger
    ];
    
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
        89631139,
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
    
    
    
    public static List<OCG_NewCardInfo> CreateDeck(byte team, int deck)
    {
        var m = deck switch
        {
            0 => _brandedMain,
            1 => _utopiaMain,
            _ => _kewlTuneMain
        };
        
        var e = deck switch
        {
            0 => _brandedExtra,
            1 => _utopiaExtra,
            _ => _kewlTuneExtra
        };
        
        var list = m.Select(card => CreateCard(team, card)).ToList();
        
        var rng = new Random();

        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = rng.Next(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }

        foreach (var card in e)
        {
            list.Add(CreateCard(team, card));
        }

        return list;
    }

    private static OCG_NewCardInfo CreateCard(byte team, uint cardNumber)
    {
        return new OCG_NewCardInfo()
        {
            team = team,
            duelist = 0,
            code = cardNumber,
            con = team,
            loc = (uint) CardLocation.Deck,
            pos = (uint) CardPosition.FaceDown
        };
    }
}