using NHibernate;
using NhEnv = NHibernate.Cfg.Environment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(svc =>
{
    var cfg = new NHibernate.Cfg.Configuration();
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

builder.Services.AddScoped(svc =>
{
    var session = svc.GetRequiredService<ISessionFactory>().OpenSession();
    return session;
});

builder.Services.AddScoped(svc =>
{
    var session = svc.GetRequiredService<ISessionFactory>().OpenStatelessSession();
    return session;
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
