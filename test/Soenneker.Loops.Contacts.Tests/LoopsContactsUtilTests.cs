using Soenneker.Loops.Contacts.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Loops.Contacts.Tests;

[Collection("Collection")]
public sealed class LoopsContactsUtilTests : FixturedUnitTest
{
    private readonly ILoopsContactsUtil _util;

    public LoopsContactsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ILoopsContactsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
