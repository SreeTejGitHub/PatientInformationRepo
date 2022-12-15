using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationApi.DAL;
using PatientInformationApi.PatientModel;

namespace PatientInformationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpGet(Name = "GetAllPatients")]
        public List<Patient> GetAllPatients ()
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.GetAllPatient();
        }


        [HttpPost(Name = "UpdatePatientIData")]
        public string UpdatePatientIData(Patient patientInfo)
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.updatePatientData(patientInfo);
        }
    }
}
