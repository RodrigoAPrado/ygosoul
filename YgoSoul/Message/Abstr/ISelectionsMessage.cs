namespace YgoSoul.Message.Abstr;

public interface ISelectionsMessage : IMessage
{
    byte[] GetResponse(List<int> ids);
    byte[] Cancel();
}