namespace YgoSoul;
using System.Runtime.InteropServices;

// void (*OCG_DataReader)(void* payload, uint32_t code, OCG_CardData* data)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void DataReader(IntPtr payload, uint code, IntPtr data);

// int (*OCG_ScriptReader)(void* payload, OCG_Duel duel, const char* name)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int ScriptReader(IntPtr payload, IntPtr duel, [MarshalAs(UnmanagedType.LPStr)] string name);

// void (*OCG_LogHandler)(void* payload, const char* string, int type)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void LogHandler(IntPtr payload, [MarshalAs(UnmanagedType.LPStr)] string message, int type);

// void (*OCG_DataReaderDone)(void* payload, OCG_CardData* data)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void DataReaderDone(IntPtr payload, IntPtr data);

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct OCG_Player {
    public uint startingLP;
    public uint startingDrawCount;
    public uint drawCountPerTurn;
}

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct OCG_DuelOptions {
    // Expandimos o array manualmente para garantir 32 bytes contínuos no início
    public ulong seed0;
    public ulong seed1;
    public ulong seed2;
    public ulong seed3;

    public ulong flags;
    
    public OCG_Player team1;
    public OCG_Player team2;
    
    // Pares de Função + Payload
    public IntPtr cardReader;
    public IntPtr payload1;
    
    public IntPtr scriptReader;
    public IntPtr payload2;
    
    public IntPtr logHandler;
    public IntPtr payload3;
    
    public IntPtr cardReaderDone;
    public IntPtr payload4;

    public byte enableUnsafeLibraries;
}