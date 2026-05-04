using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Util;

public static class FlagExtensions
{
    public static DuelFlags FromDuelMode(this DuelMode value)
    {
        switch (value)
        {
            case DuelMode.MasterRule0:
                return DuelFlags.MasterRuleGoat;
            case DuelMode.MasterRule1:
                return DuelFlags.MasterRule1;
            case DuelMode.MasterRule2:
                return DuelFlags.MasterRule2;
            case DuelMode.MasterRule3:
                return DuelFlags.MasterRule3;
            case DuelMode.MasterRule4:
                return DuelFlags.MasterRule4;
            case DuelMode.MasterRule5:
                return DuelFlags.MasterRule5;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
    
    public static CardIcon ToCardIcon(this MonsterAttributes value)
    {
        switch (value)
        {
            case MonsterAttributes.Earth:
                return CardIcon.Earth;
            case MonsterAttributes.Water:
                return CardIcon.Water;
            case MonsterAttributes.Fire:
                return CardIcon.Fire;
            case MonsterAttributes.Wind:
                return CardIcon.Wind;
            case MonsterAttributes.Light:
                return CardIcon.Light;
            case MonsterAttributes.Dark:
                return CardIcon.Dark;
            case MonsterAttributes.Divine:
                return CardIcon.Divine;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
    public static LinkArrow ToLinkArrow(this LinkMarker value)
    {
        switch (value)
        {
            case LinkMarker.BottomLeft:
                return LinkArrow.BottomLeft;
            case LinkMarker.Bottom:
                return LinkArrow.Bottom;
            case LinkMarker.BottomRight:
                return LinkArrow.BottomRight;
            case LinkMarker.Left:
                return LinkArrow.Left;
            case LinkMarker.Right:
                return LinkArrow.Right;
            case LinkMarker.TopLeft:
                return LinkArrow.TopLeft;
            case LinkMarker.Top:
                return LinkArrow.Top;
            case LinkMarker.TopRight:
                return LinkArrow.TopRight;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
    
    public static CardDataType ToCardDataType(this CardType value)
    {
        switch (value)
        {
            case CardType.Monster:
                return CardDataType.Monster;
            case CardType.Spell:
                return CardDataType.Spell;
            case CardType.Trap:
                return CardDataType.Trap;
            case CardType.Normal:
                return CardDataType.Normal;
            case CardType.Effect:
                return CardDataType.Effect;
            case CardType.Fusion:
                return CardDataType.Fusion;
            case CardType.Ritual:
                return CardDataType.Ritual;
            case CardType.TrapMonster:
                return CardDataType.TrapMonster;
            case CardType.Spirit:
                return CardDataType.Spirit;
            case CardType.Union:
                return CardDataType.Union;
            case CardType.Gemini:
                return CardDataType.Gemini;
            case CardType.Tuner:
                return CardDataType.Tuner;
            case CardType.Synchro:
                return CardDataType.Synchro;
            case CardType.Token:
                return CardDataType.Token;
            case CardType.Maximum:
                return CardDataType.Maximum;
            case CardType.QuickPlay:
                return CardDataType.QuickPlay;
            case CardType.Continuous:
                return CardDataType.Continuous;
            case CardType.Equip:
                return CardDataType.Equip;
            case CardType.Field:
                return CardDataType.Field;
            case CardType.Counter:
                return CardDataType.Counter;
            case CardType.Flip:
                return CardDataType.Flip;
            case CardType.Toon:
                return CardDataType.Toon;
            case CardType.Xyz:
                return CardDataType.Xyz;
            case CardType.Pendulum:
                return CardDataType.Pendulum;
            case CardType.SpSummon:
                return CardDataType.SpSummon;
            case CardType.Link:
                return CardDataType.Link;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
    
    public static MonsterType ToMonsterType(this MonsterRaces value)
    {
        switch (value)
        {
            case MonsterRaces.None:
                return MonsterType.None;
            case MonsterRaces.Warrior:
                return MonsterType.Warrior;
            case MonsterRaces.SpellCaster:
                return MonsterType.SpellCaster;
            case MonsterRaces.Fairy:
                return MonsterType.Fairy;
            case MonsterRaces.Fiend:
                return MonsterType.Fiend;
            case MonsterRaces.Zombie:
                return MonsterType.Zombie;
            case MonsterRaces.Machine:
                return MonsterType.Machine;
            case MonsterRaces.Aqua:
                return MonsterType.Aqua;
            case MonsterRaces.Pyro:
                return MonsterType.Pyro;
            case MonsterRaces.Rock:
                return MonsterType.Rock;
            case MonsterRaces.WingedBeast:
                return MonsterType.WingedBeast;
            case MonsterRaces.Plant:
                return MonsterType.Plant;
            case MonsterRaces.Insect:
                return MonsterType.Insect;
            case MonsterRaces.Thunder:
                return MonsterType.Thunder;
            case MonsterRaces.Dragon:
                return MonsterType.Dragon;
            case MonsterRaces.Beast:
                return MonsterType.Beast;
            case MonsterRaces.BeastWarrior:
                return MonsterType.BeastWarrior;
            case MonsterRaces.Dinosaur:
                return MonsterType.Dinosaur;
            case MonsterRaces.Fish:
                return MonsterType.Fish;
            case MonsterRaces.SeaSerpent:
                return MonsterType.SeaSerpent;
            case MonsterRaces.Reptile:
                return MonsterType.Reptile;
            case MonsterRaces.Psychic:
                return MonsterType.Psychic;
            case MonsterRaces.Divine:
                return MonsterType.Divine;
            case MonsterRaces.CreatorGod:
                return MonsterType.CreatorGod;
            case MonsterRaces.Wyrm:
                return MonsterType.Wyrm;
            case MonsterRaces.Cyberse:
                return MonsterType.Cyberse;
            case MonsterRaces.Illusion:
                return MonsterType.Illusion;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
    
    public static CardSearchCategory ToCardSearchCategory(this CardCategory value)
    {
        switch (value)
        {
            case CardCategory.None:
                return CardSearchCategory.None;
            case CardCategory.DestroyMonster:
                return CardSearchCategory.DestroyMonster;
            case CardCategory.DestroyST:
                return CardSearchCategory.DestroySpellOrTrap;
            case CardCategory.DestroyDeck:
                return CardSearchCategory.DestroyDeck;
            case CardCategory.DestroyHand:
                return CardSearchCategory.DestroyHand;
            case CardCategory.SendToGY:
                return CardSearchCategory.SendToGrave;
            case CardCategory.SendToHand:
                return CardSearchCategory.SendToHand;
            case CardCategory.SendToDeck:
                return CardSearchCategory.SendToDeck;
            case CardCategory.Banish:
                return CardSearchCategory.Banish;
            case CardCategory.Draw:
                return CardSearchCategory.Draw;
            case CardCategory.Search:
                return CardSearchCategory.Search;
            case CardCategory.ChangeAtkDef:
                return CardSearchCategory.ChangeAtkDef;
            case CardCategory.ChangeLevelRank:
                return CardSearchCategory.ChangeLevelRank;
            case CardCategory.ChangePosition:
                return CardSearchCategory.ChangePosition;
            case CardCategory.Piercing:
                return CardSearchCategory.Piercing;
            case CardCategory.DirectAttack:
                return CardSearchCategory.DirectAttack;
            case CardCategory.MultiAttack:
                return CardSearchCategory.MultiAttack;
            case CardCategory.NegateActivation:
                return CardSearchCategory.NegateActivation;
            case CardCategory.NegateEffect:
                return CardSearchCategory.NegateEffect;
            case CardCategory.DamageLP:
                return CardSearchCategory.DamageLifePoints;
            case CardCategory.RecoverLP:
                return CardSearchCategory.RecoverLifePoints;
            case CardCategory.SpecialSummon:
                return CardSearchCategory.SpecialSummon;
            case CardCategory.NonEffectRelated:
                return CardSearchCategory.NonEffectRelated;
            case CardCategory.TokenRelated:
                return CardSearchCategory.TokenRelated;
            case CardCategory.FusionRelated:
                return CardSearchCategory.FusionRelated;
            case CardCategory.RitualRelated:
                return CardSearchCategory.RitualRelated;
            case CardCategory.SynchroRelated:
                return CardSearchCategory.SynchroRelated;
            case CardCategory.XyzRelated:
                return CardSearchCategory.XyzRelated;
            case CardCategory.LinkRelated:
                return CardSearchCategory.LinkRelated;
            case CardCategory.CounterRelated:
                return CardSearchCategory.CounterRelated;
            case CardCategory.Gamble:
                return CardSearchCategory.Gamble;
            case CardCategory.Control:
                return CardSearchCategory.Control;
            case CardCategory.MoveZones:
                return CardSearchCategory.MoveZones;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}