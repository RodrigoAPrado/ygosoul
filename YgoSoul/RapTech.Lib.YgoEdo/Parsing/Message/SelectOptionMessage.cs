using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectOptionMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Options.Count;

    public byte Player { get; }
    public IReadOnlyList<ulong> Options { get; }

    public SelectOptionMessage(byte player, List<ulong> options)
    {
        Player = player;
        Options = options;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];
        
        if (id < 0 || id >= Options.Count)
            return [];

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player: {Player}, here are your options:");

        for (var i = 0; i < Options.Count; i++)
        {
            sb.AppendLine($"[{i}] => {DescriptionHandler.GetDescription(Options[i])}, {Options[i]:x16}");
        }
        return sb.ToString();
    }
}