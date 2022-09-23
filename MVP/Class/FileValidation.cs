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
                        return false;



                    if (Path.GetExtension(FilePath) != ".txt")
                        return false;
                    else
                    {
                        files = File.ReadAllLines(FilePath);
                        sportName = files[0];
                    }

                    if (!Enum.IsDefined(typeof(Sports), sportName))
                        return false;

                    if (sportName == "BASKETBALL")
                    {
                        BASKETBALL _basketBall = new BASKETBALL();
                        ValidFieldItem = _basketBall.ValidFieldItem;
                        for (int i = 1; i < files.Length; i++)
                        {
                            line = files[i].Split(";");
                            if (line.Length < ValidFieldItem)
                                return false;
                        }
                    }

                    if (sportName == "HANDBALL")
                    {
                        HANDBALL _basketBall = new HANDBALL();
                        ValidFieldItem = _basketBall.ValidFieldItem;
                        for (int i = 1; i < files.Length; i++)
                        {
                            line = files[i].Split(";");
                            if (line.Length < ValidFieldItem)
                                return false;
                        }
                    }
                        

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
