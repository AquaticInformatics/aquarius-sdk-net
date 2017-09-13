# AQUARIUS Samples - Service model code generator

This project is a console utility that can generate the [service model DTOs](../Aquarius.Client/Samples/Client/ServiceModel.cs) from the [AQUARIUS Samples Open API definition](https://demo.aqsamples.com/api/swagger.json).

The generated service model DTOs are compatible with the ServiceStack.Client framework and are included in the SDK.

## Why not use an existing Swagger code generator?

There are quite a few open source projects for generating client wrappers from Swagger/OpenApi definitions.
- None of them could be tweaked to create ServiceStack-compliant DTOs required by the Aquarius Platform SDK.
- The Samples support for OpenApi is new and a bit fragile. The JSON spec is good enough for documenting the API, but not quite coherent enough for standard code generators to do their thing.

So we wrote our own.

When the standard code generators can do what we need, we'll delete this hack.

## What this project isn't

- This project is not an arbitrary Swagger code generator. It has been ~~hacked~~ tuned to work with the idiosyncracies of the Samples Swagger spec.

## Project roadmap
- Add support for generating Java DTOs for the Java Platform SDK.
