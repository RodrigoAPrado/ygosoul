using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Parser;

public class SelectIdleCmdParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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
                var location = (OCG_CardLocation)reader.ReadByte();
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