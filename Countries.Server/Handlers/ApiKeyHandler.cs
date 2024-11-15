﻿namespace Countries.Server.Handlers;

public class ApiKeyHandler : DelegatingHandler
{
    private readonly string _apiKey;

    public ApiKeyHandler(string apiKey)
    {
        _apiKey = apiKey;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri == null)
        {
            throw new InvalidOperationException("Request URI is null");
        }

        var uriBuilder = new UriBuilder(request.RequestUri);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

        query["access_key"] = _apiKey;
        uriBuilder.Query = query.ToString();
        request.RequestUri = uriBuilder.Uri;

        return await base.SendAsync(request, cancellationToken);
    }
}