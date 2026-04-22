namespace YgoSoul.Message.Abstr;

public interface IMessage
{
    bool RequiresInput { get; }
    byte[] GetResponse(int id);
}