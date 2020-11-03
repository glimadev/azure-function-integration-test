using Xunit;

namespace azure_function_integration_test
{
    [CollectionDefinition(nameof(FunctionTestCollection))]
    public class FunctionTestCollection : ICollectionFixture<FunctionTestFixture>
    {
    }
}
