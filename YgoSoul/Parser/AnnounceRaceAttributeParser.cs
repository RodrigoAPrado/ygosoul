using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class AnnounceRaceAttributeParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var message = (GameMessage) reader.ReadByte();
        var player = reader.ReadByte();
        var count = reader.ReadByte();

        switch (message)
        {
            case GameMessage.AnnounceRace:
                return new AnnounceRaceMessage(player, count, GetAvailableRaces(reader.ReadULong64()));
            case GameMessage.AnnounceAttrib:
                return new AnnounceAttributeMessage(player, count, GetAvailableAttributes(reader.ReadUInt32()));
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private List<MonsterRaces> GetAvailableRaces(ulong availableMask)
    {
        var availableList = new List<MonsterRaces>();

        foreach (MonsterRaces race in Enum.GetValues(typeof(MonsterRaces)))
        {
            ulong raceValue = (ulong)race;

            if (raceValue != 0 && (raceValue & (raceValue - 1)) == 0)
            {
                if ((availableMask & raceValue) != 0)
                {
                    availableList.Add(race);
                }
            }
        }

        return availableList;
    }
    
    private List<MonsterAttributes> GetAvailableAttributes(uint availableMask)
    {
        var availableList = new List<MonsterAttributes>();

        foreach (MonsterAttributes attribute in Enum.GetValues(typeof(MonsterAttributes)))
        {
            uint monsterAttribute = (uint)attribute;

            if (monsterAttribute != 0 && (monsterAttribute & (monsterAttribute - 1)) == 0)
            {
                if ((availableMask & monsterAttribute) != 0)
                {
                    availableList.Add(attribute);
                }
            }
        }

        return availableList;
    }
}