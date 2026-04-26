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

        var choices = new List<BattleCmdChoice>();

        void AddBattleCmdChoice(PlayerBattleAction action)
        {
            var count = reader.ReadUInt32();
            uint index = 0;
            for (var i = count; i > 0; i--)
            {
                var cardCode = reader.ReadUInt32();
                var controller = reader.ReadByte();
                var location = (CardLocation)reader.ReadByte();
                if (action == PlayerBattleAction.ActivateEffect)
                {
                    var sequence = reader.ReadUInt32();
                    var description = reader.ReadULong64();
                    reader.Skip(1); // client mode
                    choices.Add(new BattleCmdEffectChoice(action, index, cardCode, controller, location, sequence, description));
                }
                else
                {
                    uint sequence = reader.ReadByte();
                    var directAttack = reader.ReadByte() == 1;
                    choices.Add(new BattleCmdAttackChoice(action, index, cardCode, controller, location, sequence, directAttack));
                }
                index++;
            }
        }
        
        AddBattleCmdChoice(PlayerBattleAction.ActivateEffect);
        AddBattleCmdChoice(PlayerBattleAction.Attack);

        var toMainPhase2 = reader.ReadByte() == 1;
        if(toMainPhase2)
            choices.Add(new BattleCmdOtherChoice(PlayerBattleAction.GoToMainPhase2, 0));
        var toEndPhase = reader.ReadByte() == 1;
        if(toEndPhase)
            choices.Add(new BattleCmdOtherChoice(PlayerBattleAction.GoToEndPhase, 0));

        return new SelectBattleCmdMessage(player, choices);
    }
}