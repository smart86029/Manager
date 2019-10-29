using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Notification.App.Members;
using MatchaLatte.Notification.Domain.Members;

namespace MatchaLatte.Notification.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
        }

        public async Task<ICollection<MemberDetail>> GetMembersAsync()
        {
            var members = await memberRepository.GetMembersAsync();
            var result = members
                .Select(m => new MemberDetail
                {
                    Id = m.Id,
                    DisplayName = m.DisplayName,
                })
                .ToList();

            return result;
        }

        public async Task CreateMemberAsync(CreateMemberCommand command)
        {
            var member = new Member(command.UserId, command.DisplayName);

            await memberRepository.AddAsync(member);
        }
    }
}