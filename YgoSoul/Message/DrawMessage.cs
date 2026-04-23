using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class DrawMessage : BaseMessage
{
    private readonly uint _player;
    private readonly List<DrawnCard> _cards;
    public DrawMessage(uint player, List<DrawnCard> cards)
    {
        _player = player;
        _cards = cards;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {_player} drew the following cards:");
        foreach (var card in _cards)
        {
            sb.AppendLine($"- {card.ToString()}");
        }

        return sb.ToString();
    }
}