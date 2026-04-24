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
        void ReadCardList(PlayerActions action)
        {
            var count = reader.ReadInt32();

            uint index = 0;
            for (var i = count; i > 0; i--)
            {
                uint code = reader.ReadUInt32();
                byte controller = reader.ReadByte();
                var location = (CardLocation)reader.ReadByte();
                uint sequence = reader.ReadUInt32();

                ulong description = 0;
                if (action == PlayerActions.EffectActivation)
                {
                    description = reader.ReadUInt64();
                    reader.Skip(1);// client mode
                }
                choices.Add(new IdleCmdChoiceCard(
                    action,
                    controller,
                    index,
                    location,
                    sequence,
                    code
                ));
                index++;
            }
        }

        // ordem FIXA do protocolo
        ReadCardList(PlayerActions.NormalSummon);
        ReadCardList(PlayerActions.SpecialSummon);
        ReadCardList(PlayerActions.ChangeCardPosition);
        ReadCardList(PlayerActions.Set);
        ReadCardList(PlayerActions.SpellOrTrapSet);
        ReadCardList(PlayerActions.EffectActivation);

        // fases
        if (reader.ReadByte() == 1)
            choices.Add(new IdleCmdChoiceOther(PlayerActions.GoToBattlePhase, player));

        if (reader.ReadByte() == 1)
	        choices.Add(new IdleCmdChoiceOther(PlayerActions.GotoEndPhase, player));
        
        if (reader.ReadByte() == 1)
	        choices.Add(new IdleCmdChoiceOther(PlayerActions.ShuffleDeck, player));

        return new SelectIdleCmdMessage(player, choices);
    }
}