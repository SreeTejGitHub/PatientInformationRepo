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

        public List<LabResults> GetLabResults(int patientId)
        {
            List<LabResults> objLabResultList = new List<LabResults>();
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "103.108.220.125";
            builder.InitialCatalog = "BKDigital";
            builder.UserID = "BKDigital";
            builder.Password = "Burger$2019@!";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(builder.ConnectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = sqlcon.CreateCommand();
                    DataTable dt = new DataTable();
                    cmd.CommandText = "SP_GetAllLabResult";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            LabResults objLabResult = new LabResults();
                            objLabResult.labId = Convert.ToInt32(dt.Rows[i]["patientId"]);
                            objLabResult.name = dt.Rows[i]["name"].ToString();
                            objLabResult.value = Convert.ToString(dt.Rows[i]["value"]);
                            objLabResult.valueType = Convert.ToString(dt.Rows[i]["valueType"]);
                            //objLabResult.labId = Convert.ToString(dt.Rows[i]["gender"]);
                            objLabResult.enteredTime = Convert.ToDateTime(dt.Rows[i]["enteredTime"]);
                            objLabResult.timeOfTest = Convert.ToString(dt.Rows[i]["timeOfTest"]);
                            objLabResultList.Add(objLabResult);

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

            return objLabResultList;
        }

        public string updatePatientData(Patient patientInfo)
        {
            string status = "";
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "103.108.220.125";
            builder.InitialCatalog = "BKDigital";
            builder.UserID = "BKDigital";
            builder.Password = "Burger$2019@!";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(builder.ConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = sqlcon.CreateCommand();
                    cmd.CommandText = "SP_InsertUpdate_PatientDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patientFirstName", patientInfo.firstName );
                    cmd.Parameters.AddWithValue("@patientLastName", patientInfo.lastName);
                    cmd.Parameters.AddWithValue("@patientMiddleName", patientInfo.middleName);
                    cmd.Parameters.AddWithValue("@patientPhoneNumber", patientInfo.phoneNumber);
                    cmd.Parameters.AddWithValue("@patientGender", patientInfo.gender);
                    cmd.Parameters.AddWithValue("@patientEmailAddress", patientInfo.emailAddress);
                    cmd.Parameters.AddWithValue("@patientDateOfAdmission", patientInfo.dateOfAdmission);
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    status = (string)cmd.Parameters["@Status"].Value;
                    sqlcon.Close();
                }
            }
            catch (Exception err)
            {
                status = err.ToString();
            }

             return status;
        }
    }
}
