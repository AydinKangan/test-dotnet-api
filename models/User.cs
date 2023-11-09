public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    // public Address Address { get; set; }
    // public string? Phone { get; set; }
    // public string? Website { get; set; }
    // public Company Company { get; set; }

    public User()
    {
        // Address = new Address();
        // Company = new Company();
    }

    public User(int id, string name, string username, string email, Address address, string phone, string website, Company company)
    {
        Id = id;
        Name = name;
        Username = username;
        Email = email;
        // Address = address;
        // Phone = phone;
        // Website = website;
        // Company = company;
    }
}

public class Address
{
    public string? Street { get; set; }
    public string? Suite { get; set; }
    public string? City { get; set; }
    public string? Zipcode { get; set; }
    public Geo Geo { get; set; }

    public Address()
    {
        Geo = new Geo();
    }
}

public class Geo
{
    public string? Lat { get; set; }
    public string? Lng { get; set; }
}

public class Company
{
    public string? Name { get; set; }
    public string? CatchPhrase { get; set; }
    public string? Bs { get; set; }
}
