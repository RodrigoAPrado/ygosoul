using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Struct;

namespace YgoSoul
{
    public static class OldDummyDeck
    {
        private static readonly List<uint> _brandedMain =
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
            75500286 // 40 Gold Sarcophagus
        ];

        private static readonly List<uint> _brandedExtra =
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
            53971455 // 15 Lulu
        ];

        private static readonly List<uint> _kewlTuneMain =
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
            18158393 // 40 Mannadium
        ];

        private static readonly List<uint> _kewlTuneExtra =
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
            821049 // 15 Visas Amritara
        ];

        private static readonly List<uint> _utopiaMain =
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
            65681983 // 40 Crossout Designator
        ];

        private static readonly List<uint> _utopiaExtra =
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
            63767246 // 15 38 Habinger
        ];

        private static readonly List<uint> _salaMain =
        [
            26889158, // 01 Gazelle
            26889158, // 02 Gazelle
            11962031, // 03 Sala of Fire
            11962031, // 04 Sala of Fire
            52277807, // 05 Spinny
            52277807, // 06 Spinny
            52277807, // 07 Spinny
            56003780, // 08 Jack Jaguar
            57357130, // 09 Weasel
            20618081, // 10 Falco
            94620082, // 11 Foxy
            67225377, // 12 Meer
            52155219, // 13 Circle
            52155219, // 14 Circle
            52155219, // 15 Circle
            1295111, // 16 Sanctuary
            14934922, // 17 Rage
            51339637, // 18 Roar
            74652966, // 19 Code of Soul
            80794697, // 20 Flame Buferlo
            57160136, // 21 Cynet Mining
            57160136, // 22 Cynet Mining
            59438930, // 23 Ghost Ogre
            59438930, // 24 Ghost Ogre
            59438930, // 25 Ghost Ogre
            14558127, // 26 Ash
            14558127, // 27 Ash
            14558127, // 28 Ash
            97268402, // 29 Veiler
            97268402, // 30 Veiler
            97268402, // 31 Veiler
            24224830, // 32 Called by
            10045474, // 33 Imperm
            10045474, // 34 Imperm
            10045474, // 35 Imperm
            26889158, // 36 Gazelle
            11962031, // 37 Sala of Fire
            57160136, // 38 Cynet Mining
            80794697, // 39 Flame Buferlo
            64178424 // 40 Will
        ];

        private static readonly List<uint> _salaExtra =
        [
            14812471, // 01 Balelynx
            14812471, // 02 Balelynx
            87871125, // 03 Sunlight Wolf
            87871125, // 04 Sunlight Wolf
            57134592, // 05 Phoenix
            57134592, // 06 Phoenix
            87327776, // 07 Stallion
            24842059, // 08 Linguriboh
            88093706, // 09 Update Jammer
            48815792, // 10 Hiita
            2772337, // 11 Promethean Princess
            46947713, // 12 Transcode Talker
            61245672, // 13 Heatsoul
            86066372, // 14 Accesscode
            59859086 // 15 Splash Mage
        ];

        private static readonly List<uint> _cards =
        [
            74677422,
            5318639,
            5318639,
            5318639,
            00549481,
            00549481,
            22702055,
            01184620,
            01184620,
            01784619,
            01784619,
            56465981,
            02118022,
            02118022,
            02118022,
            6728559,
            02483611,
            02483611,
            25131968,
            87430998,
            25131968,
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
            43096270,
            43096270,
            43096270,
            32909498,
            32909498,
            32909498,
            69540484
        ];

        private static readonly List<uint> _extra =
        [
            73542331,
            1769875,
            90140980,
            94798725
        ];

        //Kashtira Birth - 69540484
        //Kashtira Sangrira - 73542331
        //Kasthira Fenrir - 32909498
        //Forest - 87430998
        //Umi - 22702055
        //Set rotation - 73468603
        //Aria the melodious diva - 40502912
        //Ma'at - 18631392
        //Gunkan Suship Catch-of-the-Day - 83008724
        //Primite Roar - 92501449
        //Change of Heart - 4031928
        //Ojama Yellow - 42941100
        //Ojama Black - 79335209
        //Ojama Green - 12482652
        //Polymerization - 24094653
        //Ojama King - 90140980
        //Big-Winged Berfomet - 55461744
        //Gazelle the King of Mythical Claws - 23076639
        //Chimera the King of Phantom Beasts - 1769875
        //Chimera Fusion - 63136489
        //Alexandrite Dragon - 43096270
        //Gold Sarcophagus - 75500286
        //Archnemesis Protos - 6728559
        //Tenyi Vishuda - 23431858
        //Tenyi Ashuna - 87052196
        //Tenyi Adhara - 98159737
        //Tenyi Suruya - 52854600
        //Shaman of the Tenyi - 78917791
        //Monk of the Tenyi - 32519092
        //Swordsoul of Mo Ye - 20001443
        //Swordsoul Emergency - 56465981
        //Swordsoul Grandmaster - Chixiao - 69248256
        //Swordsoul of Taia - 56495147
        //Swordsoul Longyuan - 93490856
        //Swordsoul Supreme Soverign - 96633955
        //Swordsoul Sinister Soverign - 47710198

        //Magical Hats - -                                    81210420
        //Mystical Space Typhoon - -                           5318639
        //Evenly Matched - Remove Cards -                     15693423
        //Reasoning - Announce Number -                       58577036
        //Pot of Duality - Decktop -                          98645731
        //Pot of Extravagance - Y/N -                         49238328
        //Gen - Invocar no campo do cara -                    52126602
        //Ken - Invocar no campo do cara -                    25131968
        //Number 67 - SelectDisfield -                        35772782
        //Mind Crush - Confirm Cards -                        15800838
        //Convulsion of Nature - ReverseDeck -                62966332
        //Exchange of the Spirit - SwapGraveDeck -            17484499
        //Ookazi - Damage -                                   19523799
        //Dian Keto the Cure Master - recover -               84257639
        //Time Wizard - toss coin -                           71625222
        //Snipe Hunter - TossDice -                           84290642
        //Gamble - Announce Number -                          37313786
        //DNA Surgery - AnnounceRace -                        74701381
        //DNA Transplant - AnounceAttrib -                    56769674
        //Psi-Blocker/Crossout Designator - AnnounceCard -    29417188 / 65681983
        //Pot of Desires - RemoveCards -                      35261759
        //Victory Dragon - MatchKill -                        44910027
        //Red-eyes fusion - 6172122
        //Dark Magician - 46986414
        //Red-eyes black dragon - 74677422
        //Red-eyes dark Dragoon - 37818794
        //Card of Demise - 59750328
        //Foolish Burial - 81439173
        //Painful Choice - 74191942
        //Graceful Charity - 79571449
        //Tenyi Vishuda - 23431858
        //Tenyi Ashuna - 87052196
        //Tenyi Adhara - 98159737
        //Tenyi Suruya - 52854600
        //Shaman of the Tenyi - 78917791
        //Monk of the Tenyi - 32519092
        //Swordsoul of Mo Ye - 20001443
        //Swordsoul Emergency - 56465981
        //Swordsoul Grandmaster - Chixiao - 69248256
        //Swordsoul of Taia - 56495147
        //Swordsoul Longyuan - 93490856
        //Swordsoul Supreme Soverign - 96633955
        //Swordsoul Sinister Soverign - 47710198

        /*
         *
         *Raw: Hint 02-04-00-00-00-80-13-F5-2E-00-00
    Hint message. Content: 02-04-00-00-00-80-13-F5-2E-00-00

    Raw: Hint 02-03-01-01-00-60-44-C1-46-00-00
    System.Collections.Generic.KeyNotFoundException: The given key '1147142145' was not present in the dictionary.
       at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
       at YgoSoul.DuelRunner.CardLibrary.GetCard(UInt32 code) in C:\Users\rodri\RiderProjects\YgoSoul\YgoSoul\DuelRunner\CardLibrary.cs:line 21
       at YgoSoul.Parser.HintParser.GetHintText(UInt64 hint) in C:\Users\rodri\RiderProjects\YgoSoul\YgoSoul\Parser\HintParser.cs:line 34
       at YgoSoul.Parser.HintParser.DoParse(Byte[] buffer) in C:\Users\rodri\RiderProjects\YgoSoul\YgoSoul\Parser\HintParser.cs:line 21
       at YgoSoul.Parser.Abstr.BaseParser.Parse(Byte[] buffer) in C:\Users\rodri\RiderProjects\YgoSoul\YgoSoul\Parser\Abstr\BaseParser.cs:line 15
    Hint message. Content: 02-03-01-01-00-60-44-C1-46-00-00
    2

         *
         */


        public static List<OCG_NewCardInfo> CreateDeck(byte team, bool randomize)
        {
            var list = _cards.Select(card => CreateCard(team, card)).ToList();

            if (randomize)
            {
                var rng = new Random();

                for (var i = list.Count - 1; i > 0; i--)
                {
                    var j = rng.Next(0, i + 1);
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }

            foreach (var card in _extra) list.Add(CreateCard(team, card));

            return list;
        }

        public static List<OCG_NewCardInfo> CreateDeck(byte team, int deck, bool randomize)
        {
            if (deck is > 3 or < 0)
                return CreateDeck(team, randomize);

            var m = deck switch
            {
                0 => _brandedMain,
                1 => _utopiaMain,
                2 => _kewlTuneMain,
                3 => _salaMain
            };

            var e = deck switch
            {
                0 => _brandedExtra,
                1 => _utopiaExtra,
                2 => _kewlTuneExtra,
                3 => _salaExtra
            };

            var list = m.Select(card => CreateCard(team, card)).ToList();

            if (randomize)
            {
                var rng = new Random();

                for (var i = list.Count - 1; i > 0; i--)
                {
                    var j = rng.Next(0, i + 1);
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }

            foreach (var card in e) list.Add(CreateCard(team, card));

            return list;
        }

        private static OCG_NewCardInfo CreateCard(byte team, uint cardNumber)
        {
            return new OCG_NewCardInfo
            {
                team = team,
                duelist = 0,
                code = cardNumber,
                con = team,
                loc = (uint)OCG_CardLocation.Deck,
                pos = (uint)OCG_CardPosition.FaceDown
            };
        }
    }
}