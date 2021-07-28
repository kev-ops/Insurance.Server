using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Classes;
using Insurance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            InsuranceSetup = new InsuranceSetupRepository(_context);
            Consumer = new ConsumerRepository(_context);
            BenefitDetail = new BenefitDetailRepository(_context);
        }

        public IInsuranceSetupRepository InsuranceSetup { get; private set; }
        public IConsumerRepository Consumer { get; private set; }
        public IBenefitDetailRepository BenefitDetail { get; private set; }
        public async Task<SaveResult> Complete(CancellationToken cancellationToken)
        {
            var saveResult = new SaveResult();
            var newOrModifiedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added ||
                                                                           x.State == EntityState.Modified
                                                                        || x.State == EntityState.Deleted);
         
            try
            {
                if (newOrModifiedEntries.Count() > 0)
                {
                    var rowsAffected = await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    saveResult.rowsAffected = rowsAffected;
                    saveResult.success = true;
                    saveResult.message = "Successfully saved.";
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    var proposedValues = entry.CurrentValues;
                    var dbValues = entry.GetDatabaseValues();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;

                if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    errorMessage = "Unable to delete. Record is being used.";
                }

                saveResult.success = false;
                saveResult.message = errorMessage;
            }

            return saveResult;


        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
