# NHS Number Generator

This project is a .Net library to generate NHS numbers in the alid format.

[![Build Status](https://github.com/baynezy/NHSNumberGenerator/workflows/Test%20and%20Deploy%20Library/badge.svg)](https://github.com/baynezy/NHSNumberGenerator/actions?query=workflow%3ATest%20and%20Deploy%20Library)

## Installation

The library is available on NuGet:

[![NuGet version](https://badge.fury.io/nu/NHSNumberGenerator.svg)](http://badge.fury.io/nu/NHSNumberGenerator)

```powershell
dotnet add package NHSNumberGenerator
```

## Usage

```csharp
var nhsNumber = Generator.Generate();
```