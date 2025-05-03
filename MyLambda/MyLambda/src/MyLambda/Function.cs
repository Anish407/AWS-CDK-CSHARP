using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyLambda;

public class Function
{
    private readonly ITable _table;
    public Function()
    {
        var client= new Amazon.DynamoDBv2.AmazonDynamoDBClient();
        var tableName = Environment.GetEnvironmentVariable("TABLE_NAME");
        _table= Table.LoadTable(client, tableName);
    }
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public async Task FunctionHandler(string input, ILambdaContext context)
    {
        var id = Guid.NewGuid().ToString();
        var item = new Document
        {
            ["Id"] = id,
            ["body"] = input.ToUpper(),
            ["timestamp"] = DateTime.UtcNow.ToString("o")
        };

        await _table.PutItemAsync(item);
    }
}