using System.Reflection;
using Application.Services.Account;
using Application.Services.Account.Command;
using Application.Services.Account.Command.Impl;
using Application.Services.Account.Query;
using Application.Services.Account.Query.Impl;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Command.Impl;
using Application.Services.Dictionary.Query;
using Application.Services.Dictionary.Query.Impl;
using Application.Services.UserManager.Command;
using Application.Services.UserManager.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ILocalizationCommandService, LocalizationCommandService>();
        services.AddScoped<ILocalizationQueryService, LocalizationQueryService>();
        services.AddScoped<ISubjectCommandService, SubjectCommandService>();
        services.AddScoped<ISubjectQueryService, SubjectQueryService>();
        services.AddScoped<IQuestionTypeCommandService, QuestionTypeCommandService>();
        services.AddScoped<IQuestionTypeQueryService, QuestionTypeQueryService>();
        services.AddScoped<IQuestionGroupCommandService, QuestionGroupCommandService>();
        services.AddScoped<IQuestionGroupQueryService, QuestionGroupQueryService>();
        services.AddScoped<TokenService>();
        services.AddScoped<IAccountCommandService, AccountCommandService>();
        services.AddScoped<IUserManagerCommandService, UserManagerCommandService>();
        services.AddScoped<IUserManagerQueryService, UserManagerQueryService>();
        services.AddScoped<IAccountQueryService, AccountQueryService>();
        

    }
}