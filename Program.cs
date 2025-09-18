var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Si vas a usar Entity Framework y una base de datos, agrega esto:
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Si vas a usar sesiones (útil para el carrito de compras)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Esto es importante para servir archivos estáticos (CSS, JS, imágenes)

app.UseRouting();

app.UseAuthorization();

// Si agregaste sesiones, habilítalas
app.UseSession();

// Esta línea que tienes (MapStaticAssets) no es estándar en ASP.NET Core
// Si es parte de un paquete específico, déjala, sino coméntala o elimínala
// app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Si necesitas áreas (para una sección de administración en el futuro)
// app.MapControllerRoute(
//     name: "areas",
//     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();