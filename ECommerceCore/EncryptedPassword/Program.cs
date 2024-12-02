using BCrypt.Net;
// Example password
string password = "transflower";

// Hash the password with bcrypt
string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

// Output the hashed password
Console.WriteLine($"Password: {password}");

Console.WriteLine($"Hashed Password: {hashedPassword}");
//password = "dfsdfsdf";
if (hashedPassword != null && BCrypt.Net.BCrypt.Verify(password, hashedPassword))
{
    Console.WriteLine("Password is correct.");
}
else
{
    Console.WriteLine("Invalid password.");
}