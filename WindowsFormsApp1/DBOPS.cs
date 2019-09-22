using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WindowsFormsApp1.DataClasses;

namespace WindowsFormsApp1
{
    class DBOPS
    {
        static string cnStr = ConfigurationManager.AppSettings["cnStr"];


        public static void CreatVideoTable()
        {
            try
            {
                SqlConnection myConnection2 = new SqlConnection(cnStr);
                myConnection2.Open();
                string query = "IF OBJECT_ID('Video', 'U') IS NULL CREATE TABLE Video (id INT PRIMARY KEY, id_pat INT NOT NULL, date DATETIME NOT NULL, diag VARCHAR (255), path VARCHAR (255) NOT NULL, FOREIGN KEY (id_pat) REFERENCES Patsient (id))";
                SqlCommand command2 = new SqlCommand(query, myConnection2);
                command2.ExecuteNonQuery();
                myConnection2.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка сотворения таблицы видео: " + Ex.Message);
            }
        }
        public static void CreatePictureTable()
        {
            try
            {
                SqlConnection myConnection2 = new SqlConnection(cnStr);
                myConnection2.Open();
                string query = "IF OBJECT_ID('Pictures', 'U') IS NULL CREATE TABLE Pictures (id INT PRIMARY KEY, id_vid INT NOT NULL, id_pat INT NOT NULL, date DATETIME NOT NULL, timestamp VARCHAR (255), diag VARCHAR (255), path VARCHAR (255), type VARCHAR (255), FOREIGN KEY (id_pat) REFERENCES Patsient (id), FOREIGN KEY (id_vid) REFERENCES Video (id))";
                SqlCommand command2 = new SqlCommand(query, myConnection2);
                command2.ExecuteNonQuery();
                myConnection2.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка сотворения таблицы видео: " + Ex.Message);
            }
        }
        public static bool AddNewPat(string name, string surname, string otch, DateTime bdate, DateTime pdate, string diag)
        {
            bool result = false;
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Patsient (name, surname, otch, birthdate, date_post, diag, maker_id) VALUES (@name, @surname, @otch, @birthdate, @date_post, @diag, 1)";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@otch", otch);
                command.Parameters.AddWithValue("@birthdate", bdate);
                command.Parameters.AddWithValue("@date_post", pdate);
                command.Parameters.AddWithValue("@diag", diag);
                command.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show(String.Format("Пациент {0} {1} {2} успешно добавлен.", surname, name, otch));
                result = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка добавления пациента: " + Ex.Message);
            }
            return result;
        }
        public static bool AddNewVideo(int id_pat, DateTime date, string diag, string path)
        {
            bool result = false;
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Video (id_pat, date, diag, path) VALUES (@id_pat, @date, @diag, @path)";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_pat", id_pat);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@diag", diag);
                command.Parameters.AddWithValue("@path", path);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка AddNewVideo: " + Ex.Message);
            }
            return result;
        }
        public static bool AddNewPicture(int id_vid, int id_pat, DateTime date, string diag, string path, string timestamp)
        {
            bool result = false;
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Pictures (id_vid, id_pat, date, diag, path, timestamp) VALUES (@id_vid, @id_pat, @date, @diag, @path, @timestamp)";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                command.Parameters.AddWithValue("@id_pat", id_pat);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@diag", diag);
                command.Parameters.AddWithValue("@path", path);
                command.Parameters.AddWithValue("@timestamp", timestamp);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка AddNewPicture: " + Ex.Message);
            }
            return result;
        }

        public static void DeletePictures(int id_vid)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "DELETE FROM [Pictures] Where id_vid = @id_vid";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка в DeletePictures: " + Ex.Message);
            }
        }

        public static bool ExistPicturesCheck(int id_vid)
        {
            bool status = false;
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT COUNT(*) FROM Pictures where id_vid = @id_vid";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                var result = Convert.ToInt32(command.ExecuteScalar());
                if (result >= 1)
                    status = true;

                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка ExistPicturesCheck: " + Ex.Message);
            }
            return status;
        }


        public static List<PatsTable> GetPatsList()
        {
            List<PatsTable> pats = new List<PatsTable>();
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM [Patsient]";
                SqlCommand command = new SqlCommand(query, myConnection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pats.Add(new PatsTable { Id = Int32.Parse(dr["id"].ToString()), FIO = dr["surname"].ToString() + " " + dr["name"].ToString() + " " + dr["otch"].ToString() });
                    }
                }
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetFuelsTradeId: " + Ex.Message);
            }
            return pats;
        }
        public static List<VidTable> GetVidsList(int id_pat)
        {
            List<VidTable> vids = new List<VidTable>();
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM [Video] where id_pat = @id_pat";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_pat", id_pat);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var date = DateTime.Parse(dr["date"].ToString());
                        vids.Add(new VidTable { Id = Int32.Parse(dr["id"].ToString()), Name = date.ToString("dd/MM/yyyy") + " - " + Path.GetFileName(dr["path"].ToString())});
                    }
                }
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetFuelsTradeId: " + Ex.Message);
            }
            return vids;
        }
        public static List<ImageListTable> GetImagesList(int id_vid)
        {
            List<ImageListTable> pics = new List<ImageListTable>();
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM [Pictures] where id_vid = @id_vid";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var date = DateTime.Parse(dr["date"].ToString());
                        pics.Add(new ImageListTable { Id = Int32.Parse(dr["id"].ToString()), date = date, path = dr["path"].ToString(), timestamp = dr["timestamp"].ToString() });
                    }
                }
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetImagesList: " + Ex.Message);
            }
            return pics;
        }

        public static PatInfoTable GetPat(int id)
        {
            PatInfoTable pat = new PatInfoTable();
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM [Patsient] where id = @id";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pat = new PatInfoTable {
                            Id = Int32.Parse(dr["id"].ToString()),
                            FIO = dr["surname"].ToString() + " " + dr["name"].ToString() + " " + dr["otch"].ToString(),
                            Bdate = DateTime.Parse(dr["birthdate"].ToString()),
                            Pdate = DateTime.Parse(dr["date_post"].ToString()),
                            Diag = dr["diag"].ToString()
                        };
                    }
                }
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetPat: " + Ex.Message);
            }
            return pat;
        }
        public static VidInfoTable GetVid(int id)
        {
            VidInfoTable vid = new VidInfoTable();
            try
            {
                SqlConnection myConnection = new SqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM [Video] where id = @id";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vid = new VidInfoTable
                        {
                            Id = Int32.Parse(dr["id"].ToString()),
                            Diag = dr["diag"].ToString(),
                            path = dr["path"].ToString()
                        };
                    }
                }
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetVid: " + Ex.Message);
            }
            return vid;
        }

    }

}
