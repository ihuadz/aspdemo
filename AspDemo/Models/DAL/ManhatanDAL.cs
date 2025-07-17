using System.Data;
using AspDemo.Models.Dto;
using AspDemo.Models.Entities;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AspDemo.Models.DAL
{
    /// <summary>
    /// Manhatan 数据访问层
    /// </summary>
    public class ManhatanDAL
    {
        private string connString = "Data Source=db/test.db";

        public List<User> GetDataNoOrm()
        {
            var sql = "SELECT * FROM user";
            var users = new List<User>();
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                using (var command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // 添加这个循环来遍历所有行
                        {
                            var user = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public List<User> GetDataWithOrm()
        {
            using (IDbConnection db = new SqliteConnection(connString))
            {
                var sql = "SELECT * FROM user";
                return db.Query<User>(sql).AsList();
            }
        }

        public List<A_G> GetManhatan()
        {
            using (IDbConnection db = new SqliteConnection(connString))
            {
                var sql = "SELECT * FROM A_G";
                return db.Query<A_G>(sql).AsList();
            }
        }

        public PageResult<A_G> GetPageTabeData(PageInput<GWASListIn> input)
        {
            int offset = (input.PageNumber - 1) * input.PageSize;
            using (IDbConnection db = new SqliteConnection(connString))
            {
                string countSql = "SELECT COUNT(*) FROM A_G";
                string dataSql = "SELECT * FROM A_G";
                var parameters = new DynamicParameters();
                var whereClauses = new List<string>();

                // 添加模糊查询条件
                if (!string.IsNullOrWhiteSpace(input.Filter?.GeneName))
                {
                    whereClauses.Add("Gene_name LIKE @GeneName");
                    parameters.Add("GeneName", $"%{input.Filter.GeneName}%"); // 模糊匹配
                }

                // 拼接 WHERE 子句（如果有）
                if (whereClauses.Count > 0)
                {
                    string whereClause = " WHERE " + string.Join(" AND ", whereClauses);
                    countSql += whereClause;
                    dataSql += whereClause;
                }

                // 添加分页语句
                dataSql += " LIMIT @PageSize OFFSET @Offset";
                parameters.Add("PageSize", input.PageSize);
                parameters.Add("Offset", offset);

                // 执行查询
                int totalCount = db.ExecuteScalar<int>(countSql, parameters);
                var list = db.Query<A_G>(dataSql, parameters).AsList();

                return new PageResult<A_G>(list, totalCount);
            }
        }
    }
}
