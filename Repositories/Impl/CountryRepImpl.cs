using Npgsql;
using percobaan1.Entities;
using percobaan1.Utils;
using System.Diagnostics.Metrics;

namespace percobaan1.Repositories.Impl
{
    public class CountryRepImpl
    {
        private DbUtils dbUtil;
        public CountryRepImpl(DbUtils dbUtil)
        {
            this.dbUtil = dbUtil;
        }

        public List<Country> findAll()
        {
            List<Country> countries = new List<Country>();
            string sql = "SELECT * FROM countries";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country();
                    country.id_country = reader.GetInt32(0);
                    country.nama = reader.GetString(1);
                    countries.Add(country);
                }
                cmd.Dispose();
                dbUtil.closeConnection();
            }
            catch (Exception e)
            {
                dbUtil.closeConnection();
                throw new Exception(e.Message);
            }
            return countries;
        }

        public Country findById(int id)
        {
            string sql = "SELECT * FROM countries WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Country country = new Country();
                    country.id_country = reader.GetInt32(0);
                    country.nama = reader.GetString(1);
                    cmd.Dispose();
                    dbUtil.closeConnection();
                    return country;
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

        public Country create(Country entity)
        {
            string sql = "INSERT INTO countries (nama) VALUES (@nama) RETURNING id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@nama", entity.nama);
                entity.id_country = (int)cmd.ExecuteScalar();
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

        public Country update(Country entity)
        {
            string sql = "UPDATE countries SET nama = @nama WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@nama", entity.nama);
                cmd.Parameters.AddWithValue("@id_country", entity.id_country);
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

        public Country delete(Country entity)
        {
            string sql = "DELETE FROM countries WHERE id = @id";
            try
            {
                NpgsqlCommand cmd = dbUtil.GetNpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("@id", entity.id_country);
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
