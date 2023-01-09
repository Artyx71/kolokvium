var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/byte/{kylobyte}", ByteConvert);
app.MapGet("/know/{s}/{r}/{k}", ByteConvert);
app.Run();


string ByteConvert(string byte)
{

    string kylobyte = Convert.ToString(int.Parse(byte) * 1024);
    return $"Байтов: {byte}, Килобайтов: {kylobyte}";
}

string KnowRequest(string s, string r, string k)
{
    return "kkk";
}