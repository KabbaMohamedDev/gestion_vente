using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace gestion_vente.BL
{
    class Login
    {
        public DataTable LOGIN(string ID, string PWD)
        {

            DAL.DataAcessLayer DAL = new DAL.DataAcessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = ID;
            param[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 20);
            param[1].Value = PWD;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("login", param);
            DAL.close();
            return dt;
        }
    }
}