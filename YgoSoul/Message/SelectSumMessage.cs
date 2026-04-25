using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectSumMessage : ISelectionsMessage
{
    public InputType Input => InputType.Selections;
    public int InputCount { get; }

    public bool CanCancel => false;
    public byte[] GetResponse(int id)
    {
        throw new NotImplementedException();
    }
    public byte[] GetResponse(List<int> ids)
    {
        throw new NotImplementedException();
    }

    public byte[] Cancel()
    {
        throw new NotImplementedException();
    }
}