using Soenneker.Loops.Contacts.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Loops.Contacts.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LoopsContactsUtilTests : HostedUnitTest
{
    private readonly ILoopsContactsUtil _util;

    public LoopsContactsUtilTests(Host host) : base(host)
    {
        _util = Resolve<ILoopsContactsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
