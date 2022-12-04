using System;
namespace PatientInformationApi.PatientModel
{
	public class Patient
	{
	
		public int patientId { get; set; }
		public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string dateOfAdmission { get; set; }
    }
}

