using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;
using YgoSoul.Parser;
using YgoSoul.Util;

namespace YgoSoul.Message;

public class SelectPlaceMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Choices.Count;
    
    public byte Player { get; }
    public uint Amount { get; }
    public IReadOnlyList<Zone> Choices { get; }

    public SelectPlaceMessage(byte player, uint amount, List<Zone> choices)
    {
        Player = player;
        Amount = amount;
        Choices = choices;
    }

    public byte[] GetResponse(int id)
    {
        if(id < 0 || id >= Choices.Count)
            return [];
        
        var zone = Choices[id];
        if(!ZoneUtils.ZoneLocation.ContainsKey(zone) 
           || !ZoneUtils.ZoneIndex.ContainsKey(zone))
            return [];
        
        var response = new byte[3];
        response[0] = (byte)Player;
        response[1] = (byte)ZoneUtils.ZoneLocation[zone];
        response[2] = (byte)ZoneUtils.ZoneIndex[zone];
        return response;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player}, you need to select {Amount} places.");
        sb.AppendLine("Please input your action:");
        for (int i = 0; i < Choices.Count; i++)
        {
            sb.AppendLine($"{i} -> Place card on {Choices[i]}");
        }
        return sb.ToString();
    }
}