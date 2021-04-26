using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace ProgramStore.DataWork
{
    static class ProgramDataService
    {

        public static string FILE_PATH = @"..\..\Data\data.json";
        public static JsonSerializerOptions JSON_OPTIONS = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public static void AddProgram(Program newGame)
        {
            try
            {
                using (StreamWriter jsonFile = new StreamWriter(GetPath(), true))
                {
                    string jsonDataAboutGame = JsonSerializer.Serialize<Program>(newGame, JSON_OPTIONS);
                    jsonFile.WriteLine(jsonDataAboutGame);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        } 
        public static void ClearFile()
        {
            try
            {
                using (StreamWriter jsonFile = new StreamWriter(GetPath()))
                {
                    jsonFile.WriteLine("");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }
        public static List<Program> FindAll()
        {
            List<Program> programs = new List<Program>();
            try
            {
                using (StreamReader jsonFile = new StreamReader(GetPath()))
                {
                    string bufForJsonString = "";
                    while (!jsonFile.EndOfStream)
                    {
                        bufForJsonString += jsonFile.ReadLine();
                        if (bufForJsonString.Length > 0 && bufForJsonString.Last() == '}')
                        {
                            Program program = JsonSerializer.Deserialize<Program>(bufForJsonString, JSON_OPTIONS);
                            bufForJsonString = "";
                            programs.Add(program);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return programs;
        }
        public static List<Program> FindByName(string findName)
        {
            try
            {
                List<Program> resultPrograms = new List<Program>();
                List<Program> programs = FindAll();

                if (programs.Count > 0)
                {
                    foreach (var c in programs)
                    {
                        if (c.Name.Contains(findName))
                        {
                            resultPrograms.Add(c);
                        }
                    }
                }

                return resultPrograms;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return null;
        }
        public static bool RemoveProgram(Program program)
        {
            try
            {
                List<Program> programs = FindAll();
                if (programs.Remove(program))
                {
                    ClearFile();
                    foreach (var c in programs) 
                    {
                        AddProgram(c);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return false;
        }
        public static bool  UpdateDataAboutProgram(Program baseData, Program newData)
        {
            try
            {
                if (RemoveProgram(baseData))
                {
                    AddProgram(newData);
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return false;
        }
        private static string GetPath()
        {
            State langState = State.GetState();
            return FILE_PATH;
        }
        
    }
}
