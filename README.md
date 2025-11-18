[![Build Project](https://github.com/tremorscript/Platy.Aspire.Hosting.Mockoon/actions/workflows/ci.yml/badge.svg)](https://github.com/tremorscript/Platy.Aspire.Hosting.Mockoon/actions/workflows/ci.yml)

[![NuGet Version](https://img.shields.io/nuget/v/Platy.Aspire.Hosting.Mockoon?label=Platy.Aspire.Hosting.Mockoon)](https://www.nuget.org/packages/Platy.Aspire.Hosting.Mockoon/)

# Overview

Azurite support for Aspire.

# Usage

Add a Mockoon instance passing in the path to the mock json file and with a target port:-
```c#
builder.AddMockoonInstance("Mock.json", 3001, containerName:"dc-mockoon");
```