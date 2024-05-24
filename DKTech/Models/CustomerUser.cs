using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class CustomerUser
    {
    }
}
public int CustomerUserID { get; set; }
public string LastName { get; set; }
public string FirstMidName { get; set; }
[DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
public DateTime OrdersDate { get; set; }

public ICollection<Orders> Orders { get; set; }
    }
}
 