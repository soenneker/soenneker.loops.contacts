using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Loops.ClientUtil.Registrars;
using Soenneker.Loops.Contacts.Abstract;

namespace Soenneker.Loops.Contacts.Registrars;

/// <summary>
/// A utility library for contact related Loops operations
/// </summary>
public static class LoopsContactsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ILoopsContactsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLoopsContactsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLoopsClientUtilAsSingleton().TryAddSingleton<ILoopsContactsUtil, LoopsContactsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ILoopsContactsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLoopsContactsUtilAsScoped(this IServiceCollection services)
    {
        services.AddLoopsClientUtilAsSingleton().TryAddScoped<ILoopsContactsUtil, LoopsContactsUtil>();

        return services;
    }
}
