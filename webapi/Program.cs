using InterviewParser.Core;
using InterviewParser.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "localhost",
            policy =>
            {
                policy.WithOrigins("http://localhost:3000");
            });
    });

builder.AddSemanticKernel();
builder.AddAIService();

var app = builder.Build();

app.AddResultVerification();
app.AddInterviewRoutes();
app.UseCors();

app.Run();
