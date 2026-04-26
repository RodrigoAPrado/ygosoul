using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectChainMessage : BaseMessage
{
    public override InputType Input => InputType.SelectChain;
    public byte Player { get; }
    public bool Cancelable { get; }
    public bool Forced { get; }
    public uint TimingMask { get; }
    public uint TimingOtherMask { get; }
    public IReadOnlyList<ChainOption> Effects { get; }

    public SelectChainMessage(
        byte player, 
        bool cancelable, 
        bool forced, 
        uint timingMask, 
        uint timingOtherMask, 
        IReadOnlyList<ChainOption> effects
    )
    {
        Player = player;
        Cancelable = cancelable;
        Forced = forced;
        TimingMask = timingMask;
        TimingOtherMask = timingOtherMask;
        Effects = effects;
    }

    public override byte[] GetResponse(int id)
    {
        if (id < Effects.Count || id >= Effects.Count)
            return [];
        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(
            $"Player {Player}, {Effects.Count} effect(s) available. " +
            $"Cancelable: {Cancelable}, Forced: {Forced}."
        );

        var timingList = new List<HintTiming>();
        var timingOtherList = new List<HintTiming>();
        
        foreach (HintTiming hintTiming in System.Enum.GetValues(typeof(HintTiming)))
        {
            if (((uint)hintTiming & TimingMask) != 0)
            {
                timingList.Add(hintTiming);
            }
            if (((uint)hintTiming & TimingOtherMask) != 0)
            {
                timingOtherList.Add(hintTiming);
            }
        }

        sb.AppendLine($"For player {Player}, the timing(s) is(are):");
        foreach (var t in timingList)
        {
            sb.Append($"{t},");
        }

        sb.AppendLine();
        sb.AppendLine($"For player {1-Player}, the timing(s) is(are):");
        foreach (var t in timingOtherList)
        {
            sb.Append($"{t},");
        }

        sb.AppendLine();
        if (Effects.Count == 0)
        {
            sb.AppendLine("There is nothing to be activated...");
            return sb.ToString();
        }

        sb.AppendLine("Available chain options:");

        for (int i = 0; i < Effects.Count; i++)
        {
            var e = Effects[i];

            sb.AppendLine(
                $"[{i}] CardCode={CardLibrary.GetCard(e.Code).Name}, Controller={e.Controller}, " +
                $"Location={e.Location}, Seq={e.Sequence}, Desc={e.Description}"
            );
        }

        return sb.ToString();
    }
}