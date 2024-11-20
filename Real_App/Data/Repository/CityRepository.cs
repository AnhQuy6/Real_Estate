using Microsoft.EntityFrameworkCore;
using Real_App.Data;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Repository;

public class CityRepository : ICityRepository
{
    private readonly DataContext _dc;
    public CityRepository(DataContext dc)
    {
        _dc = dc;
    }
    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await _dc.Cities.ToListAsync();
    }

    public void AddCity(City city)
    {
        _dc.Cities.Add(city);
    }
 
    public void DeleteCity(int id)
    {
        var city = _dc.Cities.Find(id);
        _dc.Cities.Remove(city);
    }

    public async Task<City> FindCity(int id)
    {
        return await _dc.Cities.Where(s=>s.Id == id).FirstOrDefaultAsync();
    }
}