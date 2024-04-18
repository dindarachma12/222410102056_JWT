using percobaan1.DTO;
using percobaan1.Entities;
using percobaan1.Repositories.Impl;

namespace percobaan1.Services.Impl
{
    public class CountryService
    {
        private CountryRepImpl countryRepository;
        public CountryService(CountryRepImpl countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public List<Country> findAll()
        {
            return countryRepository.findAll();
        }
        public Country findById(int id)
        {
            Country country = countryRepository.findById(id);
            return country != null ? country : null;
        }
        public Country create(Country entity)
        {
            Country country = new Country();
            country.nama = entity.nama;
            return countryRepository.create(country);
        }
        public Country update(int id, Country entity)
        {
            Country country = new Country();
            country.id_region = id;
            country.nama= entity.nama;
            return countryRepository.update(country);
        }
        public Country delete(int id)
        {
            Country country = new Country();
            country.id_country = id;
            return countryRepository.delete(country);
        }
    }
}
