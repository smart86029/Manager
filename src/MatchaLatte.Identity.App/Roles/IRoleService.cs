﻿using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;

namespace MatchaLatte.Identity.App.Roles
{
    /// <summary>
    /// 角色服務。
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有角色。</returns>
        Task<PaginationResult<RoleSummary>> GetRolesAsync(PaginationOption option);

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        Task<RoleDetail> GetRoleAsync(Guid roleId);

        /// <summary>
        /// 取得新角色。
        /// </summary>
        /// <returns>新角色。</returns>
        Task<RoleDetail> GetNewRoleAsync();

        /// <summary>
        /// 建立角色。
        /// </summary>
        /// <param name="command">建立角色命令。</param>
        /// <returns>角色。</returns>
        Task<RoleDetail> CreateRoleAsync(CreateRoleCommand command);

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="command">更新角色命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateRoleAsync(UpdateRoleCommand command);
    }
}