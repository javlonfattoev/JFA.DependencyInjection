# JFA.DependencyInjection
Register services according to container with service lifetime attributes
#
>Install package from [nuget.org](https://www.nuget.org/packages/JFA.DependencyInjection)
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

[Singleton]
public class OrdersService : IOrdersService
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
