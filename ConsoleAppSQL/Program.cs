using System;
using System.Data.SqlClient;
using ConsoleAppSQL.Models;

namespace MCCDSTS
{
    class Program
    {
        SqlConnection? sqlConnection;

        string connectionString = "Data Source=DESKTOP-GK9TR5F;Initial Catalog=DTSMCC001;User ID=mccdts1;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        void Menu()
        {
            Console.WriteLine("Aplikasi Data Karyawan\r");
            Console.WriteLine("--------MENU----------\n");
            Console.WriteLine("\n");
            Console.WriteLine("1. Tambah Data Karyawan Baru\n");
            Console.WriteLine("2. Tampilkan Data Karyawan\n");
            Console.WriteLine("3. Ubah Data Karyawan\n");
            Console.WriteLine("4. Hapus Data Karyawan\n");
            Console.WriteLine("5. Keluar\n");
            Console.WriteLine("\n");
            Console.WriteLine("Silahkan masukkan angka sesuai dengan keterangan diatas kemudian tekan Enter.\n");
        }

        static void KeMenu()
        {
            Console.WriteLine("Tekan Enter untuk kembali ke Menu\n");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            Console.Clear();
        }

        static void Main(string[] args)
        {
            bool endApp = false;
            int MenuInput;

            Program program = new Program();

            while (!endApp)
            {
                program.Menu();

                MenuInput = Convert.ToInt16(Console.ReadLine());
                Console.Clear();

                if (MenuInput == 1)
                {
                    bool TambahData = true;

                    while (TambahData)
                    {
                        Console.WriteLine("Aplikasi Data Karyawan\r");
                        Console.WriteLine("--Tambah Data Karyawan Baru--\n");
                        Console.Write("Id : ");
                        int IdKaryawanBaru = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Nama : ");
                        string NamaKaryawanBaru = Console.ReadLine();
                        Console.Write("Kode Jabatan : ");
                        string JabatanKaryawanBaru = Console.ReadLine();
                        Console.Write("Kode Department : ");
                        string DepartmentKaryawanBaru = Console.ReadLine();
                        Console.WriteLine("\n");

                        Console.Write("Apakah data yang anda masukkan sudah benar (y/n) ");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("============================================\n");

                            Employees employees = new Employees()
                            {
                                EmployeeId = IdKaryawanBaru,
                                FirstName = NamaKaryawanBaru,
                                JobId = JabatanKaryawanBaru,
                                DepartmentId = DepartmentKaryawanBaru,
                            };
                            program.Insert(employees);

                            Console.WriteLine("\nData Karyawan Baru Telah Disimpan!");
                            KeMenu();
                            TambahData = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Silahkan isi kembali : \n");
                            Console.WriteLine();
                        }
                    }
                }

                else if (MenuInput == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Aplikasi Data Karyawan\r");
                    Console.WriteLine("-----Data Karyawan-----\n");

                    program.getAll();

                    KeMenu();

                }
                else if(MenuInput == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Aplikasi Data Karyawan\r");
                    Console.WriteLine("-----Ubah Data Karyawan-----\n");

                    Console.Write("Masukkan Id Karyawan yang ingin diubah : ");
                    int IdKaryawan = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\n");

                    Console.WriteLine("Data Karyawan yang akan anda ubah : \n");
                    program.getById(IdKaryawan);
                    Console.WriteLine("\n");

                    Console.WriteLine("Masukkan Data baru karyawan : \n");
                    Console.Write("Nama : ");
                    string NamaKaryawanBaru = Console.ReadLine();
                    Console.Write("Kode Jabatan : ");
                    string JabatanKaryawanBaru = Console.ReadLine();
                    Console.Write("Kode Department : ");
                    string DepartmentKaryawanBaru = Console.ReadLine();
                    Console.WriteLine("\n");

                    Employees employees = new Employees()
                    {
                        EmployeeId = IdKaryawan,
                        FirstName = NamaKaryawanBaru,
                        JobId = JabatanKaryawanBaru,
                        DepartmentId = DepartmentKaryawanBaru,
                    };
                    program.Update(employees);
                    
                    Console.WriteLine("\nData Karyawan Baru Telah Disimpan!");
                    Console.WriteLine("\n");
                    program.getById(IdKaryawan);

                    KeMenu();
                }

                else if (MenuInput == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Aplikasi Data Karyawan\r");
                    Console.WriteLine("-----Hapus Data Karyawan-----\n");

                    Console.Write("Masukkan Id Karyawan yang ingin dihapus : ");
                    int IdKaryawan = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\n");

                    Console.Write("Data Karyawan yang akan dihapus : ");
                    program.getById(IdKaryawan);

                    Console.Write("Apakah Anda yakin untuk menghapusnya? ");
                    Console.Write("Apakah data yang anda masukkan sudah benar (y/n) ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("\n");
                        program.DeleteById(IdKaryawan);
                        Console.Write("Data Karyawan berhasil dihapus. ");
                        KeMenu();
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        KeMenu();
                    }
                }
                else if (MenuInput == 5)
                {
                    endApp = true;
                }
                else
                {
                    Console.WriteLine("Masukkan angka sesuai dengan pilihan dimenu!");
                }
            }
        }

        void getAll()
        {
            string query = "select * from Employees";
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("ID: " + sqlDataReader[0] + " || Name: " + sqlDataReader[1] + " || JobId: " + sqlDataReader[5] + " || Dept: " + sqlDataReader[7]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void getById(int EmployeeId)
        {
            string query = "select * from employees where EmployeeId = @EmployeeId";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@EmployeeId";
            sqlParameter.Value = EmployeeId;

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("ID: " + sqlDataReader[0] + " || Name: " + sqlDataReader[1] + " || JobId: " + sqlDataReader[5] + " || Dept: " + sqlDataReader[7]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void Insert(Employees employees)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Employees " +
                        "(EmployeeID, FirstName, JobId, DepartmentId) VALUES (@EmployeeId, @FirstName, @JobId, @DepartmentId)";

                    SqlParameter sqlParameterId = new SqlParameter();
                    sqlParameterId.ParameterName = "@EmployeeId";
                    sqlParameterId.Value = employees.EmployeeId;

                    SqlParameter sqlParameterName = new SqlParameter();
                    sqlParameterName.ParameterName = "@FirstName";
                    sqlParameterName.Value = employees.FirstName;

                    SqlParameter sqlParameterJobId = new SqlParameter();
                    sqlParameterJobId.ParameterName = "@JobId";
                    sqlParameterJobId.Value = employees.JobId;

                    SqlParameter sqlParameterDepartmentId = new SqlParameter();
                    sqlParameterDepartmentId.ParameterName = "@DepartmentId";
                    sqlParameterDepartmentId.Value = employees.DepartmentId;

                    sqlCommand.Parameters.Add(sqlParameterId);
                    sqlCommand.Parameters.Add(sqlParameterName);
                    sqlCommand.Parameters.Add(sqlParameterJobId);
                    sqlCommand.Parameters.Add(sqlParameterDepartmentId);


                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        void Update(Employees employees)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "update Employees " +
                        "set FirstName = @FirstName, JobId = @JobId, DepartmentId = @DepartmentId where EmployeeId = @EmployeeId";
                    

                    SqlParameter sqlParameterId = new SqlParameter();
                    sqlParameterId.ParameterName = "@EmployeeId";
                    sqlParameterId.Value = employees.EmployeeId;

                    SqlParameter sqlParameterName = new SqlParameter();
                    sqlParameterName.ParameterName = "@FirstName";
                    sqlParameterName.Value = employees.FirstName;

                    SqlParameter sqlParameterJobId = new SqlParameter();
                    sqlParameterJobId.ParameterName = "@JobId";
                    sqlParameterJobId.Value = employees.JobId;

                    SqlParameter sqlParameterDepartmentId = new SqlParameter();
                    sqlParameterDepartmentId.ParameterName = "@DepartmentId";
                    sqlParameterDepartmentId.Value = employees.DepartmentId;

                    sqlCommand.Parameters.Add(sqlParameterId);
                    sqlCommand.Parameters.Add(sqlParameterName);
                    sqlCommand.Parameters.Add(sqlParameterJobId);
                    sqlCommand.Parameters.Add(sqlParameterDepartmentId);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        void DeleteById(int EmployeeId)
        {
            string query = "delete from employees where EmployeeId = @EmployeeId";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@EmployeeId";
            sqlParameter.Value = EmployeeId;

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);

            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}