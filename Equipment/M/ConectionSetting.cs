using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Equipment.M
{
    public enum ServerType {relise, test, home }
    public enum DbType { app, main}

    public static class ConectionSetting
    {
         static ServerType CurServerType
        {
            get => ServerType.home;
        }

        static Dictionary<string, string> con_list = new Dictionary<string, string>()
        {
            ["relise"] = "192.168.1.29",
            ["test"] ="192.168.3.196",
            ["home"] = "localhost"
        };

        static Dictionary<string, string> db_con_list = new Dictionary<string, string>()
        {
            ["app"] = "Eq_test",
            ["main"] = "entity_test2"
        };

        public static string ConString(ServerType serverType, DbType appType)
        {
            string tmp_server = con_list.First(x=>x.Key == serverType.ToString()).Key;
            string tmp_db= db_con_list.First(x => x.Key == appType.ToString()).Key;
            return string.Format($"server = {tmp_server}; database = {tmp_db}; uid = root; pwd = root;");
        }

        public static string GetServer()
        {
            return con_list[CurServerType.ToString()];
        }
        public static string GetDb(DbType appType)
        {
            return db_con_list[appType.ToString()];
        }
    }
}
