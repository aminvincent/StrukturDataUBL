using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            RetrieveDataFromScv();
            Console.WriteLine("MENU ITEMS");
            Console.WriteLine("===========================");
            Console.WriteLine("[1] Show Data Master\n[2] Sort Ascending NIP\n[3] Sort Descending NIP\n[4] Sort Ascending NIP and GOLONGAN\n[5] Add Data\n[6] Update Spesific Data");
            Console.WriteLine("===========================");
            Console.Write("Selection Menu: ");
            int selectionItem = Convert.ToInt32(Console.ReadLine());

            menuSelection(selectionItem);

            Console.ReadLine();
        }

        static void menuSelection(int item)
        {
            switch (item)
            {
                case 1:
                    RetrieveDataFromScv();
                    break;
                case 2:
                    SortingDataAscending();
                    break;
                case 3:
                    SortingDataDescending();
                    break;
                case 4:
                    SortingDataAscendingNipandGol();
                    break;
                case 5:
                    AddDataList();
                    break;
                default:
                    Console.WriteLine("Try again!!");
                    break;
            }
        }

        static void RetrieveDataFromScv()
        {
            Console.WriteLine("========MASTER DATA========");
            //string[] stringArray = {"1","2","3" };

            foreach (var item in loadCsvFile(@"data.csv"))
            {
                var result = item.Nip + " | " + item.Nama + " | " + item.Golongan;
                Console.WriteLine(result.ToString());

            }
            Console.WriteLine("===========================");
        }

        static void SortingDataAscending()
        {
            Console.WriteLine("========ORDER BY ASCENDING NIP========");
            var result = loadCsvFile("data.csv").OrderBy(x => x.Nip).ToList();
            foreach (var item in result)
            {
                var msg = item.Nip + " | " + item.Nama + " | " + item.Golongan;
                Console.WriteLine(msg.ToString());
            }
            Console.WriteLine("==================================");
        }

        static void SortingDataDescending()
        {
            Console.WriteLine("========ORDER BY DESCENDING NIP========");
            var result = loadCsvFile("data.csv").OrderByDescending(x => x.Nip).ToList();
            foreach (var item in result)
            {
                var msg = item.Nip + " | " + item.Nama + " | " + item.Golongan;
                Console.WriteLine(msg.ToString());
            }
            Console.WriteLine("==================================");
        }

        static void SortingDataAscendingNipandGol()
        {
            Console.WriteLine("========ORDER BY ASCENDING NIP AND GOLONGAN========");
            var result = loadCsvFile("data.csv").OrderBy(x => x.Nip).ThenBy(x => x.Golongan).ToList();
            foreach (var item in result)
            {
                var msg = item.Nip + " | " + item.Nama + " | " + item.Golongan;
                Console.WriteLine(msg.ToString());
            }
            Console.WriteLine("==================================");
        }

        static void AddDataList()
        {
            try
            {
                Console.Write("NIP: ");
                string nip = Console.ReadLine();
                Console.Write("NAMA: ");
                string nama = Console.ReadLine();
                Console.Write("GOLONGAN: ");
                string golongan = Console.ReadLine();

                EmployeeModel model = new EmployeeModel()
                {
                    Nip = nip,
                    Nama = nama,
                    Golongan = golongan
                };

                loadCsvFile(@"data.csv").Add(model);

                Console.WriteLine("ADDING DATA SUCCESSFULL!");

                RetrieveDataFromScv();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error AddDataList" + ex.Message.ToString());
            }
        }

        #region GET DATA LIST OF DATA FROM CSV
        static List<EmployeeModel> loadCsvFile(string filePath)
        {
            List<EmployeeModel> searchList = new List<EmployeeModel>();

            try
            {
                #region DUMMY
                //string arrayResult = System.IO.File.ReadAllText(filePath);
                //Console.WriteLine(arrayResult); 
                #endregion

                var reader = new StreamReader(File.OpenRead(filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    string[] stringArray = line.Split(';');
                    searchList.Add(new EmployeeModel
                    {
                        Nip = stringArray[0],
                        Nama = stringArray[1],
                        Golongan = stringArray[2]
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error RetrieveArrayFromFile: " + ex.Message.ToString());
            }

            return searchList;
        }
        #endregion

        #region STRUCT EMPLOYEE MODEL
        struct EmployeeModel
        {
            public string Nip { get; set; }
            public string Nama { get; set; }
            public string Golongan { get; set; }
        }
        #endregion
    }
}
