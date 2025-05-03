using System.Collections.Generic;
using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace CdkCsharp
{
    public class CdkCsharpStack : Stack
    {
        internal CdkCsharpStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var table=  new Amazon.CDK.AWS.DynamoDB.Table(this, "MyTable", new Amazon.CDK.AWS.DynamoDB.TableProps
            {
                PartitionKey = new Amazon.CDK.AWS.DynamoDB.Attribute
                {
                    Name = "Id",
                    Type = Amazon.CDK.AWS.DynamoDB.AttributeType.STRING
                },
                TableName = "MyTable",
                BillingMode = BillingMode.PAY_PER_REQUEST,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
            
            var lambda= new Function(this, "MyLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_8,
                Code = Code.FromAsset(@"\cdk csharp\MyLambda\MyLambda\src\MyLambda\bin\Release\net8.0\MyLambda.zip"),
                Handler = "MyLambda::MyLambda.Function::FunctionHandler",
                Timeout = Duration.Seconds(30),
                Environment = new Dictionary<string, string>()
                {
                    {"TABLE_NAME", "MyTable"}
                }
            });

            table.GrantReadWriteData(lambda);
        }
    }
}
