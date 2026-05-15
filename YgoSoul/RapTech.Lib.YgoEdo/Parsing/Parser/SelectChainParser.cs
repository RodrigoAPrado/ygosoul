using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class SelectChainParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);

        reader.ReadByte(); // msg id

        byte playerId = reader.ReadByte();
        byte cancelable = reader.ReadByte();
        byte forced = reader.ReadByte();

        uint hintTiming = reader.ReadUInt32();
        uint hintTimingOther = reader.ReadUInt32();
        var count = reader.ReadUInt32();

        var chains = new List<ChainOption>();

        for (var i = count; i > 0; i--)
        {
            var code = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (OCG_CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (OCG_CardPosition) reader.ReadUInt32();
            var description = reader.ReadULong64();
            reader.Skip(1); // client mode

            chains.Add(new ChainOption
            {
                Code = code,
                Controller = controller,
                Location = location,
                Sequence = sequence,
                Position = position,
                Description = description
            });
        }
        
        return new SelectChainMessage(
            playerId,
            cancelable != 0,
            forced != 0,
            hintTiming,
            hintTimingOther,
            chains
        );
    }
}