using Autofac;
using GameMissions.Core.Interfaces;
using GameMissions.Core.Services;

namespace GameMissions.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();

    builder.RegisterType<AddGameService>().As<IAddGameService>().InstancePerLifetimeScope();
    builder.RegisterType<UpdateGameService>().As<IUpdateGameService>().InstancePerLifetimeScope();
    builder.RegisterType<GameSearchService>().As<IGameSearchService>().InstancePerLifetimeScope();
    builder.RegisterType<DeleteGameService>().As<IDeleteGameService>().InstancePerLifetimeScope();
  }
}
