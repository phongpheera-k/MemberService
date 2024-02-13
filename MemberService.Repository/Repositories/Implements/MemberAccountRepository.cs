using MemberService.Repository.Repositories.Interfaces;

namespace MemberService.Repository.Repositories.Implements
{
    public class MemberAccountRepository : IMemberAccountRepository
    {
        private readonly IMongoCollection<MemberAccount> _members;

        public MemberAccountRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(new MongoUrl(connectionString).DatabaseName);

            _members = database.GetCollection<MemberAccount>("MemberAccount");
        }

        public async Task<MemberAccount?> GetMember(Guid id) 
            => await _members.Find(member => member.Id == id)
                .FirstOrDefaultAsync();

        public async Task<MemberAccount> CreateMember(MemberAccount memberAccount)
        {
            await _members.InsertOneAsync(memberAccount);
            return memberAccount;
        }
    }
}