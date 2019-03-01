using System;
using System.Data;
using PartnerGroup.Domain.Entities;

namespace PartnerGroup.Domain.Converters
{
    public static class BrandConvert
    {
        public static BrandEntity ToBrandEntity(this IDataReader reader)
        {
            var brand = new BrandEntity((long)reader["Id"],
                        (string)reader["Brand"],
                        (DateTime)reader["DateRegister"],
                         reader.IsDBNull(reader.GetOrdinal("DateChange")) ? null : (DateTime?)reader["DateChange"],
                        (bool)reader["Active"]);

            return brand;
        }
    }
}
