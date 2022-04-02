using Syncfusion.Licensing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//Register Syncfusion license
string syncfusionLicensePath = String.Format("{0}\\..\\..\\SyncfusionLicense.txt", Directory.GetCurrentDirectory()); 
if (File.Exists(syncfusionLicensePath))
{
    string licenseKey = File.ReadAllText(syncfusionLicensePath);
    SyncfusionLicenseProvider.RegisterLicense(licenseKey);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
