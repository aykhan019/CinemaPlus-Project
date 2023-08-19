using Cinema.Business.Abstraction;
using Cinema.Business.Abstraction.Extensions;
using Cinema.Business.Concrete;
using Cinema.DataAccess.Abstract;
using Cinema.DataAccess.Concrete.EFEntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IExtendedHallService, HallService>();
builder.Services.AddScoped<IExtendedLanguageService, LanguageService>();
builder.Services.AddScoped<IExtendedMovieService, MovieService>();
builder.Services.AddScoped<IExtendedSeatService, SeatService>();
builder.Services.AddScoped<IExtendedSessionService, SessionService>();
builder.Services.AddScoped<IExtendedSubtitleService, SubtitleService>();
builder.Services.AddScoped<IExtendedTheatreImageService, TheatreImageService>();
builder.Services.AddScoped<IExtendedTheatreService, TheatreService>();
builder.Services.AddScoped<IExtendedTicketService, TicketService>();


builder.Services.AddScoped<IHallDal, EFHallDal>();
builder.Services.AddScoped<ILanguageDal, EFLanguageDal>();
builder.Services.AddScoped<IMovieDal, EFMovieDal>();
builder.Services.AddScoped<ISeatDal, EFSeatDal>();
builder.Services.AddScoped<ISessionDal, EFSessionDal>();
builder.Services.AddScoped<ISubtitleDal, EFSubtitleDal>();
builder.Services.AddScoped<ITheatreImageDal, EFTheatreImageDal>();
builder.Services.AddScoped<ITheatreDal, EFTheatreDal>();
builder.Services.AddScoped<ITicketDal, EFTicketDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
