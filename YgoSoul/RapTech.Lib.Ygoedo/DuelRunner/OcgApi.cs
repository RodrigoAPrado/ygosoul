using System.Runtime.InteropServices;

namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public static class OcgApi
{
    private const string DllName = "ocgcore";

    /*** CORE INFORMATION ***/
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OCG_GetVersion(out int major, out int minor);

    /*** DUEL CREATION AND DESTRUCTION ***/
    // Note o 'ref' para bater com o 'const OCG_DuelOptions*'
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int OCG_CreateDuel(out IntPtr duel, ref OCG_DuelOptions options);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OCG_DestroyDuel(IntPtr duel);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OCG_DuelNewCard(IntPtr duel, ref OCG_NewCardInfo info);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OCG_StartDuel(IntPtr duel);

    /*** DUEL PROCESSING AND QUERYING ***/
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int OCG_DuelProcess(IntPtr duel);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr OCG_DuelGetMessage(IntPtr duel, out uint length);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OCG_DuelSetResponse(IntPtr duel, byte[] buffer, uint length);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int OCG_LoadScript(IntPtr duel, byte[] buffer, uint length, [MarshalAs(UnmanagedType.LPStr)] string name);
        
    // Queries
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint OCG_DuelQueryCount(IntPtr pDuel, byte team, uint loc);
    //[DllImport("ocgcore.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern IntPtr OCG_DuelQuery(IntPtr pDuel, out uint length, ref OCG_QueryInfo info_ptr);

    //[DllImport("ocgcore.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern IntPtr OCG_DuelQueryLocation(IntPtr pDuel, out uint length, ref OCG_QueryInfo info_ptr);

    [DllImport("ocgcore.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr OCG_DuelQueryField(IntPtr pDuel, out uint length);
}

[StructLayout(LayoutKind.Explicit, Size = 28)]
public struct OCG_NewCardInfo
{
    [FieldOffset(0)] public byte team;
    [FieldOffset(1)] public byte duelist;
    
    [FieldOffset(4)] public uint code; 
    
    [FieldOffset(8)] public byte con;
    
    [FieldOffset(12)] public uint loc; 
    
    [FieldOffset(16)] public uint seq;
    [FieldOffset(20)] public uint pos;
}