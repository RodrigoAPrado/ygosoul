namespace YgoSoul.RapTech.Lib.YgoEdo.Domain.Bridge;

public class OcgResponse
{
    public IntPtr Message { get; }
    public uint Length { get; }
    
    public OcgResponse(IntPtr message, uint length)
    {
        Message = message;
        Length = length;
    }
}