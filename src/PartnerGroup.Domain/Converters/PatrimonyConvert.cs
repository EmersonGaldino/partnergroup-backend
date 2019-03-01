using System;
using System.Data;
using PartnerGroup.Domain.Entities;

namespace PartnerGroup.Domain.Converters
{
    public static class PatrimonyConvert
    {
        public static PatrimonyEntity ToPatrimonyEntity(this IDataReader reader)
        {
            var brand = new BrandEntity((long)reader["B_Id"],
                                        (string)reader["B_Brand"],
                                        (DateTime)reader["B_DateRegister"],
                                        reader.IsDBNull(reader.GetOrdinal("B_DateChange")) ? null : (DateTime?)reader["B_DateChange"],
                                        (bool)reader["B_Active"]);

            var patrimony = new PatrimonyEntity(brand,
                                               (long)reader["P_Id"],
                                               (long)reader["P_BrandId"],
                                               (string)reader["P_Patrimony"],
                                               (string)reader["P_Description"],
                                               (string)reader["P_NumberTumble"],
                                               (DateTime)reader["P_DateRegister"],
                                               reader.IsDBNull(reader.GetOrdinal("P_DateChange")) ? null : (DateTime?)reader["P_DateChange"],
                                               (bool)reader["P_Active"]);
            return patrimony;
        }
    }
}