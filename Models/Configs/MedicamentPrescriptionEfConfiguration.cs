using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Models.Configs
{
    public class MedicamentPrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {

           builder.HasKey(e=> new {e.IdPrescription, e.IdMedicament }).HasName("PrescriptionMedicament_pk");

            builder.HasOne(e => e.Medicament)
                 .WithMany(e => e.PrescriptionsMedicaments)
                 .HasForeignKey(e => e.IdMedicament)
                 .HasConstraintName("PrescriptionMedicament_Medicament")
                 .OnDelete(DeleteBehavior.Restrict);
        
            builder.HasOne(e => e.Prescription)
                 .WithMany(e => e.PrescriptionsMedicaments)
                 .HasForeignKey(e => e.IdPrescription)
                 .HasConstraintName("PrescriptionMedicament_Prescription")
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Dose).IsRequired();
            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();


            builder.ToTable("Prescription_Medicament");
    }

        



}
}
