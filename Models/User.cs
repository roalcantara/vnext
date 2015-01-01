using System.ComponentModel.DataAnnotations;

namespace VNext.Models
{
  public class User
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(4)]
    public string Name { get; set; }

    [Required]
    [MinLength(6)]
    public string Username { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }
}