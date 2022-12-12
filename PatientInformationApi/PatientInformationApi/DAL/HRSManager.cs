using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Data.SqlClient;
using PatientInformationApi.PatientModel;
using Microsoft.Extensions.Configuration;

namespace PatientInformationApi.DAL
{
    public class HRSManager
    {
        public List<Patient> GetAllPatient()
        {
            List<Patient> objlistpatient = new List<Patient>();
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "103.108.220.125";
            builder.InitialCatalog = "BKDigital";
            builder.UserID = "BKDigital";
            builder.Password = "Burger$2019@!";
            try
            {
                using (SqlConnection sqlcon=new SqlConnection(builder.ConnectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = sqlcon.CreateCommand();
                    DataTable dt = new DataTable();
                    cmd.CommandText = "SP_GetAllPatients";
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    if(dt.Rows.Count > 0 )
                    {
                        for(int i=0;i<dt.Rows.Count;i++)
                        {
                            Patient objpatient = new Patient();
                            objpatient.patientId =Convert.ToInt32(dt.Rows[i]["patientId"]);
                            objpatient.firstName = dt.Rows[i]["firstName"].ToString();
                            objpatient.lastName = Convert.ToString(dt.Rows[i]["lastName"]);
                            objpatient.middleName = Convert.ToString(dt.Rows[i]["middleName"]);
                            objpatient.gender = Convert.ToString(dt.Rows[i]["gender"]);
                            objpatient.phoneNumber = Convert.ToString(dt.Rows[i]["phoneNumber"]);
                            objpatient.emailAddress = Convert.ToString(dt.Rows[i]["emailAddress"]);
                            objpatient.dateOfAdmission = Convert.ToDateTime(dt.Rows[i]["dateOfAdmission"]);
                            objlistpatient.Add(objpatient);

                        }
                    }
                    
                }
            }
            catch ( Exception ex )
            {

            }

            return objlistpatient;
        }
    }
}
