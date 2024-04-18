using percobaan1.Entities;
using percobaan1.Repositories;
using percobaan1.Repositories.Impl;
public class RegionService
    {
    private RegionRepImpl regionRepository;
    public RegionService(RegionRepImpl regionRepository)
    {
        this.regionRepository = regionRepository;
    }
    public List<Region> findAll()
    {
        return regionRepository.findAll();
    }
    public Region findById(int id)
    {
        Region region = regionRepository.findById(id);
        return region != null ? region : null;
    }
    public Region create(Region entity)
    {
        Region region = new Region();
        region.nama = entity.nama;
        return regionRepository.create(region);
    }
    public Region update(int id, Region entity)
    {
        Region region = new Region();
        region.id_region = id;
        region.nama = entity.nama;
        return regionRepository.update(region);
    }
    public Region delete(int id)
    {
        Region region = new Region();
        region.id_region = id;
        return regionRepository.delete(region);
    }
}
