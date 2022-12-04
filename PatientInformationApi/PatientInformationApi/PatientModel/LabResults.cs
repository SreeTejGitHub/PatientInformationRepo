using System;
namespace PatientInformationApi.PatientModel
{
	public class LabResults
	{
        public int labId { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string valueType { get; set; }
        public string timeOfTest { get; set; }
        public string enteredTime { get; set; }
    }
}

