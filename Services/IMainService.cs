using CodeFirst.Models;
using CodeFirst.Models.DTO;

namespace CodeFirst.Services
{
    public interface IMainService
    {
        Task<IList<DoctorDTO>> getDoctors();
        Task addDoctor(DoctorDTO doctor);

        Task updateDoctor(DoctorDTO doctor, int IdDoctor);   

        Task deleteDoctor(int IdDoctor);

        Task<Prescription> GetPrescriptionDetails(int IdPrecition);
    }
}
