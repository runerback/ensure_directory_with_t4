using Mono.TextTemplating;

var generator = new TemplateGenerator();

var session = generator.GetOrCreateSession();

var output = $"AutoGen/{Guid.NewGuid():N}/demo";

session["output"] = Path.GetDirectoryName(output);

foreach (var item in Enumerable.Range(0, 2))
{
    session["throwError"] = item > 0;

    if (!await generator.ProcessTemplateAsync("template.tt", $"{output}_{item}"))
    {
        foreach (var error in generator.Errors)
        {
            Console.WriteLine($"error: {error}");
        }
    }
}