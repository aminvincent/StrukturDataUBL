using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortingDekstopApps
{
    #region CLASS MODEL
    public class EmployeeModel
    {
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public string Age { get; set; }
    }
    #endregion
    public class MasterProcessor
    {
        #region CONST PROPERTY
        public const string pathEmployee = "employee.csv";
        #endregion

        #region GET DATA LIST OF DATA FROM CSV
        public static List<EmployeeModel> loadCsvFileEmployee(string filePath)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    string[] stringArray = line.Split(';');
                    list.Add(new EmployeeModel
                    {
                        Code = stringArray[0],
                        EmployeeName = stringArray[1],
                        Age = stringArray[2]
                    });
                }

                reader.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error RetrieveArrayFromFile: " + ex.Message.ToString());
            }

            return list;
        }
        #endregion

        #region INSERT DATA INTO CSV FILE
        public static bool InsertDataIntoCsv(EmployeeModel model)
        {
            bool isInsert = false;

            try
            {
                string StringContent = model.Code + ";" + model.EmployeeName + ";" + model.Age + ";";

                if (!File.Exists(pathEmployee))
                {
                    File.WriteAllText(pathEmployee, StringContent);
                    isInsert = true;
                }
                else
                {
                    File.AppendAllText(pathEmployee, "\n" + StringContent);
                    isInsert = true;
                }
            }
            catch (Exception ex)
            {
                isInsert = false;
                throw new Exception("Error InsertDataIntoScv: " + ex.Message.ToString());
            }

            return isInsert;
        }
        #endregion

        #region UPDATE DATA INTO CSV FILE
        public static bool UpdateDataIntoCsv(string EmployeeCode, List<EmployeeModel> listOfModel, EmployeeModel model)
        {
            bool isUpdate = false;
            try
            {
                bool found = false;
                int i = 0;
                while (i <= listOfModel.Count)
                {
                    if (listOfModel[i].Code.ToLower() == EmployeeCode.ToLower())
                    {
                        found = true;
                        break;
                    }

                    i++;
                }

                if (found)
                {
                    listOfModel[i].EmployeeName = model.EmployeeName;
                    listOfModel[i].Age = model.Age;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in listOfModel)
                {
                    string StringContent = item.Code + ";" + item.EmployeeName + ";" + item.Age + ";";
                    sb.AppendLine(StringContent);
                }

                File.WriteAllText(pathEmployee, sb.ToString().Trim());
                isUpdate = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error UpdateDataIntoCsv: " + ex.Message.ToString());
            }

            return isUpdate;
        }
        #endregion

        #region GET CURRENT DATA USING SEARCHING
        public static EmployeeModel FindDataByCode(string EmployeeCode, List<EmployeeModel> listOfModel)
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                bool found = false;
                int b = 0;
                while (b <= listOfModel.Count)
                {
                    if (listOfModel[b].Code.ToLower() == EmployeeCode.ToLower())
                    {
                        found = true;
                        break;
                    }

                    b++;
                }

                if (found)
                {
                    model.Code = listOfModel[b].Code;
                    model.EmployeeName = listOfModel[b].EmployeeName;
                    model.Age = listOfModel[b].Age;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error FindDataByCode: " + ex.Message.ToString());
            }

            return model;
        }
        #endregion

        #region REMOVE ITEM IN LIST
        public static bool RemoveItemOnList(string EmployeeCode, List<EmployeeModel> ListOfModel)
        {
            bool isRemove = false;
            try
            {
                for (int i = 0; i < ListOfModel.Count; i++)
                {
                    if (ListOfModel[i].Code.ToLower() == EmployeeCode.ToLower())
                    {
                        ListOfModel.Remove(ListOfModel[i]);
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in ListOfModel)
                {
                    string StringContent = item.Code + ";" + item.EmployeeName + ";" + item.Age + ";";
                    sb.AppendLine(StringContent);
                }

                File.WriteAllText(pathEmployee, sb.ToString().Trim());
                isRemove = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error RemoveItemOnList: " + ex.Message.ToString());
            }

            return isRemove;
        }
        #endregion

        #region SORTING 
        public static List<EmployeeModel> BubleSortingEmployee(List<EmployeeModel> list, string sortingFlagOption)
        {
            try
            {
                EmployeeModel tcode;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int sort = 0; sort < list.Count - 1; sort++)
                    {
                        switch (sortingFlagOption)
                        {
                            case "code":
                                if (string.Compare(list[sort].Code, list[sort + 1].Code) == 1) //if a > b == 1
                                {
                                    tcode = list[sort + 1];
                                    list[sort + 1] = list[sort];
                                    list[sort] = tcode;
                                }
                                break;
                            case"name":
                                if (string.Compare(list[sort].EmployeeName, list[sort + 1].EmployeeName) == 1) //if a > b == 1
                                {
                                    tcode = list[sort + 1];
                                    list[sort + 1] = list[sort];
                                    list[sort] = tcode;
                                }
                                break;
                            case "age":
                                //convert string Age into int
                                if(Convert.ToInt32(list[sort].Age) > Convert.ToInt32(list[sort + 1].Age)) //if a> b 
                                {
                                    tcode = list[sort + 1];
                                    list[sort + 1] = list[sort];
                                    list[sort] = tcode;
                                }
                                break;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error BubleSortingEmployee: " + ex.Message.ToString());
            }

            return list;
        }
        #endregion
    }
}
