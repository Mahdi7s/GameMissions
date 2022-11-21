﻿using Duende.IdentityServer.EntityFramework.Options;
using GameMissions.Web.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GameMissions.Web.Data;
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
  public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
      : base(options, operationalStoreOptions)
  {

  }
}
