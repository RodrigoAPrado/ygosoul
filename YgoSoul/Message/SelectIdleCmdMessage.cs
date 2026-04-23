using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectIdleCmdMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => _choices.Count;
    
    private readonly List<IIdleCmdChoice> _choices;
    private readonly uint _player;
    
    public SelectIdleCmdMessage(uint player, List<IIdleCmdChoice> choices)
    {
        _choices = choices;
        _player = player;
    }

    public byte[] GetResponse(int id)
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
        sb.AppendLine($"Player {_player}, input your action:");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"{i} -> {_choices[i]}");
        }
        return sb.ToString();
    }
}