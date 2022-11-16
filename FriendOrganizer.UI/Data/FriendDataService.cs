using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        [Obsolete("Вместо этого метода следует использовать метод GetItems()")]
        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
        }

        public IEnumerable<Friend> GetItems()
        {
                return _contextCreator().Friends;
        }
    }
}
