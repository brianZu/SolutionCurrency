using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using TMI.Library.Application.Core.Common.Interfaces;
using TMI.Library.Domain.Core.Common;
using WebApi.Application.Common.Interfaces;
using WebApi.Domain.Entities.Mnemonic;
using WebApi.Domain.Entities.ServicePayment;
using WebApi.Domain.Entities.TransactionMenu;
using WebApi.Domain.Entities.Currency;

namespace WebApi.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }


        public DbSet<MnemonicMain> Mnemonics => Set<MnemonicMain>();
        public DbSet<MnemonicDetail> MnemonicDetails => Set<MnemonicDetail>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<ETrxMenu> TransactionMenus => Set<ETrxMenu>();

        //AGREGADO BRIAN 31/03/2022
        public DbSet<CurrencyConfiguration> CurrencyConfigurations => Set<CurrencyConfiguration>();
        public DbSet<Currency> Currencys => Set<Currency>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<AccountType> AccountTypes => Set<AccountType>();
        //FIN DE AGREGADO BRIAN 31/03/2022
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var events = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var trimEndConversion = new ValueConverter<string, string>(v => v.TrimEnd(), v => v.TrimEnd());

            builder.Entity<MnemonicDetail>()
                .HasOne(p => p.Parent)
                .WithMany(b => b.MnemonicDetails)
                .HasForeignKey(p => p.ParentMnemonic)
                .HasPrincipalKey(b => b.Mnemonic);

            builder.Entity<Servicio>()
              .HasOne(p => p.Empresa)
              .WithMany(b => b.Servicios)
              .HasForeignKey(p => p.EmpresaMnemonic)
              .HasPrincipalKey(b => b.Mnemonic);


            builder.Entity<ETrxMenu>(tbl =>
            {
                tbl.ToTable("TransactionMenu");
                tbl.HasKey(x => x.TransactionNumber);
                tbl.Property(e => e.TransactionNumber).HasConversion(trimEndConversion);
            });

            //AGREGADO BRIAN 31/03/2022
            builder.Entity<CurrencyConfiguration>().HasKey(x => new { x.IdConfiguration, x.IdAccountType, x.IdTransaction, x.IdCurrency });

            builder.Entity<CurrencyConfiguration>()
             .HasOne(p => p.Transaction)
             .WithMany(b => b.ConfigurationTransaction)
             .HasForeignKey(p => p.IdTransaction)
             .HasPrincipalKey(b => b.IdTransaction);

            builder.Entity<CurrencyConfiguration>()
             .HasOne(p => p.Currency)
             .WithMany(b => b.ConfigurationCurrency)
             .HasForeignKey(p => p.IdCurrency)
             .HasPrincipalKey(b => b.IdCurrency);

            builder.Entity<CurrencyConfiguration>()
            .HasOne(p => p.AccountType)
            .WithMany(b => b.ConfigurationAccountType)
            .HasForeignKey(p => p.IdAccountType)
            .HasPrincipalKey(b => b.IdAccountType);

            //FIN DE AGREGADO BRIAN 31/03/2022


            base.OnModelCreating(builder);
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }

    }
}
