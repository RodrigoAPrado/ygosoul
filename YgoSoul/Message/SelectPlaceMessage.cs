using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;
using YgoSoul.Parser;

namespace YgoSoul.Message;

public class SelectPlaceMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => _choices.Count;
    
    private readonly uint _player;
    private readonly uint _amount;
    private readonly List<SelectPlaceParser.Zone> _choices;

    public SelectPlaceMessage(uint player, uint amount, List<SelectPlaceParser.Zone> choices)
    {
        _player = player;
        _amount = amount;
        _choices = choices;
    }

    public byte[] GetResponse(int id)
    {
        if(id < 0 || id >= _choices.Count)
            return [0xFF, 0xFF, 0xFF];
        
        var zone = _choices[id];
        if(!SelectPlaceParser.ZoneLocation.ContainsKey(zone) 
           || !SelectPlaceParser.ZoneIndex.ContainsKey(zone))
            return [0xFF, 0xFF, 0xFF];
        
        var response = new byte[3];
        response[0] = (byte)_player;
        response[1] = (byte)SelectPlaceParser.ZoneLocation[zone];
        response[2] = (byte)SelectPlaceParser.ZoneIndex[zone];
        return response;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {_player}, you need to select {_amount} places.");
        sb.AppendLine("Please input your action:");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"{i} -> Place card on {_choices[i]}");
        }
        return sb.ToString();
    }
}