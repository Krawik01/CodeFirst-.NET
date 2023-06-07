using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Medicament
    {
        
        public int IdMedicament { set; get; }
    
        public string Name { set; get; }
       
        public string Description { set; get; }
     
        public string Type { set; get; }

        public virtual ICollection<Prescription_Medicament> PrescriptionsMedicaments { get; set; } = new List<Prescription_Medicament>();

    }
}
