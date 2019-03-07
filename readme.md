# Project structure example

This demonstrates a very simple 3 tier application (host/app, business logic, data) with a first level onion architecture. I feel like this is the easiest compromise/starting point for most service solutions. If some solutions grow a bit bigger, then there's another layer or two to add (e.g. interfaces), but for the most part existing layers will just have added projects (e.g. Infrastructure.Sql may be joined by Infrastructure.UserService or even Infrastructure.RavenDb if it utilizes multiple databases solutions)

## Simplified example
- Structure3TierDemo.Api
  - Appplication configuration (including DI setup)
  - Provides endpoints
  - Contracts
- Structure3TierDemo.Domain
  - Business logic (models and services)
  - Behaviors remain within objects unless they span multiple entities, in which case that behavior should be removed to a service. This protects various principles of cohesion.
  - Domain shouldn't know anything about implementations (databases, http, etc.). These items are abstracted to an interface and implemented outside of this assembly
- Structure3TierDemo.Infrastructure.Sql
  - Infrastucture is really just implementation of interfaces (e.g. services and data repos) defined in the domain. For example `Infrastructure.Sql` would be a SQL implementation and `Infrastructure.UserInfo` might be a service abstraction for the User service.
- Structure3TierDemo.Infrastructure.UserService
  - Another infrastructure implementation for what be an abstraction for an external service.

Should the solution grow to a point where there the need to reference interfaces in domain would violate dependency boundaries, those interfaces would be relocated to a shared "Interfaces" project. Usually, to continue protection of the domain, adapters are created to adapt the shared interface to the domain interface. I generally try to avoid this as it is potentially another layer of mapping to deal with. It usually easier to just have the domain own the important interfaces.

## Demonstrations in this solution
- 3 tier (host/application, business logic, data)
- DI setup (installer pattern)
- Configuration setup
  - IOptions<T>
  - Environment variables overriding appsettings
- Screaming architecture

### Other things to notice
- Notice the log message output by `FooController.PostFoo()` -- While in appSettings.json, SampleConfigBlock.Inner1.InnerProp is `abcd`, it gets logged out as `1234` because it was overridden by the environment variable `SampleConfigBlock__Inner1__InnerProp` (set in launchSettings.json) 
- DTO semantics are subdivided into
  - Contracts: suffixed by 'Info' (e.g. `RequestInfo`). These are used at the API boundary only.
  - DAO: which are suffixed by 'Data' (e.g. `FooData`). These represent the data schema. They are marked internal so they cannot be referenced outside of the data implementation (see Sturcture3TierDemo.Infrastructure.Sql). 
- Database IDs are completely hidden. Application ID and database ID (PK) are separate concepts.
  - Notice that when data is mapped from the domain object to the DAO, 'Id' in the domain object is mapped to 'FooId' in the DAO. This is because 'Id' refers to the database id (or PK). In other words, ID becomes the surrogate key and FooId is the natural key.
  - This hides the implementation detail from the application and also makes it easier to migrate data between databases since the PKs no longer matter beyond the database
  - Where possible, consumers of the API should use the natural key instead of the surrogate key. In cases where the natural key happens to be the surrogate key, this pattern still works while allowing it change later.
  - Instead of having a "models" and "controller" folder, the projects are broken into bounded contexts which should demonstrate "screaming architecture" and hopefully making the projects a bit easier to navigate while keeping the intention of various objects clear. The general idea is that instead of creating namespaces for "kinds" of objects, you start by creating a "space" for a particular business case like "managing users". All code within this space is bound to the context. The scope of that context will vary from project to project. The point is that you know for a fact that everything inside of this context is closely related to a business requirement.
    - In projects that serve multiple domains (e.g. web products, orchestration services, etc.), additional layers in the bounded context hierarchy can be easily added to aid in SRP.


#### Mapping patterns
Not demonstrated here, but the pattern I generally use is that domain doesn't really have any mappers because it is the center of the onion and adding mappers would create dependencies in the wrong direction. That said, the result in a simple 3-tier would be that the mappers only exist in the host and data layers. I've usually implemented them as something like this:

``` csharp


```