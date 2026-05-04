namespace YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

public interface IDuelManager
{
    ICardLibrary CardLibrary { get; }
    IOcgDuel CurrentDuel { get; }
    bool CreateOcgDuel();
    bool DisposeDuel();
}