using CalculatorGraphQLApi.Models;
using GraphQL.Types;

namespace CalculatorGraphQLApi.GraphQL
{
    public class OperationResultType : ObjectGraphType<OperationResult>
    {
        public OperationResultType()
        {
            Field(x => x.Result);
            Field(x => x.Message, nullable: true);
        }
    }
}