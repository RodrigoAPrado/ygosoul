using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectIdleCmdParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);

        reader.ReadByte(); // msg id

        byte player = reader.ReadByte();

        var choices = new List<IIdleCmdChoice>();

        // helper local
        void ReadCardList(PlayerIdleAction action)
        {
            var count = reader.ReadInt32();

            uint index = 0;
            for (var i = count; i > 0; i--)
            {
                uint code = reader.ReadUInt32();
                byte controller = reader.ReadByte();
                var location = (CardLocation)reader.ReadByte();
                uint sequence = action == PlayerIdleAction.ChangeCardPosition ? reader.ReadByte() : reader.ReadUInt32();

                ulong description = 0;
                if (action == PlayerIdleAction.EffectActivation)
                {
                    description = reader.ReadULong64();
                    reader.Skip(1);// client mode
                }
                choices.Add(new IdleCmdChoiceCard(
                    action,
                    code,
                    controller,
                    location,
                    sequence,
                    index,
                    description
                ));
                index++;
            }
        }

        // ordem FIXA do protocolo
        ReadCardList(PlayerIdleAction.NormalSummon);
        ReadCardList(PlayerIdleAction.SpecialSummon);
        ReadCardList(PlayerIdleAction.ChangeCardPosition);
        ReadCardList(PlayerIdleAction.Set);
        ReadCardList(PlayerIdleAction.SpellOrTrapSet);
        ReadCardList(PlayerIdleAction.EffectActivation);

        // fases
        if (reader.ReadByte() == 1)
            choices.Add(new IdleCmdChoiceOther(PlayerIdleAction.GoToBattlePhase, player));

        if (reader.ReadByte() == 1)
	        choices.Add(new IdleCmdChoiceOther(PlayerIdleAction.GotoEndPhase, player));
        
        if (reader.ReadByte() == 1)
	        choices.Add(new IdleCmdChoiceOther(PlayerIdleAction.ShuffleHand, player));

        return new SelectIdleCmdMessage(player, choices);
    }
}