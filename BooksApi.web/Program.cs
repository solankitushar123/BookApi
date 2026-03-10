// Program.cs
using BooksApi.Persistence;
using BooksApi.Services;
using BooksApi.Web.Endpoints;
using LibraryApi.Services;
using Microsoft.EntityFrameworkCore;
using TestMinimalApi.Web.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<IssueBookservice>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapBookEndpoints();
app.MapMemberEndpoints();
app.MapIssueEndpoints();


RouteGroupBuilder apiGroup = app.MapGroup("api");
apiGroup.MapBookEndpoints();
apiGroup.MapCategoryEndpoints();
apiGroup.MapMemberEndpoints();
apiGroup.MapIssueEndpoints();
app.Run();