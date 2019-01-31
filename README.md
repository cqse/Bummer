# Bummer

## Contributing

Please create an issue and a pull request.

## Building

```sh
dotnet build
```

## Publishing

Increment the version number in the `.csproj` file.

```sh
dotnet pack -c Release
dotnet nuget push bin/Release/Cqse.Bummer.*.nupkg -k <NUGET_ORG_APIKEY> -s https://api.nuget.org/v3/index.json
```

