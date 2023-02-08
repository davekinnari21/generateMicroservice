using System;
using System.IO;  //read write file
using System.Collections.Generic;
using System.Globalization;  //for getting TextInfo
using Npgsql; //for database connection 
using System.Data; // datatable


namespace CSharpProgram
{
    class Program
    {
        static bool testFlag = true;    //set tetFlag to true if you want to generate phpunit test files(to generate test need atleast 3 rows data in dbtable)

        // Provide directory name with complete location.  
        /*    static string microservice = "Client";  //name of microservice
              static string ms_sub = "People";       //this is non plural name and it stays empty for same service name subfolder name
              static string lower_dash = "people";  //this is ms_sub with lower cash and dash 
              static string filename = microservice + ms_sub;
              static string pluralfilename = "Peoples";    //this is plural foldername
              static string subfolder = microservice + pluralfilename;   //this is plural sub foldername
              static string[] searchArr = { "vendorId", "homeloc", "modelId", "purchaseDate", "tracking" }; //this is extra search Id in array for get request
              static string dbtable = "client_peoples"; //database table name*/

        //with - example in foldername
     /*   static string microservice = "Inventory";    //name of microservice
        static string ms_sub = "Item";  //this is non plural name and it stays empty for same service name subfolder name
        static string lower_dash = "item"; //this is ms_sub with lower cash and dash 
        static string filename = microservice + ms_sub;
        static string pluralfilename = "Items";  //this is plural foldername
        static string subfolder = microservice + pluralfilename;     //this is plural sub foldername
        static string dbtable = "inventory_items"; //database table name
        static string[] searchArr = { "vendorId", "homeLocation", "modelId", "purchaseOrder", "trackingNumber", "datePurchasedTz" }; //this is extra search Id in array for get request. these should match with variable names*/
        
        static string microservice = "Inventory";    //name of microservice
        static string ms_sub = "MobileDevice";  //this is non plural name and it stays empty for same service name subfolder name
        static string lower_dash = "mobile-device"; //this is ms_sub with lower cash and dash 
        static string filename = microservice + ms_sub;
        static string pluralfilename = "MobileDevices";  //this is plural foldername
        static string subfolder = microservice + pluralfilename;     //this is plural sub foldername
        static string dbtable = "inventory_mobile_devices"; //database table name
        static string[] searchArr = {  "deviceTextId","name", "ebDeviceId","ebTrucks" }; //this is extra search Id in array for get request. these should match with variable names and inventory-service-gcv.conf file
        

        /*
        static string microservice = "Client";    //name of microservice
        static string ms_sub ="";             //this is non plural name and it stays empty for same service name subfolder name
        static string lower_dash= "client";    //this is ms_sub with lower cash and dash 
        static string filename = microservice + ms_sub;    
        static string subfolder = "Clients";    //this is plural sub foldername
        static string dbtable = "client_peoples"; //database table name
        static string[] searchArr = { "vendorId", "homeloc", "modelId", "purchaseDate", "tracking" }; //this is extra search Id in array for get request
*/
        static string fpath = "C:\\Users\\kdave\\Documents\\Projects\\" + microservice + "Microservice";
        //define uuid list for phpunit test
        public static List<Guid> list = new List<Guid>();

        static void Main(string[] args)
        {
            // Create a Dictionary key: New file/directory structure, Value: old file path to copy
            var filelist = new List<FileInfo>();

            filelist.Add(new FileInfo(fpath + "\\Api\\Controllers\\" + microservice.ToLower() + "\\" + lower_dash + "\\index.php", "C:\\Users\\kdave\\Documents\\Projects\\DemoMicroservice\\Api\\Controllers\\inventory\\cable-type\\index.php", "Controller"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Create" + filename + "\\Create" + filename + "Command.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\CreateInventoryCableType\CreateInventoryCableTypeCommand.php", "Create"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Create" + filename + "\\Create" + filename + "CommandHandler.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\CreateInventoryCableType\CreateInventoryCableTypeCommandHandler.php", "Handler"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Delete" + filename + "\\Delete" + filename + "Command.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\DeleteInventoryCableType\DeleteInventoryCableTypeCommand.php", "Command"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Delete" + filename + "\\Delete" + filename + "CommandHandler.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\DeleteInventoryCableType\DeleteInventoryCableTypeCommandHandler.php", "Handler"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Update" + filename + "\\Update" + filename + "Command.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\UpdateInventoryCableType\UpdateInventoryCableTypeCommand.php", "Create"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Commands\\Update" + filename + "\\Update" + filename + "CommandHandler.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Commands\UpdateInventoryCableType\UpdateInventoryCableTypeCommandHandler.php", "Handler"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "Detail\\Get" + filename + "DetailQuery.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeDetail\GetInventoryCableTypeDetailQuery.php", "Command"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "Detail\\Get" + filename + "DetailQueryHandler.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeDetail\GetInventoryCableTypeDetailQueryHandler.php", "Handler"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "Detail\\" + filename + "DetailVm.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeDetail\InventoryCableTypeDetailVm.php", "Vm"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "List\\Get" + filename + "ListQuery.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeList\GetInventoryCableTypeListQuery.php", "ListCommand"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "List\\Get" + filename + "ListQueryHandler.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeList\GetInventoryCableTypeListQueryHandler.php", "ListHandler"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Application\\Features\\" + subfolder + "\\Queries\\Get" + filename + "List\\" + filename + "ListVm.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Application\Features\InventoryCableTypes\Queries\GetInventoryCableTypeList\InventoryCableTypeListVm.php", "Vm"));
            filelist.Add(new FileInfo(fpath + "\\Core\\Domain\\Entities\\" + filename + ".php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Core\Domain\Entities\InventoryCableType.php", "Entity"));
            filelist.Add(new FileInfo(fpath + "\\Infrastructure\\Persistence\\Repositories\\" + filename + "Repository.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\Infrastructure\Persistence\Repositories\InventoryCableTypeRepository.php", "Repository"));
            //phpunit test if testFlag is set to true
            if(testFlag == true)
            {
                filelist.Add(new FileInfo(fpath + "\\test\\Datas\\" + filename + "Data.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\test\Datas\InventoryCableTypeData.php", "Data"));
                filelist.Add(new FileInfo(fpath + "\\test\\Mocks\\" + filename + "RepositoryMock.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\test\Mocks\InventoryCableTypeRepositoryMock.php", "Mock"));
                filelist.Add(new FileInfo(fpath + "\\test\\Tests\\" + filename + "Test.php", @"C:\Users\kdave\Documents\Projects\DemoMicroservice\test\Tests\InventoryCableTypeTest.php", "Test"));
            }

            foreach (FileInfo filepath in filelist)
            {
                try
                {
                    string dirname = Path.GetDirectoryName(filepath.newfile);
                    //Console.WriteLine(dirname);
                    if (!Directory.Exists(dirname))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(dirname);
                    }
                    if (!File.Exists(filepath.newfile))
                    {
                        File.Create(filepath.newfile).Dispose();
                    }

                    switch (filepath.type)
                    {
                        case "Controller":
                        case "Handler":
                        case "Command":
                        case "ListCommand":
                        case "ListHandler":
                            UpdateFile(filepath.newfile, filepath.oldfile, filepath.type);
                            break;
                        case "Entity":
                            UpdateEntity(filepath.newfile, filepath.oldfile);
                            break;
                        case "Vm":
                            UpdateVm(filepath.newfile, filepath.oldfile, "entity");
                            break;
                        case "Create":
                            UpdateVm(filepath.newfile, filepath.oldfile, "data");
                            break;
                        case "Repository":
                            UpdateRepository(filepath.newfile, filepath.oldfile);
                            break;
                        case "Test":
                            UpdateTestFile(filepath.newfile, filepath.oldfile, filepath.type);
                            break;
                        case "Data":
                            UpdateDataFile(filepath.newfile);
                            break;
                        case "Mock":
                            DefaultFile(filepath.newfile, filepath.oldfile);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Directory not created: {0}", ex.ToString());
                }
            }

            //Console.WriteLine("Directory Structure successfully created.");
        }


        //Generate phpunit test mock file or default file change
        public static void DefaultFile(string writefile, string readfile)
        {
            if (ms_sub == "")
            {
                ms_sub = microservice;
            }


            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace("InventoryCableTypes", subfolder);
                        line = line.Replace("InventoryCableType", filename);
                        line = line.Replace("inventory", microservice.ToLower());
                        line = line.Replace("Inventory", microservice);
                        line = line.Replace("cableType", ms_sub);
                        line = line.Replace("CableType", ms_sub);
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
        //Update phpunit Test file
        public static void UpdateTestFile(string writefile, string readfile, string type)
        {
            //NpgsqlConnection cn = DBConnect();
            Dictionary<string, string> dic = GetTableFields();

            if (ms_sub == "")
            {
                ms_sub = microservice;
            }


            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    bool detailFlag = false;
                    bool listFlag = false;

                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(line.Contains("$response->"))
                        {
                            if(detailFlag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    string key = kvp.Key;
                                    sw.WriteLine($"\t\t\t$this->assertEquals($_mockDatas[\"{list[0]}\"][\"{key}\"], $response->{value});");
                                }
                                detailFlag = true;
                            }
                            else
                            {
                                continue;
                            }

                        }else if (line.Contains("$response[0]"))
                        {
                            if (listFlag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    string key = kvp.Key;
                                    sw.WriteLine($"\t\t\t$this->assertEquals($_mockDatas[\"{list[0]}\"][\"{key}\"], $response[0]->{value});");
                                }
                                listFlag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }else
                        {
                            line = line.Replace("InventoryCableTypes", subfolder);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", ms_sub);
                            line = line.Replace("CableType", ms_sub);
                            if (line.Contains("DetailQuery("))
                            {
                                string substr = line.Substring(0, line.LastIndexOf("=>") + 2); //+2 will add '=>' in substring
                                substr += $"'{list[0]}'))));";
                                sw.WriteLine(substr);

                            }else
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }



        //updating index, handler and command file. if filetype is controller then index file will update and write all search id in it. 
        public static void UpdateFile(string writefile , string readfile,string filetype)
        {
            if (ms_sub == "")
            {
                ms_sub = microservice;
            }


            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("$params = array();") && filetype.Contains("Controller"))
                        {
                            sw.WriteLine(line);

                            if (searchArr.Length > 0)
                            {
                                for (int i = 0; i < searchArr.Length; i++)
                                {
                                    string id = searchArr[i];
                                    sw.WriteLine($"\n\t\t\t${id} = null;");
                                    sw.WriteLine($"\t\t\tif(isset($_GET['{id}']) && !empty($_GET['{id}']))");
                                    sw.WriteLine($"\t\t\t\t$params['{id}'] = $_GET['{id}'];");
                                }
                            }

                        } else if (filetype.Contains("ListCommand") && line.Contains("dirname(__FILE__)"))
                        {
                            if(searchArr.Length > 0)
                            {
                                for(int i =0; i < searchArr.Length; i++)
                                {
                                    string id = searchArr[i];
                                    sw.WriteLine($"\t\t\tif(isset($data->{id}))");
                                    sw.WriteLine($"\t\t\t\t$this->{id} = $data->{id};");

                                }
                            }
                            sw.WriteLine(line);
                        }
                        else if (filetype.Contains("ListCommand") && line.Contains("public $Path;"))
                        {
                            if (searchArr.Length > 0)
                            {
                                for (int i = 0; i < searchArr.Length; i++)
                                {
                                    string id = searchArr[i];
                                    sw.WriteLine($"\t\tpublic ${id};");

                                }
                            }
                            sw.WriteLine(line);
                        }
                        else
                        {
                            line = line.Replace("InventoryCableTypes", subfolder);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", ms_sub);
                            line = line.Replace("CableType", ms_sub);
                            sw.WriteLine(line);
                        }


                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
            
        }


        //update Data file for phpunit test
    public static void UpdateDataFile(string writefile)
    {
        //we need only three records to test in phpunit test
        string qry = $"select * from {dbtable} limit 3";
        DataTable dataTable = GetSqlQryResults(qry);
  
        try
        {
            StreamWriter sw = new StreamWriter(writefile);
            sw.WriteLine("<?php");
            sw.WriteLine("$_mockDatas = array(");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                int i = 0;
                string line;
                int colcount = dataTable.Columns.Count;

                //php unit test - Generate uuid for list 
                Guid uuid = Guid.NewGuid();
                list.Add(uuid);
                line = $"\"{uuid}\" => array(";

                foreach (var item in dataRow.ItemArray)
                {
                    string colname = dataTable.Columns[i].ColumnName;
                    string value = item.ToString();
                    line += $"'{colname}' => '{value}'";

                    if(i < colcount - 1)
                    {
                        line += ",";
                    }
                    i++;
                }
                line += "),";
                sw.WriteLine(line);
            }
        sw.WriteLine(");");
        sw.Close();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
        }
        
    }
        //Create,Update,ListVm,DetailVm
        public static void UpdateVm(string writefile, string readfile,string type)
        {
            //NpgsqlConnection cn = DBConnect();
            Dictionary<string, string> dic = GetTableFields();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    bool publicflag = false;
                    bool dataflag = false;
                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("public"))
                        {
                            if (publicflag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    sw.WriteLine($"\t\tpublic ${value};");
                                }
                                if(type == "data")
                                {
                                    sw.WriteLine("\t\tpublic $Path;");
                                }
                                publicflag = true;
                            }
                            else
                            {
                                if (line.Contains("__construct"))
                                {
                                    sw.WriteLine(line);
                                }
                                else
                                {
                                    continue;
                                }

                            }
                        }
                        else if (line.Contains($"${type}->"))
                        {
                            if (dataflag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    sw.WriteLine($"\t\t\tif(isset(${type}->{value}))");
                                    sw.WriteLine($"\t\t\t\t$this->{value} = ${type}->{value};");
                                }
                                dataflag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            line = line.Replace("InventoryCableTypes", subfolder);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", ms_sub);
                            line = line.Replace("CableType", ms_sub);
                            sw.WriteLine(line);
                        }

                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }

        }

        

        public static void UpdateEntity(string writefile, string readfile)
        {
            //NpgsqlConnection cn = DBConnect();
            Dictionary<string,string> dic = GetTableFields();

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    bool publicflag = false;
                    bool dataflag = false;
                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("public"))
                        {
                            if (publicflag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    sw.WriteLine($"\t\tpublic ${value};");
                                }
                                sw.Write("public function __construct($data = null)");
                                publicflag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }else if (line.Contains("$data['"))
                        {
                            if(dataflag == false)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    string value = kvp.Value;
                                    string key = kvp.Key;
                                    sw.WriteLine($"\t\t\tif(isset($data['{key}']))");
                                    sw.WriteLine($"\t\t\t\t$this->{value} = $data['{key}'];");
                                }
                                dataflag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            line = line.Replace("InventoryCableTypes", subfolder);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", filename);
                            line = line.Replace("CableType", filename);
                            sw.WriteLine(line);
                        }

                    }
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                //Console.Error.WriteLine("Error while file"+ readfile);
                Console.Error.WriteLine(ex.ToString());
            }

        }

        public static void UpdateRepository(string writefile, string readfile)
        {
            //NpgsqlConnection cn = DBConnect();
            Dictionary<string, string> dic = GetTableFields();
            string id = dic.Keys.First();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(readfile))
                {
                    string line;
                    StreamWriter sw = new StreamWriter(writefile);
                    while ((line = sr.ReadLine()) != null)
                    {
                        var keyList = string.Join(",", dic.Keys.ToArray());
                        if (line.Contains("public $selectAll"))
                        {
                            string str = "public $selectAll = 'SELECT ";

                            foreach (var key in dic.Keys)
                            {
                                str += $"{dbtable}.{key},";
                            }
                            str = str.Remove(str.Length - 1,1);
                            str += "';";
                            sw.WriteLine("\t" + str);

                        }else if (line.Contains("this->_db->prepare('UPDATE") && !line.Contains("SET is_deleted = true"))//for update
                        {
                            string str = $"$stmt = $this->_db->prepare('UPDATE {dbtable} SET ";
                            string stmt = "";
                            foreach (KeyValuePair<string, string> kvp in dic)
                            {
                                string value = kvp.Value;
                                string key = kvp.Key;
                                if (key.Contains("date_created_tz") || key.Contains("created_by_id"))
                                {
                                    continue;
                                }
                               /* else if (key.Contains("is_deleted"))
                                {
                                    str += "is_deleted = false,";
                                }*/
                                else if (key.Contains("date_last_modified_tz"))
                                {
                                    str += "date_last_modified_tz = current_timestamp,";
                                }
                                else
                                {
                                    string type = "PARAM_STR";
                                    //in update we are not updating id so excluding id here(e.g. inventory_item_id=:inventory_item_id)
                                    if (!key.Contains(id))
                                    {
                                        str += $"{key}=:{key} ,";
                                    }
                                    if (key.StartsWith("is"))
                                    {
                                        type = "PARAM_BOOL";
                                    }
                                    stmt += $"\t\t\t$stmt->bindValue(':{key}',${filename}->{value},\\PDO::{type});\n";
                                }

                            }
                            str = str.Remove(str.Length - 1, 1);
                            str += $" WHERE {id} = :{id}');";
                            sw.WriteLine("\t\t" + str);
                            sw.WriteLine(stmt);
                        }else if(line.Contains("GetAll(") && searchArr.Length > 0) //updating getAll function for multiple search string 
                        {
                            sw.WriteLine(line);//function GetAll
                            sw.WriteLine("\t\t$searchString=\"\";");
                            sw.WriteLine("\t\t$andFlag=false;");

                            string whereString = "\t\tif(";

                            for (int i = 0; i < searchArr.Length; i++)
                            {
                                string idstr = searchArr[i];
                                if(i == searchArr.Length - 1)
                                {
                                    whereString += $"isset(${idstr}))\n";
                                    whereString += "\t\t{\n";
                                }
                                else
                                {
                                    whereString += $"isset(${idstr}) || ";
                                }
                                
                                //find key for matching value
                                //string value = SnakeCaseToPascalCase(idstr);
                                string value = char.ToUpper(idstr[0])+idstr.Substring(1);
                                string key = dic.Where(kvp => kvp.Value.Contains(value)).Select(kvp => kvp.Key).FirstOrDefault();
                                sw.WriteLine($"\t\t${idstr} = $request->{idstr};");
                                sw.WriteLine($"\t\tif(isset(${idstr}))");
                                sw.WriteLine("\t\t{");
                                sw.WriteLine($"\t\t\tif($andFlag == true)");
                                sw.WriteLine($"\t\t\t\t$searchString .= \" and \";");
                                sw.WriteLine($"\t\t\t$searchString .= \" {key}='\".${idstr}.\"'\";");
                                sw.WriteLine($"\t\t\t$andFlag = true;");
                                sw.WriteLine("\t\t}");
                            }
                            whereString += $"\t\t\t$searchString = \" Where \". $searchString;\n";
                            sw.WriteLine(whereString);
                            sw.WriteLine("\t\t}");

                        }
                        
                        
                        //Create function
                        else if (line.Contains("INSERT INTO"))
                        {
                            Dictionary<string, string> dic2 = new Dictionary<string, string>(dic);
                            
                            dic2.Remove(id);
                            var allKeys = dic2.Keys.ToArray();
                            string str = $"$stmt = $this->_db->prepare('INSERT INTO {dbtable}(" + string.Join(",", allKeys) + ") Values(";
                            string stmt = "";
                            
                            foreach (KeyValuePair<string, string> kvp in dic2)
                            {
                                string value = kvp.Value;
                                string key = kvp.Key;
                               if (key.Contains("date_created_tz"))
                                {
                                    str += "current_timestamp,";
                                }
                                else if (key.Contains("is_deleted"))
                                {
                                    str += "false,";
                                }
                                else if (key.Contains("is_active"))
                                {
                                    str += "true,";
                                }else if (key.Contains("date_last_modified_tz") || key.Contains("last_modified_by_id"))
                                {
                                    str += "NULL,";
                                }
                                else
                                {
                                    string type = "PARAM_STR";
                                    str += $":{key} ,";
                                    if(key.StartsWith("is"))
                                    {
                                        type = "PARAM_BOOL";
                                     }
                                    stmt += $"\t\t\t$stmt->bindValue(':{key}',${filename}->{value},\\PDO::{type});\n";
                                }
                                
                            }
                            str = str.Remove(str.Length - 1, 1);
                            str += $")RETURNING {id} AS return_id ');";
                            sw.WriteLine("\t\t" + str);
                            sw.WriteLine(stmt);
                        }else if (line.Contains("$CableTypeId"))
                        {
                            line = line.Replace("inventory_cable_types", dbtable);
                            line = line.Replace("cable_type_id", id);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", filename);
                            line = line.Replace("CableType", filename);
                            sw.WriteLine(line);
                        }
                        else if (line.Contains("$stmt->bindValue"))//skipping because this lines written from database
                        {
                            continue;
                        }else {
                            line = line.Replace("inventory_cable_types", dbtable);
                            line = line.Replace("cable_type_id", id);
                            line = line.Replace("InventoryCableType", filename);
                            line = line.Replace("inventoryCableType", filename);
                            line = line.Replace("inventory", microservice.ToLower());
                            line = line.Replace("Inventory", microservice);
                            line = line.Replace("cableType", filename);
                            line = line.Replace("CableType", filename);
                            //Console.WriteLine(line);
                            sw.WriteLine(line);
                        }

                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

public static string SnakeCaseToPascalCase(string name)
        {
            string newstr = name.ToLower().Replace("_", " ");
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            string str = info.ToTitleCase(newstr);
            //check if field is boolean then name start with is___
            if (str.StartsWith("Is ")) { 
                str = str.Replace("Is ", "is ");
            }
            return str.Replace(" ", string.Empty); ;

        }

        public static NpgsqlConnection DBConnect()
        {
            // Database Connection string
            //Server=127.0.0.1
            string connString = "Server=127.0.0.1;port=5432;User Id=postgres;Password=password;Database=GCV-kdev";

            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            //Console.WriteLine(connString);
            return conn;
        }
    
        //Dictionary Key : table_field_name Value: Variable converted in PascalCase
        public static Dictionary<string,string> GetTableFields()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            NpgsqlConnection conn = DBConnect();
            conn.Open();
            // Define a query
            NpgsqlCommand command = new NpgsqlCommand("SELECT column_name FROM information_schema.columns where table_name = '" + dbtable + "' order by ordinal_position", conn);

            // Execute the query and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            // Output rows
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dic.Add(dr[i].ToString().Trim(), SnakeCaseToPascalCase(dr[i].ToString()).Trim());
                }
            }
            conn.Close();
            return dic;
        }

        //Query
        public static DataTable GetSqlQryResults(string qry)
        {
            NpgsqlConnection conn = DBConnect();
            conn.Open();
            // Define a query
            NpgsqlCommand command = new NpgsqlCommand(qry, conn);

            // Execute the query and obtain a result set
            using var reader = command.ExecuteReader();
            using var dataTable = new DataTable();
            dataTable.Load(reader);

            conn.Close();
            return dataTable;
        }

        public class FileInfo
        {
            public string newfile { get; set; }
            public string oldfile { get; set; }
            public string type { get; set; }

            public FileInfo(string nfile, string ofile, string filetype)
            {
                this.newfile = nfile;
                this.oldfile = ofile;
                this.type = filetype;
            }
        }
    }
}