using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class AnnounceRaceParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();//msg
        var count = reader.ReadByte();//msg
        var races = GetAvailableRaces(reader.ReadULong64());

        return new AnnounceRaceMessage(player, count, races);
    }
    
    public List<MonsterRaces> GetAvailableRaces(ulong availableMask)
    {
        var availableList = new List<MonsterRaces>();

        // Aqui usamos a máscara diretamente (1 significa disponível)
        foreach (MonsterRaces race in Enum.GetValues(typeof(MonsterRaces)))
        {
            ulong raceValue = (ulong)race;

            // 1. Verifica se é uma raça individual (um único bit)
            // 2. Verifica se esse bit está ligado na máscara 'availableMask'
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
}