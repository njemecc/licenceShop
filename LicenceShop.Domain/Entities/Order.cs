using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

[Collection("orders")]
public class Order : BaseEntity
{
    
    //enums : Pending | Rejected | Approved
    
    #region Properties
    
    [Field("order_code")]
    public long OrderCode { get; set; }
    
    [Field("customer")]
    public ApplicationUser Customer { get; set; }
    
    [Field("licences")]
    public  List<Licence> Licences { get; set; }
    
    [Field("total_price")]
    public double TotalPrice { get; set; }
    
    [Field("status")]
    public string Status { get; set; }
    
    #endregion

    #region Constructors

    public Order()
    {
    }

    #endregion

    #region Methods

    // public Order AddStatus(Enum status)
    // {
    //     Status = status;
    //     return this;
    // }


    public Order AddTotalPrice()
    {
        TotalPrice = this.Licences.Sum(licence => licence.Price);
        return this;
    }

    #endregion
    
}