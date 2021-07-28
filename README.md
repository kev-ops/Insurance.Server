## Insurance.Application

This layer contains services of what should the application is doing. This contains interfaces and abstractions.

## Insurance.Domain

This layer contains application wide concerns like entities, classes, DTO, Enums, etc.

## Insurance.Infrastructure

This layer contains classes and services and its implementation based on the application layer. This houses database persistence concerns, migration class etc.

## Insurance.WebApi

This project is a web api project which client side is communication. Also acts a presentation layer since, it is the entry point of communication with the client side. This project usually needs the dependency of the application layer to perform its duties.

## Insurance.Test

This project contains sample unit tests for the application. Both server side and service.

## Technology

1. Dot Net 5.0
2. Code first w/ Migrations
3. Entity framework as ORM
4. SQL Server 2019
5. xUnit & Moq
6. Automapper


## Setup

1. In the appsettings.json change the `insuranceConnectionString` pointing to your local SQL server.
2. Apply the Initial migration using this command  `update-database`
