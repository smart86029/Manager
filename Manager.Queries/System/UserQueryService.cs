using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Manager.App.Queries.System;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.Queries.System
{
    /// <summary>
    /// 使用者查詢服務。
    /// </summary>
    public class UserQueryService : IUserQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="UserQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public UserQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有使用者。</returns>
        public async Task<PaginationResult<UserSummary>> GetUsersAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT UserId, UserName, IsEnabled
                FROM [System].[User]
                ORDER BY UserId
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY";
            var param = new
            {
                Skip = (option.PageIndex - 1) * option.PageSize,
                Take = option.PageSize
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var users = await connection.QueryAsync<UserSummary>(sql, param);
                var result = new PaginationResult<UserSummary>
                {
                    Items = users.AsList(),
                    ItemCount = 100
                };

                return result;
            }
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        public async Task<User> GetUserAsync(int userId)
        {
            var sql = $@"
				SELECT u1.UserId, u1.UserName, u1.IsEnabled, u1.RoleId, u1.Name, ISNULL(x.IsChecked, 0) AS IsChecked
				FROM (
					SELECT u.UserId, u.UserName, u.IsEnabled, r.RoleId, r.Name
					FROM (
						SELECT UserId, UserName, IsEnabled
						FROM [System].[User]
						WHERE UserId = @UserId
					) AS u
					CROSS JOIN (
                        SELECT RoleId, Name
                        FROM [System].[Role]
                        WHERE IsEnabled = 1
                    ) AS r
				) AS u1
				LEFT JOIN (
					SELECT UserId, RoleId, 1 AS IsChecked
					FROM [System].[UserRole]
					WHERE UserId = @UserId
				) AS x ON u1.UserId = x.UserId AND u1.RoleId = x.RoleId";
            var param = new { UserId = userId };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var users = new Dictionary<int, User>();
                var result = await connection.QueryAsync<User, User.Role, User>(sql, (u, r) =>
                {
                    if (!users.TryGetValue(u.UserId, out User user))
                    {
                        user = u;
                        users.Add(u.UserId, u);
                    }

                    user.Roles.Add(r);

                    return user;
                }, param, splitOn: nameof(User.Role.RoleId));

                return result.First();
            }
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        public async Task<User> GetNewUserAsync()
        {
            var sql = $@"
                SELECT RoleId, Name
                FROM [System].[Role]
                WHERE IsEnabled = 1";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var roles = await connection.QueryAsync<User.Role>(sql);
                var result = new User
                {
                    Roles = roles.ToList()
                };

                return result;
            }
        }
    }
}