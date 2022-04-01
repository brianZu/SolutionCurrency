using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities.Mnemonic;
using WebApi.Domain.Entities.ServicePayment;
using WebApi.Domain.Entities.TransactionMenu;
using WebApi.Domain.Entities.Currency;

namespace WebApi.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<ETrxMenu> TransactionMenus { get; }

        DbSet<MnemonicMain> Mnemonics { get; }

        DbSet<MnemonicDetail> MnemonicDetails { get; }

        DbSet<Empresa> Empresas { get; }

        DbSet<Servicio> Servicios { get; }

        //AGREGADO BRIAN 31/03/2022
        DbSet<CurrencyConfiguration> CurrencyConfigurations { get; }
        DbSet<Currency> Currencys { get; }
        DbSet<Transaction> Transactions { get; }
        DbSet<AccountType> AccountTypes { get; }
        //FIN DE AGREGADO BRIAN 31/03/2022

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
