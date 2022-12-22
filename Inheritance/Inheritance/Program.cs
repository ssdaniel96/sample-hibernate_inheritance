using Inheritance.Entities;
using NHibernate;
using NhEnv = NHibernate.Cfg.Environment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(svc =>
{
    var cfg = new NHibernate.Cfg.Configuration();
    cfg.Properties[NhEnv.Dialect] = typeof(NHibernate.Dialect.MsSql2008Dialect).AssemblyQualifiedName;
    cfg.Properties[NhEnv.ConnectionProvider] =
        typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName;
    cfg.Properties[NhEnv.ConnectionString] = builder.Configuration.GetConnectionString("Default");
    cfg.Properties[NhEnv.MaxFetchDepth] = 24.ToString();
    cfg.Properties[NhEnv.PrepareSql] = false.ToString();
    cfg.Properties[NhEnv.ShowSql] = true.ToString();
    cfg.Properties[NhEnv.GenerateStatistics] = true.ToString();
    cfg.Properties[NhEnv.CommandTimeout] = "90";
    cfg.AddAssembly(typeof(Program).Assembly);

    var factory = cfg.BuildSessionFactory();
    return factory;
});

builder.Services.AddSingleton(svc =>
{
    var session = svc.GetRequiredService<ISessionFactory>().OpenSession();
    return session;
});

builder.Services.AddSingleton(svc =>
{
    var session = svc.GetRequiredService<ISessionFactory>().OpenStatelessSession();
    return session;
});


var app = builder.Build();

app.MapGet("/", () =>
{
    var dbSession = app.Services.GetRequiredService<NHibernate.ISession>();

    var query = dbSession.Query<Person>();

    var list = query.ToList();

    return list;
});

app.Run();
