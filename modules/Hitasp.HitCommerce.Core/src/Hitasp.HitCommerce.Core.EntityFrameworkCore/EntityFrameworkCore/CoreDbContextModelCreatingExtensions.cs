using Volo.Abp.EntityFrameworkCore.Modeling;
using Hitasp.HitCommerce.Core.Countries;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.EntityFrameworkCore
{
    public static class CoreDbContextModelCreatingExtensions
    {
        public static void ConfigureCore(
            this ModelBuilder builder,
            Action<CoreModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CoreModelBuilderConfigurationOptions(
                CoreDbProperties.DbTablePrefix,
                CoreDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);

                b.ConfigureByConvention();

                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            if (builder.IsHostDatabase())
            {
                builder.Entity<Country>(b =>
    {
        b.ToTable(CoreDbProperties.DbTablePrefix + "Countries", CoreDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Name).HasColumnName(nameof(Country.Name)).IsRequired().HasMaxLength(CountryConsts.NameMaxLength);
        b.Property(x => x.Code3).HasColumnName(nameof(Country.Code3)).HasMaxLength(CountryConsts.Code3MaxLength);
        b.Property(x => x.IsBillingEnabled).HasColumnName(nameof(Country.IsBillingEnabled));
        b.Property(x => x.IsShippingEnabled).HasColumnName(nameof(Country.IsShippingEnabled));
    });

            }
        }
    }
}