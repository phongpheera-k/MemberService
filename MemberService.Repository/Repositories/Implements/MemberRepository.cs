using MemberService.Repository.Repositories.Interfaces;

namespace MemberService.Repository.Repositories.Implements
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMongoCollection<MemberAccount> _members;

        public MemberRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(new MongoUrl(connectionString).DatabaseName);

            _members = database.GetCollection<MemberAccount>("Members");
        }

        public async Task<MemberAccount?> GetMember(string id) 
            => await _members.Find(member => member.Id == id)
                .FirstOrDefaultAsync();

        public async Task<MemberAccount> CreateMember(MemberAccount memberAccount)
        {
            await _members.InsertOneAsync(memberAccount);
            return memberAccount;
        }
    }
}