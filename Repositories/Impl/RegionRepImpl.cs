using Npgsql;
using percobaan1.Entities;
using percobaan1.Entities;
using percobaan1.Utils;

namespace percobaan1.Repositories.Impl
{
    public class RegionRepImpl
    {
        private DbUtils dbUtil;
        public RegionRepImpl(DbUtils dbUtil)
        {
            this.dbUtil = dbUtil;
        }
        public List<Region> findAll()
        {
            List<Region> regions = new List<Region>();
            string sql = "SELECT * FROM regions";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Region region = new Region();
                    region.id_region = reader.GetInt32(0);
                    region.nama = reader.GetString(1);
                    regions.Add(region);
                }
                cmd.Dispose();
                dbUtil.closeConnection();
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return regions;
        }

        public Region findById(int region_id)
        {
            string sql = "SELECT * FROM regions WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@id", region_id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Region region = new Region();
                    region.id_region = reader.GetInt32(0);
                    region.nama = reader.GetString(1);
                    cmd.Dispose();
                    dbUtil.closeConnection();
                    return region;
                }
                cmd.Dispose();
                dbUtil.closeConnection();
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return null;
        }

        public Region create(Region entity)
        {
            string sql = "INSERT INTO regions (name) VALUES (@name) RETURNING id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@nama", entity.nama);
                entity.id_region = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                dbUtil.closeConnection();
                return entity;
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return null;
        }

        public Region update(Region entity)
        {
            string sql = "UPDATE regions SET name = @name WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@name", entity.nama);
                cmd.Parameters.AddWithValue("@id", entity.id_region);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbUtil.closeConnection();
                return entity;
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return null;
        }

        public Region delete(Region entity)
        {
            string sql = "DELETE FROM regions WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@id", entity.id_region);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbUtil.closeConnection();
                return entity;
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return null;
        }
    }
}
