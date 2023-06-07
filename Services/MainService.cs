using CodeFirst.Models;
using CodeFirst.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CodeFirst.Services
{
    public class MainService : IMainService
    {

        private readonly MainDbContext _context;

        public MainService(MainDbContext mainDbContext)
        {
            _context = mainDbContext;

        }

        public async Task<IList<DoctorDTO>> getDoctors()
        {

            var doctors = await _context.Doctors.ToListAsync();
            var doctorDTOs = doctors.Select(d => new DoctorDTO
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Prescriptions = d.Prescriptions
            }).ToList();

            return doctorDTOs;


        }
        public async Task addDoctor(DoctorDTO doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task updateDoctor(DoctorDTO doctor, int IdDoctor)
        {

            var existingDoctor = await _context.Doctors.FindAsync(IdDoctor);

            if (existingDoctor != null)
            {
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Email = doctor.Email;

                _context.Update(existingDoctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task deleteDoctor(int IdDoctor)
        {

            var existingDoctor = await _context.Doctors.FindAsync(IdDoctor);

            if (existingDoctor != null)
            {
                _context.Remove(existingDoctor);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Prescription> GetPrescriptionDetails(int prescriptionId)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64 // Zwiększenie maksymalnej głębokości serializacji, jeśli jest to konieczne
            };

            var prescription = await _context.Set<Prescription>()
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .Include(p => p.PrescriptionsMedicaments)
                    .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPrescription == prescriptionId);

            return prescription;
        }
    }
}
