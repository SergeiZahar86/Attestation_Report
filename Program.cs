using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Attestation_Report
{
    class Program
    {
        public static string numGuid = "A78A"; // первые четыре знака номера партии
        static void Main(string[] args)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // получаем строку подключения из конфига
            string sqlExpressionPart = $"SELECT * FROM tb_part WHERE part_id LIKE '{numGuid}%'"; // получаем сведения по партии вагонов
            string sqlExpressionCar = $"SELECT * FROM tb_car where part_id LIKE '{numGuid}%'";           // получаем 25 вагонов
            using (SqlConnection connection = new SqlConnection(connectionString)) // делаем подключение
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
                Console.WriteLine("------------------------------------------------------------------");


                SqlCommand command1 = new SqlCommand(sqlExpressionPart, connection); // делаем команду
                using (SqlDataReader reader1 = command1.ExecuteReader()) // класс для чтения строк из патока 
                {
                    if (reader1.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader1.GetName(0), reader1.GetName(1), reader1.GetName(2), reader1.GetName(3), reader1.GetName(4), reader1.GetName(5));

                        while (reader1.Read()) // построчно считываем данные
                        {
                            object part_id = reader1.GetValue(0);
                            object oper = reader1.GetValue(1);
                            object num_izm = reader1.GetValue(2);
                            object start_time = reader1.GetValue(3);
                            object end_time = reader1.GetValue(4);
                            object num_metering = reader1.GetValue(5);

                            Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5}", part_id, oper, num_izm, start_time, end_time, num_metering);
                        }
                    }
                }
                Console.WriteLine("------------------------------------------------------------");
                SqlCommand command2 = new SqlCommand(sqlExpressionCar, connection); // делаем команду
                using (SqlDataReader reader1 = command2.ExecuteReader()) // класс для чтения строк из патока 
                {
                    if (reader1.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}",
                            reader1.GetName(0), reader1.GetName(1), reader1.GetName(2),
                            reader1.GetName(3), reader1.GetName(4), reader1.GetName(5), reader1.GetName(6), reader1.GetName(7),
                            reader1.GetName(8), reader1.GetName(9), reader1.GetName(10), reader1.GetName(11), reader1.GetName(12),
                            reader1.GetName(13), reader1.GetName(14), reader1.GetName(15), reader1.GetName(16), reader1.GetName(17));

                        while (reader1.Read()) // построчно считываем данные
                        {
                            object part_id = reader1.GetValue(0);
                            object car_id = reader1.GetValue(1);
                            object num = reader1.GetValue(2);
                            object att_code = reader1.GetValue(3);
                            object tara = reader1.GetValue(4);
                            object tara_e = reader1.GetValue(5);
                            object zone_e = reader1.GetValue(6);
                            object cause_id = reader1.GetValue(7);
                            object carring_e = reader1.GetValue(8);
                            object att_time = reader1.GetValue(9);
                            object shipper = reader1.GetValue(10);
                            object consigner = reader1.GetValue(11);
                            object mat = reader1.GetValue(12);
                            object left_truck = reader1.GetValue(13);
                            object right_truck = reader1.GetValue(14);
                            object brutto = reader1.GetValue(15);
                            object netto = reader1.GetValue(16);
                            object weighing_time = reader1.GetValue(17);

                            Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8} \t{9}" +
                                " \t{10} \t{11} \t{12} \t{13} \t{14} \t{15} \t{16} \t{17}", part_id, car_id, num, att_code, tara,
                                tara_e, zone_e, cause_id, carring_e, att_time, shipper, consigner, mat, left_truck, right_truck,
                                brutto, netto, weighing_time);
                        }
                    }
                }
            }
            Console.WriteLine("Подключение закрыто...");
            Console.WriteLine();

            //Console.Read();




            List<User> users = new List<User>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../XMLFile1.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;



            // создаем новый элемент user
            XmlElement userElem = xDoc.CreateElement("user");
            // создаем атрибут name
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");
            // создаем элементы company и age
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode("Mark Zuckerberg");
            XmlText companyText = xDoc.CreateTextNode("Facebook");
            XmlText ageText = xDoc.CreateTextNode("30");


            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);
            xRoot.AppendChild(userElem);
            xDoc.Save("../../XMLFile1.xml");
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                User user = new User();
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        user.Name = attr.Value;
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "company")
                    {
                        user.Company = childnode.InnerText;
                    }
                    // если узел age
                    if (childnode.Name == "age")
                    {
                        user.Age = Int32.Parse(childnode.InnerText);
                    }
                }
                users.Add(user);
                Console.WriteLine();
            }
            foreach (User u in users)
                Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            Console.Read();
        }
    }
}
