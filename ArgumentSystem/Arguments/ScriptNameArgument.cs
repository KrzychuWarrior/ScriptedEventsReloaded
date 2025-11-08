using JetBrains.Annotations;
using SER.ArgumentSystem.BaseArguments;
using SER.Helpers.ResultSystem;
using SER.ScriptSystem.Structures;
using SER.TokenSystem.Tokens;

namespace SER.ArgumentSystem.Arguments;

public class ScriptNameArgument(string name) : Argument(name)
{
    public override string InputDescription => "Name of a script";
    
    [UsedImplicitly]
    public DynamicTryGet<ScriptName> GetConvertSolution(BaseToken token)
    {
        return new(() =>
        {
            var name = token.GetBestTextRepresentation(Script);
            return ScriptName.TryInit(name);
        });
    }
}