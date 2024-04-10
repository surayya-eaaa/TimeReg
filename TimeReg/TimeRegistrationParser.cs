using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace EmployeeTimeTracker
{
    public class TimeRegistrationParser
    {
        public static List<TimeRegistrationModel> CSVtoModel(string path)
        {
            List<TimeRegistrationModel> list = new List<TimeRegistrationModel>();

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    //Process row
                    TimeRegistrationModel trm = new TimeRegistrationModel();

                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        try
                        {
                            trm.Name = fields[0];
                            trm.Date = DateTime.ParseExact(fields[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            trm.Hours = Double.Parse(fields[2]);
                            trm.UserDefinedRegistration = "Normal Row";
                        }
                        catch (System.FormatException)
                        {
                            trm.Name = "?";
                            trm.Date = DateTime.Now;
                            trm.Hours = 0.0;
                            string userdef = "";
                            foreach (var item in fields)
                            {
                                userdef += item.ToString() + " ";
                            }

                            trm.UserDefinedRegistration = userdef;
                        }
                        list.Add(trm);
                    }
                }
                return list;
            }
        }
    }
}