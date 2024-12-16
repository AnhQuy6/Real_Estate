using System.ComponentModel.DataAnnotations;

namespace Real_App.Model;

public class City : BaseEntity
{

    public string Name { get; set; }
    public string  Country { get; set; }

}