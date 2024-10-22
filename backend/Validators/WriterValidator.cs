using System.Net.Mail;

public static class WriterValidator 
{
  // Validate function ensures that a writer object is well supplied
  // and returns an empty dictionary. Otherwise, it returns the di-
  // ctionary filled with the related invalid data inputs.
  public static Dictionary<string, string> Validate(Models.Writer w)
  {
    var errors = new Dictionary<string, string>();
    if (w.Username.Length < 6) errors["username"] = "Username must contain at least 6 characters.";
    if (w.Password.Length < 8) errors["password"] = "Password must contain at least 8 characters";
    if (w.DisplayName.Length < 3) errors["display_name"] = "DisplayName must contain at least 3 characters";
    if (w.Email != null && !IsEmailValid(w.Email)) errors["email"] = "Ensure that the email is valid.";
    return errors;
  }

  private static bool IsEmailValid(string emailaddress)
  {
    try
    {
      MailAddress m = new MailAddress(emailaddress);
      return true;
    }
    catch (FormatException)
    {
      return false;
    }
  }
}
