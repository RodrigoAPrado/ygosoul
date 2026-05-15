using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SelectBattleCmdParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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