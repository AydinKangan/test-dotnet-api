HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/users-string", () => GetUsersAsString());
app.MapGet("/users-json", () => GetUsersAsJson());
app.MapGet("/user/{id}", (int id) => GetUserJson(id));
app.MapPost("/add-user", (User user) => AddUserJson(user));

app.Run();

async Task<string> GetUsersAsString()
{
    var response = await client.GetAsync(client.BaseAddress);
    response.EnsureSuccessStatusCode();
    var responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
}

async Task<List<User>?> GetUsersAsJson()
{
    var response = await client.GetFromJsonAsync<List<User>>(client.BaseAddress);
    return response;
}

async Task<User?> GetUserJson(int id)
{
    List<User>? users = await client.GetFromJsonAsync<List<User>>(client.BaseAddress);

    User? selectedUser = null;

    if (users != null && users.Count > 0)
    {
        foreach (User user in users)
        {
            if (user.Id == id)
            {
                selectedUser = user;
                break;
            }
        }
    }

    return selectedUser;
}

async Task<User?> AddUserJson(User newUser)
{
    HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, newUser);

    if (response.IsSuccessStatusCode)
    {
        return newUser;
    }

    return null;
}
