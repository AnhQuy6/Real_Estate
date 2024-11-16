using Real_App.Interfaces;
using Real_App.Repository;

namespace Real_App.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dc;
    private ICityRepository _cityRepository;

    public UnitOfWork(DataContext dc)
    {
        _dc = dc;
    }


    public ICityRepository CityRepository => 
        new CityRepository(_dc);

    public async Task<bool> SaveAsync()
    {
        return await _dc.SaveChangesAsync() > 0;
    }
    
}