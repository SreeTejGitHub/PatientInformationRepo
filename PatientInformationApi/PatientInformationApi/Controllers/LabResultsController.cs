using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationApi.DAL;
using PatientInformationApi.PatientModel;

namespace PatientInformationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabResultsController : ControllerBase
    {
        [HttpGet(Name = "GetAllLabResults")]
        public List<LabResults> GetAllLabResults(int patientId)
        {
            HRSManager objhrs = new HRSManager();
            return objhrs.GetLabResults(patientId);
        }
    }
}
