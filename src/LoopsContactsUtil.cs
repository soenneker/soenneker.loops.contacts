using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Loops.ClientUtil.Abstract;
using Soenneker.Loops.Contacts.Abstract;
using Soenneker.Loops.OpenApiClient;
using Soenneker.Loops.OpenApiClient.Models;

namespace Soenneker.Loops.Contacts;

/// <inheritdoc cref="ILoopsContactsUtil"/>
public sealed class LoopsContactsUtil : ILoopsContactsUtil
{
    private readonly ILoopsClientUtil _loopsClientUtil;
    private readonly ILogger<LoopsContactsUtil> _logger;

    public LoopsContactsUtil(ILoopsClientUtil loopsClientUtil, ILogger<LoopsContactsUtil> logger)
    {
        _loopsClientUtil = loopsClientUtil;
        _logger = logger;
    }

    public async ValueTask<string> Create(string email, string? firstName = null, string? lastName = null, bool subscribed = true, string? userGroup = null,
        string? userId = null, CancellationToken cancellationToken = default)
    {
        try
        {
            LoopsOpenApiClient client = await _loopsClientUtil.Get(cancellationToken);

            var request = new ContactRequest
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Subscribed = subscribed,
                UserGroup = userGroup,
                UserId = userId
            };

            ContactSuccessResponse? response = await client.Contacts.Create.PostAsync(request, null, cancellationToken);
            return response?.Id ?? throw new Exception("Failed to get contact ID from response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create contact in Loops.so for email {Email}", email);
            throw;
        }
    }

    public async ValueTask<string> Update(string email, string? firstName = null, string? lastName = null, bool? subscribed = null, string? userGroup = null,
        string? userId = null, CancellationToken cancellationToken = default)
    {
        try
        {
            LoopsOpenApiClient client = await _loopsClientUtil.Get(cancellationToken);

            var request = new ContactRequest
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Subscribed = subscribed ?? true,
                UserGroup = userGroup,
                UserId = userId
            };

            ContactSuccessResponse? response = await client.Contacts.Update.PutAsync(request, null, cancellationToken);
            return response?.Id ?? throw new Exception("Failed to get contact ID from response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update contact in Loops.so for email {Email}", email);
            throw;
        }
    }

    public async ValueTask<string?> Find(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            LoopsOpenApiClient client = await _loopsClientUtil.Get(cancellationToken);

            List<Contact>? response = await client.Contacts.Find.GetAsync(options => { options.QueryParameters.Email = email; }, cancellationToken);
            return response?.FirstOrDefault()?.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to find contact in Loops.so for email {Email}", email);
            throw;
        }
    }

    public async ValueTask<bool> Delete(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            LoopsOpenApiClient client = await _loopsClientUtil.Get(cancellationToken);

            var request = new ContactDeleteRequest {Email = email};

            ContactDeleteResponse? response = await client.Contacts.DeletePath.PostAsync(request, null, cancellationToken);
            return response?.Success ?? false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete contact in Loops.so for email {Email}", email);
            throw;
        }
    }
}