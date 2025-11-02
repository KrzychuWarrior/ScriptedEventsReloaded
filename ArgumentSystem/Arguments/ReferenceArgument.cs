using JetBrains.Annotations;
using SER.ArgumentSystem.BaseArguments;
using SER.Helpers.Extensions;
using SER.Helpers.ResultSystem;
using SER.TokenSystem.Tokens;
using SER.ValueSystem;

namespace SER.ArgumentSystem.Arguments;

public class ReferenceArgument<TValue>(string name) : Argument(name)
{
    private static readonly string ValidInput = $"a reference to {typeof(TValue).AccurateName} object.";
    public override string InputDescription => ValidInput;

    [UsedImplicitly]
    public DynamicTryGet<TValue> GetConvertSolution(BaseToken token)
    {
        if (!token.CanReturn<ReferenceValue>(out var get))
        {
            return $"Value '{token.RawRep}' does not represent a valid reference.";
        }

        return new(() => get().OnSuccess(TryParse));
    }

    public static TryGet<TValue> TryParse(ReferenceValue value)
    {
        if (value.Value is TValue tValue)
        {
            return tValue;
        }
        
        return $"The {value} reference is not {ValidInput}";
    }
}