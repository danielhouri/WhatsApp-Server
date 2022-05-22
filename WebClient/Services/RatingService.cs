using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebClient.Data;
using WebClient.Models;

namespace WebClient.Services
{
    public class RatingService : IRatingService
    {
        private readonly WebClientContext _context;

        public RatingService(WebClientContext Context)
        {
            _context = Context;
        }



        public async Task<bool> AddAsync(Feedback feedback)
        {
            if (GetSpecific(feedback.username) == null)
            {
                feedback.time = DateTime.Now;
                try
                {
                    await _context.Feedback.AddAsync(feedback);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionHandlerExtensions(ex);
                }
            }
            return false;
        }

        private void ExceptionHandlerExtensions(Exception ex)
        {
            throw new NotImplementedException();
        }

        public Feedback? GetSpecific(string username)
        {
            return _context.Feedback.FirstOrDefault(c => c.username == username);
        }
        public async Task<IEnumerable<Feedback>> GetAll(string username)
        {
            var res = _context.Feedback.Where(e => string.Compare(e.username, username) == 0);
            return await res.ToListAsync();
        }

        public async Task<bool> Remove(string username)
        {
            var result = _context.Feedback.SingleOrDefault(c => c.username == username);
            if (result != null)
            {
                _context.Feedback.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task Update(Feedback feedback)
        {
            var feedback1 = await _context.Feedback.FindAsync(feedback.username);
            feedback1.rate = feedback.rate;
            feedback1.description = feedback.description;
            feedback1.username = feedback.username;
            await _context.SaveChangesAsync();
        }
        public async Task<double> computeAVG()
        {
            if (await _context.Feedback.CountAsync() == 0)
            {
                return 0;
            }
            double avg = (double)await _context.Feedback.AverageAsync(e => e.rate);
            return Math.Round(avg, 2);
        }
        public async Task<List<Feedback>> searchByNameOrDescription(SearchContent content)
        {
            return await _context.Feedback.Where(e => e.username.Contains(content.Search) || e.description.Contains(content.Search)).ToListAsync();
        }
    }
}
