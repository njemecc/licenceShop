using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

[Collection("cars")]
public class Car : BaseEntity
{

    #region Properties

    [Field("name")]
    public string Name { get; set; }
    
    [Field("year_production")]
    public int YearProduction { get;  set; }
    
    [Field("vendor")]
    public One<Vendor> Vendor { get; set; }
    
    // [Field("users")]
    // public Many<ApplicationUser> Users {get; set;}
    //
    // [Field("other_users")]
    // [OwnerSide]
    // public Many<ApplicationUser> OtherUsers { set; get; }
    //
    public List<ApplicationUser> Users { set; get; }
    
    public List<ApplicationUser> OtherUsers { get; set; }

    #endregion
    

    #region Constructors
    public Car()
    {
        // this.InitOneToMany(() => Users);
        // this.InitManyToMany(() => OtherUsers, user => user.Cars);
    }
    
    #endregion

    #region Methods(FAKE Extensions)

    public Car AddYearProduction(int yearProduction)
    {
        YearProduction = yearProduction;
        return this;
    }
    
    public Car AddVendor(One<Vendor> vendor)
    {
        Vendor = vendor;
        return this;
    }

    public Car AddActive(bool active)
    {
        Active = active;
        return this;
    }


    // public Car AddUsers(Many<ApplicationUser> users)
    // {
    //     Users = users;
    //     return this;
    // }
    

    #endregion

   
}