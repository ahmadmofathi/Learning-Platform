using Acedify.Web.BL;
using Acedify.Web.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost",
                "http://localhost:4200",
                "https://localhost:7230",
                "https://localhost:5173",
                "http://localhost:5173",
                "http://localhost:90"
                )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

//context registration 
builder.Services.AddIdentity<User, IdentityRole<string>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
// Register services
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IAdminManager, AdminManager>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ICodeRepo, CodeRepo>();
builder.Services.AddScoped<ICodeManager, CodeManager>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
builder.Services.AddScoped<IEnrollmentManager, EnrollmentManager>();
builder.Services.AddScoped<IHomeworkRepo, HomeworkRepo>();
builder.Services.AddScoped<IHomeworkManager, HomeworkManager>();
builder.Services.AddScoped<IHwAnswerRepo, HwAnswerRepo>();
builder.Services.AddScoped<IHwAnswerManager, HwAnswerManager>();
builder.Services.AddScoped<IMaterialRepo, MaterialRepo>();
builder.Services.AddScoped<IMaterialManager, MaterialManager>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<IQuestionManager, QuestionManager>();
builder.Services.AddScoped<IQuizRepo, QuizRepo>();
builder.Services.AddScoped<IQuizManager, QuizManager>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<ISubscriptionRequestRepo, SubscriptionRequestRepo>();
builder.Services.AddScoped<ISubscriptionRequestManager, SubscriptionRequestManager>();
builder.Services.AddScoped<ISuperAdminRepo, SuperAdminRepo>();
builder.Services.AddScoped<ISuperAdminManager, SuperAdminManager>();
builder.Services.AddScoped<ITeacherRepo, TeacherRepo>();
builder.Services.AddScoped<ITeacherManager, TeacherManager>();
builder.Services.AddScoped<ITechnicalRepo, TechnicalRepo>();
builder.Services.AddScoped<ITechnicalSupportManager, TechnicalSupportManager>();
builder.Services.AddScoped<IVideoRepo, VideoRepo>();
builder.Services.AddScoped<IVideoManager, VideoManager>();
//JWT Auth
var secretKey = builder.Configuration.GetValue<string>("SecretKey");
var secretKeyBytes = string.IsNullOrEmpty(secretKey) ? null : Encoding.ASCII.GetBytes(secretKey);
var Key = new SymmetricSecurityKey(secretKeyBytes);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        IssuerSigningKey = Key
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
}
    // Enable Swagger UI at /swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();