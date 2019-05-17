using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using UC.ASP.TaskManager.BL.Facades;
using UC.ASP.TaskManager.BL.Queries;
using UC.ASP.TaskManager.BL.Repositories;
using UC.ASP.TaskManager.BL.UnitOfWork;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.BL.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        { 
            container.Register(
                // properties of type IRepository are implemented by default implementation from Base
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(RepositoryBase<>))
                    .IsFallback()
                    .LifestyleTransient(),
                Component.For<IUnitOfWorkProvider>()
                    .ImplementedBy<UnitOfWorkProvider>()
                    .LifestyleSingleton(),
                Component.For<AppDbContext>()
                    .Forward<DbContext>()
                    .LifestyleTransient(),
                // repositories inherited from IRepository with self implementation
                Classes.FromAssemblyContaining<DataAccessInstaller>()
                    .BasedOn(typeof(IRepository<>))
                    .OrBasedOn(typeof(IQuery<>))
                    .OrBasedOn(typeof(IFacade))
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
        }
    }
}