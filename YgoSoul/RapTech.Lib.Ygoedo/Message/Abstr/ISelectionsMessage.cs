namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

public interface ISelectionsMessage : IOcgMessage
{
    bool CanCancel { get; }
    byte[] Cancel();
}