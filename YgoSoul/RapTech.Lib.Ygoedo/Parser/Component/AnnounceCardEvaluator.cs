using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser.Component;

public class AnnounceCardEvaluator
{
    // Pilha para armazenar resultados booleanos (para AND, OR, NOT)
    private Stack<bool> _boolStack = new Stack<bool>();
    // Pilha para armazenar valores numéricos (para ISCODE, ISTYPE, etc)
    private Stack<ulong> _valueStack = new Stack<ulong>();

    public bool IsCardValid(OCG_CardData card, List<ulong> options)
    {
        _boolStack.Clear();
        _valueStack.Clear();

        foreach (ulong opt in options)
        {
            // Verifica se é um Opcode (tem o bit 0x4000... ligado)
            if ((opt & 0x4000000000000000) != 0)
            {
                ExecuteOpcode((AnnounceCardOpcode)opt, card);
            }
            else
            {
                // Se não for opcode, é um valor puro (ID, Atributo, etc)
                _valueStack.Push(opt);
            }
        }

        // No final, o resultado da expressão lógica está no topo da pilha de bools
        return _boolStack.Count > 0 ? _boolStack.Pop() : true;
    }

    private void ExecuteOpcode(AnnounceCardOpcode op, OCG_CardData card)
    {
        switch (op)
        {
            // --- Verificadores (Tiram um valor e comparam com a carta) ---
            case AnnounceCardOpcode.IsCode:
                _boolStack.Push(card.code == (uint)_valueStack.Pop());
                break;
            case AnnounceCardOpcode.IsType:
                _boolStack.Push((card.type & (uint)_valueStack.Pop()) != 0);
                break;
            case AnnounceCardOpcode.IsAttribute:
                _boolStack.Push((card.attribute & (uint)_valueStack.Pop()) != 0);
                break;
            case AnnounceCardOpcode.IsRace:
                _boolStack.Push((card.race & _valueStack.Pop()) != 0);
                break;

            // --- Operadores Lógicos (Combinam resultados da boolStack) ---
            case AnnounceCardOpcode.Or:
                if (_boolStack.Count >= 2)
                    _boolStack.Push(_boolStack.Pop() | _boolStack.Pop());
                break;
            case AnnounceCardOpcode.And:
                if (_boolStack.Count >= 2)
                    _boolStack.Push(_boolStack.Pop() & _boolStack.Pop());
                break;
            case AnnounceCardOpcode.Not:
                if (_boolStack.Count >= 1)
                    _boolStack.Push(!_boolStack.Pop());
                break;

            // --- Getters (Pegam dados da carta e põem na valueStack) ---
            case AnnounceCardOpcode.GetCode:
                _valueStack.Push(card.code);
                break;
            case AnnounceCardOpcode.GetType:
                _valueStack.Push(card.type);
                break;

            // Flags de permissão geralmente são tratadas antes do loop de filtragem
            case AnnounceCardOpcode.AllowAliases:
            case AnnounceCardOpcode.AllowTokens:
                break; 
        }
    }
}