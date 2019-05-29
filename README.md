# PaymentGateway
Payment Gateway APIs

This is a set of APIs that connects merchants to acquiring banks to allow them to send their payments. They call also call an API to get the status of their payments.

Features

Uses EntityFramework Core (InMemory Provider) for data storage
Uses CompositionRoot pattern to register all dependencies using Native .NET Core Dependency Injection
Interface-based programming
Validation with FluentValidation
Swashbuckle to generate API documentation + UI to explore and test endpoints
AutoRest to generate a client library
Unit tests using xUnit.net
