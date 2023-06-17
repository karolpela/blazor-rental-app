using RentalApp.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RentalAppContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Rental Shop API";
        // document.Info.Description = "Local Web API for Rental Shop";
        // document.Info.TermsOfService = "None";
        // document.Info.Contact = new NSwag.OpenApiContact
        // {
        //     Name = "Shayne Boyer",
        //     Email = string.Empty,
        //     Url = "https://twitter.com/spboyer"
        // };
        // document.Info.License = new NSwag.OpenApiLicense
        // {
        //     Name = "Use under LICX",
        //     Url = "https://example.com/license"
        // };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseOpenApi();
app.UseSwaggerUi3();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();