namespace MemberService.Repository.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMongoCollection<Member> _members;

        public MemberRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(new MongoUrl(connectionString).DatabaseName);

            _members = database.GetCollection<Member>("Members");
        }

        public async Task<Member> GetMember(string id) 
            => await _members.Find(member => member.Id == id)
                .FirstOrDefaultAsync();

        public async Task<Member> CreateMember(Member member)
        {
            await _members.InsertOneAsync(member);
            return member;
        }
    }
}