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
        [Route("GetAllPatients")]
        [HttpGet]
        public List<Patient> GetAllPatients ()
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.GetAllPatient();
        }

        [Route("UpdatePatientData")]
        [HttpPost]
        public string UpdatePatientData(Patient patientInfo)
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.updatePatientData(patientInfo);
        }

        [Route("DeletePatientData")]
        [HttpPost]
        public string DeletePatientData(int patientId)
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.DeletePatientData(patientId);
            
        }
    }
}
