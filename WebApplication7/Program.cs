using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication7.Models;
using WebApplication7.Repositry.IRepositry;
using WebApplication7.Repositry;

namespace WebApplication7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // test
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DepiContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DepiConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Password.RequireDigit = true
                )
                .AddEntityFrameworkStores<DepiContext>();

            builder.Services.AddScoped<IPlace, Place_Repo>();
            builder.Services.AddScoped<IAdmin, Admin_Repo>();
            builder.Services.AddScoped<IBooking, Booking_Repo>();
            builder.Services.AddScoped<IPayment, Payment_Repo>();
            builder.Services.AddScoped<IReview, Review_Repo>();
            builder.Services.AddScoped<IUser, User_Repo>();
            builder.Services.AddScoped<IPromotion, Promotion_Repo>();
            builder.Services.AddScoped<IWishList, WishList_Repo>();
            builder.Services.AddScoped<ISearch, Search_Repo>();


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
            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}