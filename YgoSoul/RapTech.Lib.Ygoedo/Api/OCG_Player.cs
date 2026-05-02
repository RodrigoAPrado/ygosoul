using System.Runtime.InteropServices;

namespace YgoSoul.RapTech.Lib.Ygoedo.Api;

[StructLayout(LayoutKind.Sequential)]
public struct OCG_Player {
    public uint startingLP;
    public uint startingDrawCount;
    public uint drawCountPerTurn;
}