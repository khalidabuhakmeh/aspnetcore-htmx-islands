var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddOutputCache();
builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseResponseCaching();
app.UseOutputCache();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.MapGet("/profile/avatar", () => Results.Content(
    //lang=html
    $"""
     <div class="alert alert-info">
        <p class="fs-1 fw-bold">🌴 Welcome to the island Khalid!</p>
        <p class="fs-3">You arrived on ({DateTime.Now.ToLongTimeString()})</p>
     </div>
     """))
    .CacheOutput(policy => { /* apply caching policy here */ });

app.Run();