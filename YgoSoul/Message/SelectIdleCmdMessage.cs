using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectIdleCmdMessage : BaseMessage
{
    public override InputType Input => InputType.Value;
    
    private readonly List<IIdleCmdChoice> _choices;
    private readonly int _playerId;
    
    public SelectIdleCmdMessage(int playerId, List<IIdleCmdChoice> choices)
    {
        _choices = choices;
        _playerId = playerId;
    }

    public override byte[] GetResponse(int id)
    {
        if (id >= _choices.Count)
        {
            return [0xFF, 0xFF, 0xFF, 0xFF];
        }
        var choice = _choices[id];
        byte[] response = new byte[4];
        response[0] = (byte)choice.PlayerAction;
        response[2] = (byte)choice.ValueIndex;
        return response;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {_playerId}, input your action:");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"{i} -> {_choices[i]}");
        }
        return sb.ToString();
    }
}