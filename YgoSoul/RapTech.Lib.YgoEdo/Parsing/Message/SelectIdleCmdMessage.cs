using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectIdleCmdMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Choices.Count;

    public IReadOnlyList<IIdleCmdChoice> Choices { get; }
    public byte Player { get; }
    
    public SelectIdleCmdMessage(byte player, List<IIdleCmdChoice> choices)
    {
        Choices = choices;
        Player = player;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];

        if (id < 0 || id >= Choices.Count)
            return [];

        var choice = Choices[id];

        uint value = (choice.Index << 16) | (uint)choice.Action;

        return BitConverter.GetBytes(value); 
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player}, input your action:");
        for (int i = 0; i < Choices.Count; i++)
        {
            sb.AppendLine($"[{i}] => {Choices[i]}");
        }
        return sb.ToString();
    }
}