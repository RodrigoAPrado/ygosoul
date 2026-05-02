using System.Runtime.InteropServices;

namespace YgoSoul.RapTech.Lib.Ygoedo.Api;

[StructLayout(LayoutKind.Sequential)]
public struct OCG_QueryInfo
{
    public uint flags;
    public byte con;
    public uint loc;
    public uint seq;
    public uint overlay_seq;
}