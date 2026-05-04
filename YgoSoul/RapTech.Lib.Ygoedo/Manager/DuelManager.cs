using System.Runtime.InteropServices;
using YgoSoul.RapTech.Lib.Ygoedo.Factory;
using YgoSoul.RapTech.Lib.Ygoedo.Manager;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public class DuelManager : IDuelManager
{
    private Dictionary<GameMessage, IParser> _parsers;

    public ICardLibrary CardLibrary { get; }
    public IOcgDuel CurrentDuel => _ocgDuel;
    private OcgDuel? _ocgDuel;
    
    public DuelManager(ICardLibrary cardLibrary, Dictionary<GameMessage, IParser> parsers)
    {
        CardLibrary = cardLibrary;
        _parsers = parsers;
    }
    
    public bool CreateOcgDuel()
    {
        if (_ocgDuel == null) 
            return false;
        _ocgDuel = new OcgDuel(ParseMessages);
        return true;
    }

    public bool DisposeDuel()
    {
        throw new NotImplementedException();
    }

    private void ParseMessages(IntPtr message, uint length)
    {
        var buffer = new byte[length];
        Marshal.Copy(message, buffer, 0, (int)length);
        
        var offset = 0;
        var messages = new List<IMessage>();
        
        while (offset < buffer.Length) {
            var msgSize = BitConverter.ToInt32(buffer, offset);
            offset += 4;

            var msgData = new byte[msgSize];
            Array.Copy(buffer, offset, msgData, 0, msgSize);
            offset += msgSize;

            messages.Add(ParseSingleMessage(msgData));
        }
        
        _ocgDuel?.SetNewMessages(messages);
    }

    private IMessage ParseSingleMessage(byte[] buffer)
    {
        var msgType = (GameMessage)buffer[0];
        _parsers.TryGetValue(msgType, out var parser);
        if (parser == null)
            throw new InvalidOperationException();
        return parser.Parse(buffer);
    }
}