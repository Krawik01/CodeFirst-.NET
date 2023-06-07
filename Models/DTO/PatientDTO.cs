﻿namespace CodeFirst.Models.DTO
{
    public class PatientDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<PrescriptionDTO> Prescriptions { get; set; } = new List<PrescriptionDTO>();
    }
}
