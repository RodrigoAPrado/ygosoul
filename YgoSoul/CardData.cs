using System.Runtime.InteropServices;

namespace YgoSoul;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct OCG_CardData
{
    public uint code;
    public uint alias;
    public IntPtr setcode;
    public uint type;
    public uint level;    // O Level vem depois
    public uint attribute;
    public ulong race;
    private uint _padding;     // Padding implícito do C++
    public int attack;    // O Ataque vem aqui
    public int defense;   // A Defesa vem aqui
    public uint lscale;
    public uint rscale;
    public uint link_marker;
}