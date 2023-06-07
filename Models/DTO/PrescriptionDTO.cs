namespace CodeFirst.Models.DTO
{
    public class PrescriptionDTO
    {

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual ICollection<Prescription_Medicament> PrescriptionsMedicaments { get; set; } = new List<Prescription_Medicament>();

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
