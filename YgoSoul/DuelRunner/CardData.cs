using System.Runtime.InteropServices;

namespace YgoSoul.DuelRunner;

[StructLayout(LayoutKind.Sequential)]
public struct OCG_CardData
{
    public uint code;
    public uint alias;
    public IntPtr setcode;
    public uint type;
    public uint level;
    public uint attribute;
    public ulong race;
    public int attack;
    public int defense;
    public uint lscale;
    public uint rscale;
    public uint link_marker;
}