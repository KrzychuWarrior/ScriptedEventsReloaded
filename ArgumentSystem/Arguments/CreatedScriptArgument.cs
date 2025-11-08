using JetBrains.Annotations;
using SER.ArgumentSystem.BaseArguments;
using SER.Helpers.ResultSystem;
using SER.ScriptSystem;
using SER.TokenSystem.Tokens;

namespace SER.ArgumentSystem.Arguments;

public class CreatedScriptArgument(string name) : Argument(name)
{
    public override string InputDescription => "Name of a script to create";
    
    [UsedImplicitly]
    public DynamicTryGet<Script> GetConvertSolution(BaseToken token)
    {
        return new(() => Script.CreateByScriptName(token.GetBestTextRepresentation(Script), null));
    }
}