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
using System.Data.Common;
using Npgsql;

namespace WindowsFormsApp1
{
    class DBOPS
    {
        static string dp = ConfigurationManager.AppSettings["provider"];
        static string cnStr = ConfigurationManager.AppSettings["cnStr"];

        static DbProviderFactory factory = DbProviderFactories.GetFactory(dp);


        public static void CreatPatsTable()
        {
            try
            {
                NpgsqlConnection myConnection2 = new NpgsqlConnection(cnStr);
                myConnection2.Open();
                string query = "CREATE TABLE IF NOT EXISTS Patsient (id SERIAL, surname text NOT NULL, name text NOT NULL, otch text NOT NULL, birthdate date NOT NULL, date_post date NOT NULL, diag text NOT NULL, PRIMARY KEY (id))";
                NpgsqlCommand command2 = new NpgsqlCommand(query, myConnection2);
                command2.ExecuteNonQuery();
                myConnection2.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка сотворения CreatPatsTable: " + Ex.Message);
            }
        }
        public static void CreatVideoTable()
        {

                NpgsqlConnection myConnection2 = new NpgsqlConnection(cnStr);
                myConnection2.Open();           
                string query = "CREATE TABLE IF NOT EXISTS Video (id SERIAL, id_pat INT NOT NULL REFERENCES Patsient(id), date date NOT NULL, diag text, path text NOT NULL, PRIMARY KEY (id), FOREIGN KEY(id_pat) REFERENCES Patsient(id))";
                NpgsqlCommand command2 = new NpgsqlCommand(query, myConnection2);
                command2.ExecuteNonQuery();
                myConnection2.Close();
            

        }
        public static void CreatPictueTable()
        {
            try
            {
                NpgsqlConnection myConnection2 = new NpgsqlConnection(cnStr);
                myConnection2.Open();
                string query = "CREATE TABLE IF NOT EXISTS Pictures (id SERIAL, id_vid INT NOT NULL, id_pat INT NOT NULL, date date NOT NULL, timestamp text, diag text, path text, type text, PRIMARY KEY (id), FOREIGN KEY (id_vid) REFERENCES video(id), FOREIGN KEY (id_pat) REFERENCES Patsient(id))";
                NpgsqlCommand command2 = new NpgsqlCommand(query, myConnection2);
                command2.ExecuteNonQuery();
                myConnection2.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка сотворения CreatPictueTable: " + Ex.Message);
            }
        }

        public static bool AddNewPat(string name, string surname, string otch, DateTime bdate, DateTime pdate, string diag)
        {
            bool result = false;
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Patsient (name, surname, otch, birthdate, date_post, diag) VALUES (@name, @surname, @otch, @birthdate, @date_post, @diag)";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Video (id_pat, date, diag, path) VALUES (@id_pat, @date, @diag, @path)";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "INSERT INTO Pictures (id_vid, id_pat, date, diag, path, timestamp) VALUES (@id_vid, @id_pat, @date, @diag, @path, @timestamp)";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "DELETE FROM Pictures Where id_vid = @id_vid";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка в DeletePictures: " + Ex.Message);
            }
        }
        public static void DeletePatCascade(int id)
        {
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "DELETE FROM Pictures Where id_pat = @id_pat";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_pat", id);
                command.ExecuteNonQuery();
                query = "DELETE FROM Video Where id_pat = @id_pat";
                command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_pat", id);
                command.ExecuteNonQuery();
                query = "DELETE FROM Patsient Where id = @id";
                command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                myConnection.Close();
                if (Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + id))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + id, true);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка в DeletePatCascade: " + Ex.Message);
            }
        }

        public static void DeleteVidCascade(int vid_id, string path)
        {
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "DELETE FROM Pictures Where id_vid = @id_vid";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@vid_id", vid_id);
                command.ExecuteNonQuery();
                query = "DELETE FROM Video Where id = @id";
                command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", vid_id);
                command.ExecuteNonQuery();
                myConnection.Close();
                if (Directory.Exists(System.IO.Directory.GetCurrentDirectory()  + path+ "_images"))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.Directory.Delete(System.IO.Directory.GetCurrentDirectory() +  path + "_images", true);
                }
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + path))
                {
                    File.Delete(System.IO.Directory.GetCurrentDirectory() + path);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка в DeleteVidCascade: " + Ex.Message);
            }
        }

        public static bool ExistPicturesCheck(int id_vid)
        {
            bool status = false;
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT COUNT(*) FROM Pictures where id_vid = @id_vid";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Patsient";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                using (NpgsqlDataReader dr = command.ExecuteReader())
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
                MessageBox.Show("Ошибка GetPatsList: " + Ex.Message);
            }
            return pats;
        }
        public static List<VidTable> GetVidsList(int id_pat)
        {
            List<VidTable> vids = new List<VidTable>();
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Video where id_pat = @id_pat";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_pat", id_pat);
                using (NpgsqlDataReader dr = command.ExecuteReader())
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
                MessageBox.Show("Ошибка GetVidsList: " + Ex.Message);
            }
            return vids;
        }
        public static List<ImageListTable> GetImagesList(int id_vid)
        {
            List<ImageListTable> pics = new List<ImageListTable>();
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Pictures where id_vid = @id_vid";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id_vid", id_vid);
                using (NpgsqlDataReader dr = command.ExecuteReader())
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
        public static List<SearchImageListTable> GetSearchImagesList()
        {
            List<SearchImageListTable> pics = new List<SearchImageListTable>();
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Pictures";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var date = DateTime.Parse(dr["date"].ToString());
                        var fio = GetPat(Int32.Parse(dr["id_pat"].ToString()));
                        var vid = GetVid(Int32.Parse(dr["id_vid"].ToString()));
                        pics.Add(new SearchImageListTable { Id = Int32.Parse(dr["id"].ToString()), Id_vid = Path.GetFileName(vid.Path), Id_pat = fio.FIO, date = date, path = dr["path"].ToString(), timestamp = dr["timestamp"].ToString() });
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Patsient where id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                using (NpgsqlDataReader dr = command.ExecuteReader())
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
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "SELECT * FROM Video where id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vid = new VidInfoTable
                        {
                            Id = Int32.Parse(dr["id"].ToString()),
                            Diag = dr["diag"].ToString(),
                            Path = dr["path"].ToString()
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

        public static void UpdPat(int id, string name, string surname, string otch, DateTime bdate, DateTime pdate, string diag)
        {
            try
            {
                NpgsqlConnection myConnection = new NpgsqlConnection(cnStr);
                myConnection.Open();

                string query = "UPDATE Patsient SET name=@name, surname=@surname, otch=@otch, birthdate=@birthdate, date_post=@date_post, diag=@diag WHERE id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@otch", otch);
                command.Parameters.AddWithValue("@birthdate", bdate);
                command.Parameters.AddWithValue("@date_post", pdate);
                command.Parameters.AddWithValue("@diag", diag);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка GetPat: " + Ex.Message);
            }
        }

    }

}
