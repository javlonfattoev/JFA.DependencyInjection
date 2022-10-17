# JFA.DependencyInjection
Register services according to container with service lifetime attributes
#
>Install package from [nuget.org](NuGet\Install-Package JFA.DependencyInjection -Version 1.0.0)
```C#
NuGet\Install-Package JFA.DependencyInjection -Version <VERSION>
```
#
>Add lifetime attribute to service implementations
```C#
[Scoped]
public class UsersService : IUsersService
{...}

[Transient]
public class ProductsService : IProductsService
{...}
```
#
>Add following line to Program.cs file
```C#
builder.Services.AddServicesFromAttribute();
```
#
>Now you can inject services
```C#
public UsersController(IUsersService usersService)
{...}
```
