using System;

namespace MenuConfigurator.Model
{
    public static class Endpoints
    {
        public const string BasePrefix = "api";

        public static class Dishes
        {
            public const string Base = BasePrefix +"/dishes";

            public static string GetAll => Base;
            public static string Get(Guid id) => $"{Base}/{id}";
            public static string PostCreate => Base;
            public static string PatchUpdate(Guid id) => $"{Base}/{id}";
            public static string Delete(Guid id) => $"{Base}/{id}";
        }
    }

}