using System.Text;
using YgoSoul.Query.Component;

namespace YgoSoul.Query;

public class FieldQuery
{
    public IReadOnlyDictionary<byte, PlayerInfo> PlayerInfos { get; private set; }
    private FieldQuery() { }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var p in PlayerInfos)
        {
            sb.AppendLine($"Player={p.Key}, Info=[{p.Value}]");
        }

        return sb.ToString();
    }

    public class Builder
    {
        private Builder()
        {
            
        }
        
        public static Builder Create() => new Builder();
        
        private Dictionary<byte, PlayerInfo> _playerInfo = new();
    
        public Builder AddPlayerInfo(byte player, PlayerInfo info)
        {
            _playerInfo.Add(player, info);
            return this;
        }

        public FieldQuery Build()
        {
            var query = new FieldQuery();
            query.PlayerInfos = _playerInfo;
            return query;
        }
    }
}