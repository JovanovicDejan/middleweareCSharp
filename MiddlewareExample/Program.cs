using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();
app.UseMyCustomMiddleware();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from middleware 1 \n");
    await next(context);
});




//Middleware 2
//Hiding method 
//app.UseMiddleware<MyCustomMiddleware>();

//app.UseMyCustomMiddleware();

app.UseHelloCustomMiddle();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again from middleware 3 \n");
});

app.Run();