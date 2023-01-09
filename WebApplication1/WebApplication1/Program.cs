var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/byte/{bite}", ByteConvert);
app.MapGet("/convertMoney/{money}", MoneyRequest);
app.Run();


string ByteConvert(string bite)
{
    StreamWriter sw = new StreamWriter("./log.txt", true);
    string kylobyte = Convert.ToString(int.Parse(bite) / 1024);
    string megabyte = Convert.ToString(int.Parse(kylobyte) / 1024);
    sw.WriteLine($"Кол-во Байтов:{bite} Килобайтов: {kylobyte}, Мегабайтов: {megabyte}");
    sw.Close();
    return $"Килобайтов: {kylobyte}, Мегабайтов: {megabyte}";
}

string MoneyRequest(string money)
{
    StreamWriter sw = new StreamWriter("./log.txt", true);

    int M = int.Parse(money);

    int A = M % 500;

    int A1 = M / 500;

    int B = A % 100;

    int B1 = A / 100;

    int C = B % 10;

    int C1 = B / 10;

    int D1 = C / 2;
    sw.WriteLine($"Деньги:{M},500: {A1}, 100: {B1}, 10: {C1}, 2: {D1}");
    sw.Close();
    return $"500: {A1}, 100: {B1}, 10: {C1}, 2: {D1}";
}