# GHCP Contoso Clothing

A minimal .NET 8 storefront modernization lab for practicing GitHub Copilot, GitHub Flow, testing, debugging, documentation, secure coding basics, and simple CI.

## Who this is for

This repository is for early-career engineers, DevOps practitioners, security learners, and adjacent technical roles who want a small, practical repo to use after a GitHub Copilot Fundamentals Workshop.

## What participants will learn

- GitHub flow with small scoped changes
- Copilot prompting and reusable prompt files
- Code generation, refactoring, debugging, and testing
- Secure coding basics and review habits
- Simple CI with GitHub Actions

## Quick start

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/ContosoClothing.Api
```

## Run the API

```bash
dotnet run --project src/ContosoClothing.Api
```

## Run the tests

```bash
dotnet test
```

## Open Swagger

Start the API, then open:

- `http://localhost:5122/swagger`
- or the HTTPS URL shown by `dotnet run`

## Repository structure

```text
ghcp-contoso-clothing/
├── src/ContosoClothing.Api
├── tests/ContosoClothing.Api.Tests
├── docs
├── exercises
└── .github
```

## Workshop learning path

- Day 1: build, read code, generate small changes, refactor, test, debug, document
- Day 2: improve Copilot instructions, use prompt files, practice better prompting
- Day 3: review secure coding basics, make small agent-style changes, review PRs

Start with:

1. `docs/workshop-guide.md`
2. `src/ContosoClothing.Api/Program.cs`
3. `tests/ContosoClothing.Api.Tests/ProductsApiTests.cs`
4. `exercises/00-setup.md`

## Copilot prompts to try

- `.github/prompts/explain-code.prompt.md`
- `.github/prompts/generate-unit-tests.prompt.md`
- `.github/prompts/debug-failing-test.prompt.md`
- `.github/prompts/roses-feature-prompt.prompt.md`

## GitHub flow overview

1. Create or pick an issue
2. Create a branch
3. Make one small change
4. Build and test
5. Open a pull request
6. Review and merge

See `docs/github-flow-guide.md` for a beginner-friendly walkthrough.

## Disclaimer

GHCP Contoso Clothing is a fictional educational lab for `ghcp-contoso-clothing`. It uses in-memory data only, avoids production dependencies, and is intentionally small so learners can understand it in one sitting. It is not production code.
