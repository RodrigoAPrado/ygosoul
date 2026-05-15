using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SelectDisfieldMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Choices.Count;

    public byte Player { get; }
    public uint Amount { get; }
    public IReadOnlyList<OCG_Zone> Choices { get; }

    public SelectDisfieldMessage(byte player, uint amount, List<OCG_Zone> choices)
    {
        Player = player;
        Amount = amount;
        Choices = choices;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];
        
        if (id < 0 || id >= Choices.Count)
            return [];

        var zone = Choices[id];
        if (!ZoneUtils.ZoneLocation.ContainsKey(zone)
            || !ZoneUtils.ZoneIndexInput.ContainsKey(zone))
            return [];

        var response = new byte[3];
        response[1] = (byte)ZoneUtils.ZoneLocation[zone];
        response[2] = (byte)ZoneUtils.ZoneIndexInput[zone];
        if(ZoneUtils.ZoneIndexQuery.Contains(zone))
            response[0] = Player;
        else
            response[0] = (byte) Math.Abs(Player-1);
        
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