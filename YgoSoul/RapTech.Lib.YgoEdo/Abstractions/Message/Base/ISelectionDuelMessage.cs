namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

public interface ISelectionDuelMessage : IDuelMessage
{
    bool CanCancel { get; }
}