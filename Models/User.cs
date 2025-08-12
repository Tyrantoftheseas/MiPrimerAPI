// Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string First_Name { get; set; } = string.Empty;
    public string Last_Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}

// Models/UserResponse.cs
public class UserResponse
{
    public int Page { get; set; }
    public int Per_Page { get; set; }
    public int Total { get; set; }
    public int Total_Pages { get; set; }
    public List<User> Data { get; set; } = new List<User>();
}