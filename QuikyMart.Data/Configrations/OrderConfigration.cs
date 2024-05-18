using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuikyMart.Data.Entites.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Configrations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderR>
    {
        public void Configure(EntityTypeBuilder<OrderR> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, X =>
            {
                X.WithOwner();
            });

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
            builder.Property(o => o.Status)
                .HasConversion(
                    os => os.ToString(),
                    os => (OrderStatus)Enum.Parse(typeof(OrderStatus), os)
                );

            builder.HasOne(o => o.deliveryMethod).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }


}
