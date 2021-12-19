using ErtsApiFetcher._Infrastructure.RecurringJobs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ErtsApiFetcher._Infrastructure.Enqueuers
{
    public interface IEnqueuer
    {
       public void AddRecurringJob(RecurringJobInfoAttribute recurringJobInfo);
    }
}
