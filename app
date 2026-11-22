#!/usr/bin/env -S dotnet --

#:sdk Microsoft.NET.Sdk.Web

var app = WebApplication
    .CreateBuilder(new WebApplicationOptions  { WebRootPath = "docs" })
    .Build();
app.UseDefaultFiles().UseStaticFiles();
app.Run();
