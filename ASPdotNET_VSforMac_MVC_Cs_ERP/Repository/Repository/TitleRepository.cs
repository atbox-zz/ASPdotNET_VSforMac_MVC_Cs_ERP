using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository
{
    public class TitleRepository : ITitleRepository
    {
        private ErpContext context;

        public TitleRepository(ErpContext _context)
        {
            context = _context;
        }

        public Task<Title> GetByIdAsync(int id)
        {
            return context.Titles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Title>> ListAsync()
        {
            return context.Titles.ToListAsync();
        }

        public Task AddAsync(Title title)
        {
            context.Titles.Add(title);
            return context.SaveChangesAsync();
        }

        public Task UpdateAsync(Title title)
        {
            context.Entry(title).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(Title title)
        {
            context.Titles.Remove(title);
            return context.SaveChangesAsync();
        }
    }
}
