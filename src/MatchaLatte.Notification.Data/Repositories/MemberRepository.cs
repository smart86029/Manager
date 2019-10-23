using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Notification.Domain.Members;
using MongoDB.Driver;

namespace MatchaLatte.Notification.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Member> members;

        public MemberRepository(IMongoDatabase database)
        {
            members = database.GetCollection<Member>("member");
        }

        public Task<ICollection<Member>> GetMembersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Member member)
        {
            await members.InsertOneAsync(member);
        }
    }
}