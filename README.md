# AWS CDK in C#

Trying out AWS CDK in C#. 

# Project Structure (WILL KEEP ADDING MORE RESOURCES)

The project structure is as follows: 
1. Lambda receives a request as input and stores the data into a dynamodb table. 


## Points to note
- The code is written in C# and uses the AWS CDK to define the infrastructure.
- The CdkCsharpStack defines a Lambda function, and the path to the handler is specified as `"Handler = "MyLambda::MyLambda.Function::FunctionHandler","`. This is 
because the lambda project is in a different directory `D:\cdk csharp\MyLambda\MyLambda\src\MyLambda\`. This was done purposefully to understand how to use the CDK with a lambda function in a different directory.
- The CDK project is created using the command `cdk init app --language csharp` and the lambda function is created using the command `cdk init app --language=csharp --generate-only cdkCsharpProj`.
- The CDK project is in this directory `D:\cdk csharp\CdkCsharpProj\CdkCsharpProj\`. 
- We publish the lambda function using the command `dotnet lambda package "../../../output/MyLambda.zip"` . This will create the publish files in a separate directory and this path will be used by the cdk app to create the lambda function.
- We should run cdk bootstrap from the directory where cdk.json is located, because that is the root of your CDK app.


## Resources created till now
 - Lambda function