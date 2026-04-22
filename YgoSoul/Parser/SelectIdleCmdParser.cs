using System.Text;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class SelectIdleCmdParser : BaseParser
{
    protected override SelectIdleCmdMessage DoParse(byte[] buffer)
    {
        var choices = new List<IIdleCmdChoice>();
        int player = buffer[1];
        int currentPos = 2;
        foreach (PlayerActions pa in Enum.GetValues(typeof(PlayerActions)))
        {
            if (pa is PlayerActions.GoToBattlePhase or PlayerActions.GotoEndPhase)
                continue;
            
            uint actionValue = BitConverter.ToUInt32(buffer, currentPos);
            var result = AddCardAction(actionValue, currentPos, buffer, choices, pa);
            currentPos = result;
        }
        
        currentPos += 1;
        if(buffer[currentPos] == 1)
            choices.Add(new IdleCmdChoiceOther(PlayerActions.GoToBattlePhase));

        currentPos += 1;
        if(buffer[currentPos] == 1)
            choices.Add(new IdleCmdChoiceOther(PlayerActions.GotoEndPhase));
        
        return new SelectIdleCmdMessage(player, choices);
    }
    
    private static int AddCardAction(uint actionCount, int currentPos, byte[] buffer, List<IIdleCmdChoice> choices, PlayerActions pa)
    {
        if (actionCount > 0)
        {
            for (var i = 0; i < actionCount; i++)
            {
                currentPos += 4;
                uint monsterValue = BitConverter.ToUInt32(buffer, currentPos);
                currentPos += 5;
                uint locationValue = buffer[currentPos];
                currentPos += 1;
                uint positionValue = buffer[currentPos];
                choices.Add(new IdleCmdChoiceCard(pa, i, (CardLocation)locationValue, (int)positionValue, CardLibrary.GetCard(monsterValue).Name));
            }
        }
        currentPos+=4;
        return currentPos;
    }
}