using PatientInformationApi.DAL;
using PatientInformationApi.PatientModel;
using System;
using System.Web;
using System.Web.Http;

namespace PatientInformationApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/HRS")]
    public class patientController:ApiController
    {
        [HttpPost]
        [Route("GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.GetAllPatient();
        }
    }
}
