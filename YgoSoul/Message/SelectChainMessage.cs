using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectChainMessage : BaseMessage
{
    public override InputType Input => InputType.Confirmation;

    private readonly byte _player;
    private readonly bool _cancelable;
    private readonly bool _forced;
    private readonly uint _timingMask;
    private readonly uint _timingOtherMask;
    private readonly IReadOnlyList<ChainOption> _effects;

    public SelectChainMessage(
        byte player, 
        bool cancelable, 
        bool forced, 
        uint timingMask, 
        uint timingOtherMask, 
        IReadOnlyList<ChainOption> effects
        )
    {
        _player = player;
        _cancelable = cancelable;
        _forced = forced;
        _timingMask = timingMask;
        _timingOtherMask = timingOtherMask;
        _effects = effects;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(
            $"Player {_player}, {_effects.Count} effect(s) available. " +
            $"Cancelable: {_cancelable}, Forced: {_forced}."
        );

        var timingList = new List<HintTiming>();
        var timingOtherList = new List<HintTiming>();
        
        foreach (HintTiming hintTiming in System.Enum.GetValues(typeof(HintTiming)))
        {
            if (((uint)hintTiming & _timingMask) != 0)
            {
                timingList.Add(hintTiming);
            }
            if (((uint)hintTiming & _timingOtherMask) != 0)
            {
                timingOtherList.Add(hintTiming);
            }
        }

        sb.AppendLine($"For player {_player}, the timing(s) is(are):");
        foreach (var t in timingList)
        {
            sb.Append($"{t},");
        }

        sb.AppendLine();
        sb.AppendLine($"For player {1-_player}, the timing(s) is(are):");
        foreach (var t in timingOtherList)
        {
            sb.Append($"{t},");
        }

        sb.AppendLine();
        if (_effects.Count == 0)
        {
            sb.AppendLine("There is nothing to be activated...");
            return sb.ToString();
        }

        sb.AppendLine("Available chain options:");

        for (int i = 0; i < _effects.Count; i++)
        {
            var e = _effects[i];

            sb.AppendLine(
                $"[{i}] CardCode={e.Code}, Controller={e.Controller}, " +
                $"Location=0x{e.Location:X}, Seq={e.Sequence}, Desc={e.Description}"
            );
        }

        return sb.ToString();
    }
}