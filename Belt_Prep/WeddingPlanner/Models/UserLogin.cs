#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class UserLogin
{
    [Required]
    public string EmailLogin {get;set;}

    [Required]
    [DataType(DataType.Password)]
    public string PasswordLogin {get;set;}
}