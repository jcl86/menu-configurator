using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace MenuConfigurator.FunctionalTests
{
    [CollectionDefinition(nameof(ServerFixtureCollection))]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
    }
}


