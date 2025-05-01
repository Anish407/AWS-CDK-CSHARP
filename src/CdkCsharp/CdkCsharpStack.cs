using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace CdkCsharp
{
    public class CdkCsharpStack : Stack
    {
        internal CdkCsharpStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var lambda= new Function(this, "MyLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_8,
                Code = Code.FromAsset(@"\cdk csharp\MyLambda\MyLambda\src\MyLambda\bin\Release\net8.0\MyLambda.zip"),
                Handler = "MyLambda::MyLambda.Function::FunctionHandler",
            });
        }
    }
}
