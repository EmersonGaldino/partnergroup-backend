namespace PartnerGroup.Domain.Queries
{
    public static class PatrimonyQuery
    {
        public const string PatrimonyByBrandId = "SELECT " +
                                                    "P.[Id] 'P_Id', " +
                                                    "P.[BrandId] 'P_BrandId', " +
                                                    "P.[Patrimony] 'P_Patrimony', " +
                                                    "P.[Description] 'P_Description', " +
                                                    "P.[NumberTumble] 'P_NumberTumble', " +
                                                    "P.[DateRegister] 'P_DateRegister', " +
                                                    "P.[DateChange] 'P_DateChange', " +
                                                    "P.[Active] 'P_Active', " +
                                                    "B.[Id] 'B_Id', " +
                                                    "B.[Brand] 'B_Brand', " +
                                                    "B.[DateRegister] 'B_DateRegister', " +
                                                    "B.[DateChange] 'B_DateChange', " +
                                                    "B.[Active] 'B_Active' " +
                                                "FROM dbo.Patrimony(NOLOCK) P INNER JOIN dbo.Brand(NOLOCK) B ON B.Id = P.BrandId WHERE P.BrandId = @BranchId";

        public const string PatrimonyById = "SELECT " +
                                                "P.[Id] 'P_Id', " +
                                                "P.[BrandId] 'P_BrandId', " +
                                                "P.[Patrimony] 'P_Patrimony', " +
                                                "P.[Description] 'P_Description', " +
                                                "P.[NumberTumble] 'P_NumberTumble', " +
                                                "P.[DateRegister] 'P_DateRegister', " +
                                                "P.[DateChange] 'P_DateChange', " +
                                                "P.[Active] 'P_Active', " +
                                                "B.[Id] 'B_Id', " +
                                                "B.[Brand] 'B_Brand', " +
                                                "B.[DateRegister] 'B_DateRegister', " +
                                                "B.[DateChange] 'B_DateChange', " +
                                                "B.[Active] 'B_Active' " +
                                            "FROM dbo.Patrimony(NOLOCK) P INNER JOIN dbo.Brand(NOLOCK) B ON B.Id = P.BrandId WHERE P.Id = @Id";

        public const string Patrimonies = "SELECT " +
                                            "P.[Id] 'P_Id', " +
                                            "P.[BrandId] 'P_BrandId', " +
                                            "P.[Patrimony] 'P_Patrimony', " +
                                            "P.[Description] 'P_Description', " +
                                            "P.[NumberTumble] 'P_NumberTumble', " +
                                            "P.[DateRegister] 'P_DateRegister', " +
                                            "P.[DateChange] 'P_DateChange', " +
                                            "P.[Active] 'P_Active', " +
                                            "B.[Id] 'B_Id', " +
                                            "B.[Brand] 'B_Brand', " +
                                            "B.[DateRegister] 'B_DateRegister', " +
                                            "B.[DateChange] 'B_DateChange', " +
                                            "B.[Active] 'B_Active' " +
                                          "FROM dbo.Patrimony(NOLOCK) P INNER JOIN dbo.Brand(NOLOCK) B ON B.Id = P.BrandId";
    }
}
