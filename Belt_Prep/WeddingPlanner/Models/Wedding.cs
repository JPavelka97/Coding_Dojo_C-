#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId {get;set;}

    [Required]
    public string WedderOne {get;set;}

    [Required]
    public string WedderTwo {get;set;}

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime Date {get;set;}

    [Required]
    public string Address {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int CreatorId {get;set;}
    public List<Attendee> Attendees {get;set;} = new List<Attendee>();
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? date, ValidationContext validationContext)
    {
        if(date == null)
        {
            return new ValidationResult("Date must be selected!");
        }
        Console.WriteLine(date);
        Console.WriteLine(DateTime.Today);
        if(DateTime.Compare((DateTime)date, DateTime.Now) < 0)
        {
            return new ValidationResult("Date must be in the future!");
        } else {
            return ValidationResult.Success;
        }
    }
}