using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectOptionMessage : ISelectionOcgMessage, ISelectOptionMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Options.Count;

    public byte Player { get; }
    public IReadOnlyList<string> Options { get; }
    private readonly List<ulong> _options;
    
    public SelectOptionMessage(byte player, List<ulong> options)
    {
        Player = player;
        _options = options;
        Options = _options.Select(DescriptionUtil.GetDescription).ToList().AsReadOnly();
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
            sb.AppendLine($"[{i}] => {DescriptionUtil.GetDescription(_options[i])}, {_options[i]:x16}");
        }
        return sb.ToString();
    }

    public bool CanCancel => false;
    public byte[] Cancel()
    {
        return [];
    }
}