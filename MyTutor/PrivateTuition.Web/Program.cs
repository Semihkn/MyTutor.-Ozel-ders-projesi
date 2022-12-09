using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Business.Concrete;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Web.Identity;


var builder = WebApplication.CreateBuilder(args);

var sqliteConnection = builder.Configuration.GetConnectionString("SqliteCon");

builder.Services.AddDbContext<MyIdentityContext>(options => options.UseSqlite(sqliteConnection));
builder.Services.AddIdentity<MyIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(500);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".PrivateTuition.Security.Cookie"
    };

});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<PrivateTuitionContext>(options => options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<IShowCardRepository, EfCoreShowCardRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ISubjectRepository, EfCoreSubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, EfCoreTeacherRepository>();
builder.Services.AddScoped<ILessonRequestRepository, EfCoreLessonRequestRepository>();
builder.Services.AddScoped<IStudentRepository, EfCoreStudentRepository>();

builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IShowCardService, ShowCardManager>();
builder.Services.AddScoped<ISubjectService, SubjectManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ILessonRequestService, LessonRequestManager>();

builder.Services.AddScoped<ICitiesRepository,EFCoreCitiesRepository>();
builder.Services.AddScoped<IDistrictRepository, EFCoreDistrictRepository>();
builder.Services.AddScoped<ICitiesService,CitiesManager>();
builder.Services.AddScoped<IDistrictService, DistrictManager>();

//unit of work design patern

builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddControllers();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "deleteShowcard",
//    pattern: "admin/deleteshowcard/{id}",
//    defaults: new { controller = "Teacher", action = "ShowCardDelete" }
//);

//app.MapControllerRoute(
//    name: "ListShowCard",
//    pattern: "teacher/showcardlist",
//    defaults: new { controller = "Teacher", action = "ShowCardList" }
//);

//app.MapControllerRoute(
//    name: "EditShowCard",
//    pattern: "teacher/edit/{id}",
//    defaults: new { controller = "Teacher", action = "ShowCardEdit" }
//);



app.MapControllerRoute(
    name: "advanceSearch",
    pattern: "advanceSearch",
    defaults: new { controller = "PrivateTuition", action = "AdvanceSearch" });

app.MapControllerRoute(
    name: "search",
    pattern: "search",
    defaults: new { controller = "PrivateTuition", action = "Search" }
);
app.MapControllerRoute(
    name: "ShowCardsbyCategory",
    pattern: "showCards/subjects/{category?}",
    defaults: new { controller = "PrivateTuition", action = "ListByCategory" });

//  );

//app.MapControllerRoute(
//    name: "ShowCardsbySubject",
//    defaults: new { controller = "Home", action = "Index" },
//    pattern: "showCards/subjects/categories/{category?}"
//    );
app.MapControllerRoute(
    name: "showCardsList",
    pattern: "showCards/{category?}",
    defaults: new { controller = "PrivateTuition", action = "List" }
);

app.MapControllerRoute(
    name: "teachersList",
    pattern: "teachersList/{category?}",
    defaults: new { controller = "PrivateTuition", action = "TeacherList" }
);

app.MapControllerRoute(
    name: "showCardsByCategory",
    defaults: new { controller = "Home", action = "ShowCardList" },
    pattern: "showCards/categories/{category?}"
    );


app.MapControllerRoute(
    name: "details",
    pattern: "showCard/{url}",
    defaults: new { controller = "PrivateTuition", action = "Details" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

