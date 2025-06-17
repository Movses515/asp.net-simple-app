namespace Demo.Core.Records;

public record UserRecord(string Name, string Surname, string Email);
public record CreateUser(string Name, string Surname, string Email, string Password, string ConfirmPassword);
