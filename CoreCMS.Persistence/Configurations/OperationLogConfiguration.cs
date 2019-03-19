using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCMS.Persistence.Configurations
{
    public class OperationLogConfiguration : IEntityTypeConfiguration<OperationLog>
    {
        public void Configure(EntityTypeBuilder<OperationLog> builder)
        {
            builder.HasKey(l => l.LogId);
            builder.Property(l => l.LogId).HasColumnName("LogID");
            builder.Property(l => l.OperatorId)
                .IsRequired()
                .HasColumnName("OperatorID");
            builder.Property(l => l.OperationType).HasMaxLength(32);
            builder.Property(l => l.OperateTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(l => l.OperatorIp).HasMaxLength(64);
            builder.Property(l => l.Note).HasMaxLength(256);

            builder.HasOne(l => l.Operator)
                .WithMany(m => m.OperationLogs)
                .HasForeignKey(l => l.OperatorId)
                .HasConstraintName("FK_OperationLogs_Managers");
        }
    }
}