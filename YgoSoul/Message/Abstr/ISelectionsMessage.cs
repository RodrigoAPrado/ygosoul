namespace YgoSoul.Message.Abstr;

public interface ISelectionsMessage : IMessage
{
    bool CanCancel { get; }
    byte[] GetResponse(List<int> ids);
    byte[] Cancel();
}