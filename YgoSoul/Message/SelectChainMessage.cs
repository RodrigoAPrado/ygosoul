using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectChainMessage : BaseMessage
{
    public override InputType Input => InputType.Confirmation;
    private uint _player;
    private uint _effects;
    private uint _forced;
    private string _timming;
    private string _timming2;
    
    public SelectChainMessage(uint player, uint effects, uint forced, string timming, string timming2)
    {
        _player = player;
        _effects = effects;
        _forced = forced;
        _timming = timming;
        _timming2 = timming2;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(
            $"Player {_player}, you have {_effects} effects, {_forced} forced effects, " +
            $"it is the {_timming} timming for you and {_timming2} timming for your opponent.");
        if (_effects == 0 && _forced == 0)
        {
            sb.AppendLine("There is nothing to be activated...");
        }

        return sb.ToString();
    }
}