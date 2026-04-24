using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
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

        for (var i = effectCount; i > 0; i--)
        {
            var card = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var description = reader.ReadString64();
            reader.Skip(1); // client mode
        }
        
        var attackCount = reader.ReadUInt32();
        
        for (var i = attackCount; i > 0; i--)
        {
            var card = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadByte();
            var directAttack = reader.ReadByte();
        }

        var toMainPhase2 = reader.ReadByte();
        var toEndPhase = reader.ReadByte();

        throw new NotImplementedException();
    }
}