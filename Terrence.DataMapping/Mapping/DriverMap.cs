using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Terrence.Domain;

namespace Terrence.DataMapping
{
    public class DriverMap : EntityTypeConfiguration<Driver>
    {
        public DriverMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.ToTable("Driver");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SupplierId).HasColumnName("SupplierId");
            this.Property(t => t.IsDistribution).HasColumnName("IsDistribution");
            this.Property(t => t.DriverName).HasColumnName("DriverName");
            this.Property(t => t.IdCard).HasColumnName("IdCard");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.DrivingYears).HasColumnName("DrivingYears");
            this.Property(t => t.DrivingLicense).HasColumnName("DrivingLicense");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Sex).HasColumnName("Sex");
        }
    }
}
