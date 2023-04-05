# AromaVilla
A Sample N-layered .NET Core Project Demonstrating Clean Architecture and the Generic Repository Pattern.

## Packages

### ApplicationCore
```
Install-Package Ardalis.Specification -v 6.1.0
```

### Infrastructure
```
Install-Package Microsoft.EntityFrameworkCore -v 6.0.15
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.15
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 6.0.8
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 6.0.15
Install-Package Microsoft.EntityFrameworkCore.Design -v 6.0.15
Install-Package Ardalis.Specification.EntityFrameworkCore -v 6.1.0
```

### Web
```
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.15
```

## Migrations
Before running the following commands, make sure that Web is set as startup project. Run the following commands on the project "Infrastructure".

### Infrastructure
```
Add-Migration InitialCreate -Context ShopContext -OutputDir Data/Migrations
Update-Database -Context ShopContext

Add-Migration InitialIdentity -Context AppIdentityDbContext -OutputDir Identity/Migrations
Update-Database -Context AppIdentityDbContext
```

## Resources
* https://gist.github.com/yigith/c6f999788b833dc3d22ac6332a053dd1
* https://codepen.io/yigith/pen/PoOrWjX