using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Loops.Contacts.Abstract;

public interface ILoopsContactsUtil
{
    /// <summary>
    /// Creates a new contact in Loops.so
    /// </summary>
    /// <param name="email">The contact's email address</param>
    /// <param name="firstName">The contact's first name</param>
    /// <param name="lastName">The contact's last name</param>
    /// <param name="subscribed">Whether the contact will receive campaign and loops emails</param>
    /// <param name="userGroup">Group to segment users when sending emails</param>
    /// <param name="userId">A unique user ID from your application</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ID of the created contact</returns>
    ValueTask<string> Create(string email, string? firstName = null, string? lastName = null, bool subscribed = true, string? userGroup = null,
        string? userId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing contact in Loops.so
    /// </summary>
    /// <param name="email">The contact's email address</param>
    /// <param name="firstName">The contact's first name</param>
    /// <param name="lastName">The contact's last name</param>
    /// <param name="subscribed">Whether the contact will receive campaign and loops emails</param>
    /// <param name="userGroup">Group to segment users when sending emails</param>
    /// <param name="userId">A unique user ID from your application</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ID of the updated contact</returns>
    ValueTask<string> Update(string email, string? firstName = null, string? lastName = null, bool? subscribed = null, string? userGroup = null,
        string? userId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a contact by email in Loops.so
    /// </summary>
    /// <param name="email">The contact's email address</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The contact's ID if found, null otherwise</returns>
    ValueTask<string?> Find(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a contact from Loops.so
    /// </summary>
    /// <param name="email">The contact's email address</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the contact was deleted, false otherwise</returns>
    ValueTask<bool> Delete(string email, CancellationToken cancellationToken = default);
}