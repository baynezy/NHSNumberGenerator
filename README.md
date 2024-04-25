# NHS Number Generator

This project is a .Net library to generate NHS numbers in the valid format.


| Branch    | Status                                                                                                                                                                                                        |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `master`  | [![master](https://github.com/baynezy/NHSNumberGenerator/actions/workflows/branch-master.yml/badge.svg?branch=master)](https://github.com/baynezy/NHSNumberGenerator/actions/workflows/branch-master.yml)     |
| `develop` | [![develop](https://github.com/baynezy/NHSNumberGenerator/actions/workflows/branch-develop.yml/badge.svg?branch=develop)](https://github.com/baynezy/NHSNumberGenerator/actions/workflows/branch-develop.yml) |

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