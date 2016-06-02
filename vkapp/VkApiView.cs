using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Windows.Forms;

namespace vkapp
{
    class VkApiView
    {
        public static void SendMessages(DataGridView dgw, int status, int sex, int sage, int fage, int destination, string message, bool checkAge)
        {
            for(int i = 0; i < dgw.RowCount; i++)
            {
                if(status == 0 && dgw.Rows[i].Cells[5].Value.ToString() == "Off")
                {
                    dgw.Rows.RemoveAt(i);
                    i--;
                    continue;
                }

                if (status == 1 && dgw.Rows[i].Cells[5].Value.ToString() == "On")
                {
                    dgw.Rows.RemoveAt(i);
                    i--;
                    continue;
                }

                if (sex == 0 && dgw.Rows[i].Cells[4].Value.ToString() == "Мужчина")
                {
                    dgw.Rows.RemoveAt(i);
                    i--;
                    continue;
                }

                if (sex == 1 && dgw.Rows[i].Cells[4].Value.ToString() == "Женщина")
                {
                    dgw.Rows.RemoveAt(i);
                    i--;
                    continue;
                }
                if (checkAge == true)
                {
                    int age = dgw.Rows[i].Cells[3].Value.ToString() == "---" ?
                        0 
                        : 
                        Convert.ToInt32(dgw.Rows[i].Cells[3].Value);

                    if (age < sage || age > fage)
                    {
                        dgw.Rows.RemoveAt(i);
                        i--;
                        continue;
                    }
                }

                string uid = dgw.Rows[i].Cells[0].Value.ToString();

                if(destination == 0)
                {
                    bool result = Program.api.SendMessage(uid, message);
                    if(result == false)
                    {
                        dgw.Rows.RemoveAt(i);
                        i--;
                    }
                }
                if (destination == 1)
                {
                    bool result = Program.api.SendMessage(uid, message);
                    if (result == false)
                    {
                        dgw.Rows.RemoveAt(i);
                        i--;
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
        }

        public static void FillAccountInfo(XmlDocument result, Control.ControlCollection controls)
        {
            controls["textBoxID"].Text = Program.api.UserId;

             controls["textBoxFirstName"].Text = result["response"]["user"]["first_name"].InnerText;

            controls["textBoxLastName"].Text = result["response"]["user"]["last_name"].InnerText;

            controls["textBoxSex"].Text = (result["response"]["user"]["sex"].InnerText == "2") ? "Мужчина" : "Женщина";


            if (result["response"]["user"].SelectSingleNode("bdate") == null)
            {
                controls["textBoxBdate"].Text = "д/р неизвестен";
            }
            else
            {
                string bdate = result["response"]["user"]["bdate"].InnerText;
                int countPoint = bdate.Split('.').Length - 1;

                controls["textBoxBdate"].Text = countPoint == 1 ? bdate + ".год" : bdate;

            }

        }
        public static void FillFriendsTable(XmlDocument result, DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (XmlNode node in result["response"].ChildNodes)
            {
                string userId = node["uid"].InnerText;
                string first_name = node["first_name"].InnerText;
                string last_name = node["last_name"].InnerText;

                string age = "---";
                if (node["bdate"] != null)
                {
                    string bdate = node["bdate"].InnerText;
                    int countPoint = bdate.Split('.').Length - 1;
                    if (countPoint == 2)
                    {
                        age = ((int)(DateTime.Now - Convert.ToDateTime(bdate)).TotalDays/365).ToString();
                    }
                }
                string sex = (node["sex"].InnerText == "2") ? "муж" : "жен";
                string status = (node["online"].InnerText == "0") ? "Off" : "On";
                dgv.Rows.Add(userId, first_name, last_name, age, sex, status);
            }
        }
    }
}
