using Real_App.Data.Repository;
using Real_App.Interfaces;
using Real_App.Repository;

namespace Real_App.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dc;

    public UnitOfWork(DataContext dc)
    {
        _dc = dc;
    }
    
    public ICityRepository CityRepository => 
        new CityRepository(_dc);

    public IUserRepository UserRepository => 
        new UserRepository(_dc);

    public IPropertyRepository PropertyRepository =>
        new PropertyRepository(_dc);

    public async Task<bool> SaveAsync()
    {
        return await _dc.SaveChangesAsync() > 0;
    }
    
}