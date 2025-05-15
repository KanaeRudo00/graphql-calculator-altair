using CalculatorGraphQLApi.GraphQL;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8081); // Chỉ HTTP
                               // Xoá hoặc ẩn dòng options.ListenAnyIP(8081, listenOptions => listenOptions.UseHttps())
    options.ListenAnyIP(8082);
});
// 1️⃣ Register your query/type services
builder.Services
    .AddSingleton<CalculatorQuery>()
    .AddSingleton<OperationResultType>()
    .AddSingleton<ISchema, CalculatorSchema>(sp =>
        new CalculatorSchema(new SelfActivatingServiceProvider(sp)));

// 2️⃣ Configure GraphQL middleware & execution
builder.Services.AddGraphQL(gqlBuilder => gqlBuilder
    // Replace EnableMetrics/UnhandledExceptionDelegate with ConfigureExecution
    .ConfigureExecution((execOpts, next) =>
    {
        execOpts.EnableMetrics = false;      // toggle field‐level metrics :contentReference[oaicite:0]{index=0}
        return next(execOpts);
    })
    .AddSystemTextJson()                      // System.Text.Json serialization :contentReference[oaicite:2]{index=2}
    .AddGraphTypes()                          // auto‐register your ObjectGraphTypes :contentReference[oaicite:3]{index=3}
);

var app = builder.Build();

// 3️⃣ Set up the HTTP pipeline
app.UseRouting();
app.UseWebSockets();

// 4️⃣ Map the GraphQL endpoint
app.UseGraphQL<ISchema>("/graphql");         // GraphQL over HTTP & WebSockets :contentReference[oaicite:4]{index=4}

// 5️⃣ (Optional) Expose the Altair in-browser IDE
app.UseGraphQLAltair("/ui/altair");           // Altair UI middleware :contentReference[oaicite:5]{index=5}

app.Run();