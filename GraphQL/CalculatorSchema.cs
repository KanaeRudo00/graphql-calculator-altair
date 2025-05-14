using GraphQL.Types;

namespace CalculatorGraphQLApi.GraphQL;

public class CalculatorSchema : Schema
{
    public CalculatorSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<CalculatorQuery>();
    }
}