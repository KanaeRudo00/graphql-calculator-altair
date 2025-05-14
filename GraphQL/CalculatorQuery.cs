using CalculatorGraphQLApi.Models;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace CalculatorGraphQLApi.GraphQL
{
    public class CalculatorQuery : ObjectGraphType
    {
        public CalculatorQuery()
        {
            AddField(new FieldType
            {
                Name = "add",
                Arguments = new QueryArguments(
            new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "a" },
            new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "b" }
            ),
                Type = typeof(OperationResultType),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    double a = context.GetArgument<double>("a");
                    double b = context.GetArgument<double>("b");
                    return new OperationResult { Result = a + b };
                })
            });

            AddField(new FieldType
            {
                Name = "subtract",
                Arguments = new QueryArguments(
            new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "a" },
            new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "b" }
        ),
                Type = typeof(OperationResultType),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    double a = context.GetArgument<double>("a");
                    double b = context.GetArgument<double>("b");
                    return new OperationResult { Result = a - b };
                })
            });

            AddField(new FieldType
            {
                Name = "multiply",
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "a" },
                    new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "b" }
                ),
                Type = typeof(OperationResultType),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    double a = context.GetArgument<double>("a");
                    double b = context.GetArgument<double>("b");
                    return new OperationResult { Result = a * b };
                })
            });

            AddField(new FieldType
            {
                Name = "divide",
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "a" },
                    new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "b" }
                ),
                Type = typeof(OperationResultType),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    double a = context.GetArgument<double>("a");
                    double b = context.GetArgument<double>("b");

                    if (b == 0)
                    {
                        return new OperationResult
                        {
                            Result = 0,
                            Message = "Division by zero is not allowed."
                        };
                    }

                    return new OperationResult { Result = a / b };
                })
            });
        }
    }
}