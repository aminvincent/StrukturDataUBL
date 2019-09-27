using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingDekstopApps
{
    #region CLASS MODEL
    public class SalaryModel
    {
        public string SalaryId { get; set; }
        public string EmpCode { get; set; }
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
    }
    #endregion

    #region CLASS MODEL
    public class MergeModel
    {
        public string SalaryId { get; set; }
        public string EmpCode { get; set; }
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
    }
    #endregion


    public class SalaryProcessor
    {
        #region CONST PROPERTY
        public const string pathSalary = "salary.csv";
        #endregion

        #region GET DATA LIST OF DATA FROM CSV
        public static List<SalaryModel> loadCsvFileSalary(string filePath)
        {
            List<SalaryModel> list = new List<SalaryModel>();

            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    string[] stringArray = line.Split(';');
                    list.Add(new SalaryModel
                    {
                        SalaryId = stringArray[0],
                        EmpCode = stringArray[1],
                        Salary = stringArray[2],
                        Tax = stringArray[3],
                        Total = stringArray[4]
                    });
                }

                reader.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error loadCsvFileSalary: " + ex.Message.ToString());
            }

            return list;
        }
        #endregion

        #region MERGE ARRAY BETWEEN SALARY AND EMPLOYEE
        public static List<MergeModel> MergeSalary(List<SalaryModel> salList, List<EmployeeModel> empList)
        {
            List<MergeModel> lst = new List<MergeModel>();

            try
            {
                int sal;
                int emp;
                for (sal = 0; sal < salList.Count; sal++)
                {
                    for (emp = 0; emp < empList.Count; emp++)
                    {
                        if (salList[sal].EmpCode == empList[emp].Code)
                        {
                            lst.Add(new MergeModel
                            {
                                SalaryId = salList[sal].SalaryId,
                                EmpCode = salList[sal].EmpCode,
                                EmployeeName = empList[emp].EmployeeName,
                                Salary = salList[sal].Salary,
                                Tax = salList[sal].Tax,
                                Total = salList[sal].Total
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error MergeSalary: " + ex.Message.ToString());
            }

            return lst;
        }
        #endregion

        #region INSERT DATA
        public static bool InsertDataIntoCsv(SalaryModel model)
        {
            bool isInsert = false;

            try
            {
                string StringContent = model.SalaryId + ";" + model.EmpCode + ";" + model.Salary + ";" + model.Tax + ";" + model.Total + ";";

                if (!File.Exists(pathSalary))
                {
                    File.WriteAllText(pathSalary, StringContent);
                    isInsert = true;
                }
                else
                {
                    File.AppendAllText(pathSalary, "\n" + StringContent);
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
        public static bool UpdateDataIntoCsv(string salaryId, List<SalaryModel> listOfModel, SalaryModel model)
        {
            bool isUpdate = false;
            try
            {
                bool found = false;
                int i = 0;
                while (i <= listOfModel.Count)
                {
                    if (listOfModel[i].SalaryId.ToLower() == salaryId.ToLower())
                    {
                        found = true;
                        break;
                    }

                    i++;
                }

                if (found)
                {
                    listOfModel[i].EmpCode = model.EmpCode;
                    listOfModel[i].Salary = model.Salary;
                    listOfModel[i].Tax = model.Tax;
                    listOfModel[i].Total = model.Total;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in listOfModel)
                {
                    string StringContent = item.SalaryId + ";" + item.EmpCode + ";" + item.Salary + ";" + item.Tax + ";" + item.Total + ";";
                    sb.AppendLine(StringContent);
                }

                File.WriteAllText(pathSalary, sb.ToString().Trim());
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
        public static SalaryModel FindDataBySalaryId(string salaryId, List<SalaryModel> listOfModel)
        {
            SalaryModel model = new SalaryModel();
            try
            {
                bool found = false;
                int b = 0;
                while (b <= listOfModel.Count)
                {
                    if (listOfModel[b].SalaryId.ToLower() == salaryId.ToLower())
                    {
                        found = true;
                        break;
                    }

                    b++;
                }

                if (found)
                {
                    model.SalaryId = listOfModel[b].SalaryId.Trim();
                    model.EmpCode = listOfModel[b].EmpCode.Trim();
                    model.Salary = listOfModel[b].Salary.Trim();
                    model.Tax = listOfModel[b].Tax.Trim();
                    model.Total = listOfModel[b].Total.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error FindDataBySalaryId: " + ex.Message.ToString());
            }

            return model;
        }
        #endregion

        #region REMOVE ITEM IN LIST
        public static bool RemoveItemOnList(string salaryId, List<SalaryModel> ListOfModel)
        {
            bool isRemove = false;
            try
            {
                for (int i = 0; i < ListOfModel.Count; i++)
                {
                    if (ListOfModel[i].SalaryId.ToLower() == salaryId.ToLower())
                    {
                        ListOfModel.Remove(ListOfModel[i]);
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in ListOfModel)
                {
                    string StringContent = item.SalaryId + ";" + item.EmpCode + ";" + item.Salary + ";" + item.Tax + ";" + item.Total + ";";
                    sb.AppendLine(StringContent);
                }

                File.WriteAllText(pathSalary, sb.ToString().Trim());
                isRemove = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error RemoveItemOnList: " + ex.Message.ToString());
            }

            return isRemove;
        }
        #endregion

        #region MyRegion
        public static int LastSalaryId()
        {
            int LastValue = 0;
            try
            {
                var SalList = loadCsvFileSalary(pathSalary);
                LastValue = Convert.ToInt32(SalList[SalList.Count - 1].SalaryId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error LastSalaryId: " + ex.Message.ToString());
            }
            return LastValue;
        }
        #endregion

        #region SORTING 
        public static List<MergeModel> BubleSortingSalary(List<MergeModel> list, string sortingFlagOption)
        {
            try
            {
                MergeModel tcode;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int sort = 0; sort < list.Count - 1; sort++)
                    {
                        switch (sortingFlagOption)
                        {
                            case "code":
                                if (string.Compare(list[sort].EmpCode, list[sort + 1].EmpCode) == 1) //if a > b == 1
                                {
                                    tcode = list[sort + 1];
                                    list[sort + 1] = list[sort];
                                    list[sort] = tcode;
                                }
                                break;
                            case "name":
                                if (string.Compare(list[sort].EmployeeName, list[sort + 1].EmployeeName) == 1) //if a > b == 1
                                {
                                    tcode = list[sort + 1];
                                    list[sort + 1] = list[sort];
                                    list[sort] = tcode;
                                }
                                break;
                            case "salary":
                                //convert string Age into int
                                if (Convert.ToInt32(list[sort].Salary) > Convert.ToInt32(list[sort + 1].Salary)) //if a> b 
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
                throw new Exception("Error BubleSortingSalary: " + ex.Message.ToString());
            }

            return list;
        }
        #endregion
    }
}
