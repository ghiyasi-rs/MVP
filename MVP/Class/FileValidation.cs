using MVP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MVP.Class
{

    public class FileValidation
    {
        public bool IsValidFile(string FilePath)
        {

            string sportName = "";
            string[] files;
            string[] line;
            int ValidFieldItem;
            try
            {
                if (FilePath != null)
                {
                    if (!File.Exists(FilePath))
                        return false; //file not found
                    

                    if (Path.GetExtension(FilePath) != ".txt")
                        return false;// file format not valid
                    else
                    {
                        files = File.ReadAllLines(FilePath);
                        sportName = files[0];
                    }

                    if (!Enum.IsDefined(typeof(Sports), sportName))
                        return false; // sport name not valid

                    if (sportName == "BASKETBALL")
                    {                        
                        ValidFieldItem = Basketball.ValidFieldItem;
                        for (int i = 1; i < files.Length; i++)
                        {
                            line = files[i].Split(";");
                            if (line.Length < ValidFieldItem)
                                return false; // item in line not valid
                        }
                    }

                    if (sportName == "HANDBALL")
                    {                        
                        ValidFieldItem = Handball.ValidFieldItem;

                        for (int i = 1; i < files.Length; i++)
                        {
                            line = files[i].Split(";");
                            if (line.Length < ValidFieldItem)
                                return false;
                        }
                    }
                    return true;
                }
                else
                return false;
            }
            catch
            {
                return false; // error
            }
        }
    }
}
