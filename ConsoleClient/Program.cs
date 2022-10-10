// See https://aka.ms/new-console-template for more information
using ConsoleClient;
using System.Net.Http.Headers;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7019");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
HttpResponseMessage response = await client.GetAsync("api/Items");
response.EnsureSuccessStatusCode();
if (response.IsSuccessStatusCode)
{
    var items = await response.Content.ReadFromJsonAsync<IEnumerable<ItemDto>>();
	foreach (var item in items)
	{
		Console.WriteLine(item.Id);
	}
}
else
{
	Console.WriteLine("No results found");
}
Console.ReadLine();

