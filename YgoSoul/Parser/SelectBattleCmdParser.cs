using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectBattleCmdParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte(); //msg
        var player = reader.ReadByte();
        var effectCount = reader.ReadUInt32();

        var choices = new List<BattleCmdChoice>();
        uint index = 0;
        for (var i = effectCount; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var description = reader.ReadString64();
            reader.Skip(1); // client mode
            choices.Add(new BattleCmdEffectChoice(index, cardCode, controller, location, sequence, description));
            index++;
        }
        
        var attackCount = reader.ReadUInt32();
        index = 0;
        for (var i = attackCount; i > 0; i--)
        {
            var card = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            uint sequence = reader.ReadByte();
            var directAttack = reader.ReadByte() == 1;
        }

        var toMainPhase2 = reader.ReadByte() == 1;
        var toEndPhase = reader.ReadByte() == 1;

        throw new NotImplementedException();
    }
}