namespace YgoSoul.Util;

public class PacketReader
{
    private readonly byte[] _buffer;
    private int _pos;

    public PacketReader(byte[] buffer)
    {
        _buffer = buffer;
        _pos = 0;
    }

    public int Position => _pos;
    public int Length => _buffer.Length;
    public bool EndOfBuffer => _pos >= _buffer.Length;

    public byte ReadByte()
    {
        return _buffer[_pos++];
    }

    public ushort ReadUInt16()
    {
        var value = BitConverter.ToUInt16(_buffer, _pos);
        _pos += 2;
        return value;
    }

    public uint ReadUInt32()
    {
        var value = BitConverter.ToUInt32(_buffer, _pos);
        _pos += 4;
        return value;
    }

    public int ReadInt32()
    {
        var value = BitConverter.ToInt32(_buffer, _pos);
        _pos += 4;
        return value;
    }

    public ulong ReadULong64()
    {
        var value = BitConverter.ToUInt64(_buffer, _pos);
        _pos += 8;
        return value;
    }
    
    public byte[] ReadBytes(int count)
    {
        var result = new byte[count];
        Buffer.BlockCopy(_buffer, _pos, result, 0, count);
        _pos += count;
        return result;
    }

    public void Skip(int count)
    {
        _pos += count;
    }

    public byte PeekByte()
    {
        return _buffer[_pos];
    }
}