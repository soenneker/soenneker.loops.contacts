[![](https://img.shields.io/nuget/v/soenneker.loops.contacts.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.loops.contacts/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.loops.contacts/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.loops.contacts/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.loops.contacts.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.loops.contacts/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.loops.contacts/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.loops.contacts/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Loops.Contacts

Create, update, find, and delete Loops contacts by email address.

## Install

```bash
dotnet add package Soenneker.Loops.Contacts
```

## Configure and register

```json
{ "Loops": { "ApiKey": "<API key>" } }
```

```csharp
services.AddLoopsContactsUtilAsScoped();
```

The scoped operation service deliberately uses the singleton Loops client provider. Use the singleton registration when the operation layer should also live for the application lifetime.

## Create and update

```csharp
string id = await contacts.Create(
    "person@example.com",
    firstName: "Morgan",
    subscribed: true,
    cancellationToken: cancellationToken);

string updatedId = await contacts.Update(
    "person@example.com",
    firstName: "Morgan",
    subscribed: null,
    cancellationToken: cancellationToken);
```

`Create` subscribes the contact by default. On `Update`, `subscribed: null` leaves subscription state unchanged; pass `true` or `false` only when the caller intends to change consent. Both methods throw if Loops returns no contact ID.

## Find and delete

```csharp
string? id = await contacts.Find("person@example.com", cancellationToken);
bool deleted = await contacts.Delete("person@example.com", cancellationToken);
```

`Find` returns the first matching contact ID. `Delete` is destructive and reports the API's success flag. API failures are logged with the contact email and rethrown, so ensure application logs are handled as personal data.
