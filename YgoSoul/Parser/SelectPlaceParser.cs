using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectPlaceParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte(); //msg
        var player = reader.ReadByte();
        var amount = reader.ReadByte();
        var mask = reader.ReadUInt32();

        var zones = new List<Zone>();
        
        for (int i = 0; i < 32; i++)
        {
            if ((mask & (1u << i)) == 0)
            {
                zones.Add((Zone)(1u << i));
            }
        }
        
        return new SelectPlaceMessage(player, amount, zones);
    }

    public static readonly Dictionary<Zone, CardLocation> ZoneLocation = new()
    {
        { Zone.Monster0, CardLocation.MonsterZone },
        { Zone.Monster1, CardLocation.MonsterZone },
        { Zone.Monster2, CardLocation.MonsterZone },
        { Zone.Monster3, CardLocation.MonsterZone },
        { Zone.Monster4, CardLocation.MonsterZone }
    };

    public static readonly Dictionary<Zone, uint> ZoneIndex = new()
    {
        { Zone.Monster0, 0 },
        { Zone.Monster1, 1 },
        { Zone.Monster2, 2 },
        { Zone.Monster3, 3 },
        { Zone.Monster4, 4 }
    };
    
    public enum Zone : uint
    {
        Monster0 = 0x1,
        Monster1 = 0x2,
        Monster2 = 0x4,
        Monster3 = 0x8,
        Monster4 = 0x10,
        Unknown0 = 0x20,
        Unknown1 = 0x40,
        Unknown2 = 0x80,
        Unknown3 = 0x100,
        Unknown4 = 0x200,
        Unknown5 = 0x400,
        Unknown6 = 0x800,
        Unknown7 = 0x1000,
        Unknown8 = 0x2000,
        Unknown9 = 0x4000,
        Unknown10 = 0x8000,
        Unknown11 = 0x10000,
        Unknown12 = 0x20000,
        Unknown13 = 0x40000,
        Unknown14 = 0x80000,
        Unknown15 = 0x100000,
        Unknown16 = 0x200000,
        Unknown17 = 0x400000,
        Unknown18 = 0x800000,
        Unknown19 = 0x1000000,
        Unknown20 = 0x2000000,
        Unknown21 = 0x4000000,
        Unknown22 = 0x8000000,
        Unknown23 = 0x10000000,
        Unknown24 = 0x20000000,
        Unknown25 = 0x40000000,
        Unknown26 = 0x80000000
    }
}