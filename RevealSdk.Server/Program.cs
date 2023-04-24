using Reveal.Sdk;
using RevealSdk.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddReveal(); 

//(builder =>
//{
//    builder
//        //.AddObjectEncoder<DataEncoder>()
//        //.AddAuthenticationProvider<AuthenticationProvider>() 
//        //.AddSettings(settings =>
//        //    {
//        //        settings.License = "SMH00XXXA87002002482396134-8654091020";
//        //    });
//        //.AddObjectFilter<ServerSideFiltering>() 
//        //.AddDataSourceProvider<DataSourceProvider>()
//        //.AddUserContextProvider<UserContextProvider>();
//    ;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
      builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
