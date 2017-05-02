using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FOR2B3U_Lokaverkefni
{
    class Gagnagrunnur
    {
        //server: segir til um hvar serverinn er hýstur, hjá okkur er það localhost
        private string server;
        //database: nafnið á gagnagrunninum sem verið er að nota
        private string database;
        //uid: er MySQL notendanafnið
        private string uid;
        //password. er MySQL lykilorðið
        private string password;
        //tengistrengur: contains the connection string to connect to the database and will be assigned to the connection variable
        string tengistrengur = null;
        //fyrirspurn: inniheldur viðeigandi fyrirspurn hverju sinni.
        string fyrirspurn = null;

        MySqlConnection sqltenging; //Þetta er notað til þess að opna tengingu við gagnagrunn
        MySqlCommand nySQLskipun; //Þetta er notað til þess að framkvæma SQL fyrirspurna
        MySqlDataReader sqllesari = null; //Lesari sem getur lesið úr SQL gagnagrunninum

        //Þessi aðferð tengir notanda við gagnagrunninn, þannig að þið breytið viðeigandi upplýsingum sem á við
        public void TengingVidGagnagrunn()
        {
            server = "10.200.10.24";
            database = "2605993489_for2b3ulokaverkefni";
            uid = "2605993489";
            password = "mypassword";

            tengistrengur = "server = " + server + ";userid = " + uid + ";password = " + password + ";database = " + database;
            sqltenging = new MySqlConnection(tengistrengur);
        }

        //Þessi aðferð athugar hvort tenging sé komin eða ekki
        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        //Þessi aðferð lokar tengingu eftir notkun
        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        public string LesautSQLToflu(string flokkur,string mynd)
        {
            string kkkk = null;
            
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT " + flokkur + " FROM spil WHERE nafn_myndar ='" + mynd+"'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        kkkk += sqllesari.GetValue(i).ToString();
                    }
                }
                CloseConnection();

            }
            CloseConnection();
            return kkkk;
        }
    }
}
