using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ErtsModel.FakeSeeds {
    abstract class FakeSeederBase<TModel> where TModel : ModelBase {
        public FakeSeederBase(DbSet<TModel> dbSet) {
            this.dbSet = dbSet;
        }

        protected readonly DbSet<TModel> dbSet;

        public List<TModel> SeedIfNotSeeded() {
            if (!dbSet.Any()) {
                return Seed().ToList();
            }
            return null;
        }

        protected abstract IEnumerable<TModel> Seed();
    }
}
