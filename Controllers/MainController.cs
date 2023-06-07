using CodeFirst.Models;
using CodeFirst.Models.DTO;
using CodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {


        private readonly IMainService _mainService;

        public MainController(IMainService mainService)
        {
            this._mainService = mainService;
        }

        [HttpGet]
        public async Task<IActionResult> getDoctors()
        {
           IList<DoctorDTO> doctors =  await _mainService.getDoctors();
           return Ok(doctors);
        }
        [HttpPost]
        public async Task<IActionResult> addDoctor(DoctorDTO doctor)
        {
            await _mainService.addDoctor(doctor);

            return Ok(doctor);
        }
        [HttpPut("{IdDoctor}")]
        public async Task<IActionResult> updateDoctor(DoctorDTO doctor, int IdDoctor)
        {
            await _mainService.updateDoctor(doctor, IdDoctor);
            return Ok(doctor);
        }
        [HttpDelete("{IdDoctor}")]
        public async Task<IActionResult> deleteDoctor(int IdDoctor)
        {
            await _mainService.deleteDoctor(IdDoctor);
            return Ok();
        }

        [HttpGet("{prescriptionId}")]
        public async Task<IActionResult> GetPrescription(int prescriptionId)
        {
            Prescription prescription = await _mainService.GetPrescriptionDetails(prescriptionId);

            if (prescription == null)
            {
                return NotFound();
            }

            return Ok(prescription);
        }

    }
}
