using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Model;

public class Product
{
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Typen skal være mellem 2 og 50 tegn.")]
    public string? Type { get; set; }

    [Required]
    public string? Størrelse { get; set; }

    [Required]
    public string? Description { get; set; }

    public bool ErLedig { get; set; }

}
    
