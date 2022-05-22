using WebClient.Models;

namespace WebClient.Services
{
    public interface IRatingService
    {
        public Task<bool> AddAsync(Feedback feedback);

        public Task<bool> Remove(string username);

        public Feedback? GetSpecific(string username);

        public Task<IEnumerable<Feedback>> GetAll(string username);

        public Task Update(Feedback feedback);

        public Task<double> computeAVG();
        public Task<List<Feedback>> searchByNameOrDescription(SearchContent content);
    }
}
