﻿using FastEndpoints;
using IcaKvantumPrice.ApiService.Contracts.Requests;
using IcaKvantumPrice.ApiService.Services;
using Microsoft.AspNetCore.Authorization;

namespace IcaKvantumPrice.ApiService.Endpoints;

[HttpPost("receipts"), AllowAnonymous]
public class UploadReceiptEndpoint(IPdfService pdfService, ILogger<UploadReceiptEndpoint> logger) : Endpoint<UploadReceiptRequest, EmptyResponse>
{
    public override async Task HandleAsync(UploadReceiptRequest req, CancellationToken ct)
    {
        await pdfService.AddShoppingsFromFile(req.File);
    }
}
