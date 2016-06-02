using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace vkapp
{
    public partial class FormWork : Form
    {
        XmlDocument myFriends = new XmlDocument();
        public FormWork()
        {
            InitializeComponent();
        }

        

        private void FormWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            VkApiView.SendMessages
                (
                    dataGridViewMessage,
                    comboBoxStatus.SelectedIndex,
                    comboBoxSex.SelectedIndex,
                    (int)numericUpDownStartAge.Value,
                    (int)numericUpDownEndAge.Value,
                    comboBoxDestenation.SelectedIndex, 
                    richTextBoxMessageText.Text,
                    checkBoxAge.Checked
                );

            MessageBox.Show("Все сообщения успешно отправлены");
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            dataGridViewMessage.Rows.Clear();

            for(int i = 0; i < dataGridViewMessage.RowCount; i++)
            {
                dataGridViewMessage.Rows.Add(
                    dataGridViewFriends.Rows[i].Cells[0].Value,
                    dataGridViewFriends.Rows[i].Cells[1].Value,
                    dataGridViewFriends.Rows[i].Cells[2].Value,
                    dataGridViewFriends.Rows[i].Cells[3].Value,
                    dataGridViewFriends.Rows[i].Cells[4].Value,
                    dataGridViewFriends.Rows[i].Cells[5].Value
                    );
            }
        }

        private void dataGridViewFriends_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddOne_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<dataGridViewFriends.SelectedRows.Count;i++)
            {
                dataGridViewMessage.Rows.Add
                    (
                        dataGridViewFriends.SelectedRows[i].Cells[0].Value,
                        dataGridViewFriends.SelectedRows[i].Cells[1].Value,
                        dataGridViewFriends.SelectedRows[i].Cells[2].Value,
                        dataGridViewFriends.SelectedRows[i].Cells[3].Value,
                        dataGridViewFriends.SelectedRows[i].Cells[4].Value,
                        dataGridViewFriends.SelectedRows[i].Cells[5].Value
                    );
            }
        }

        private void FormWork_Shown(object sender, EventArgs e)
        {
            VkApiView.FillAccountInfo
                (
                Program.api.AccountGetInfo(),
                this.Controls
                );
            
            myFriends = Program.api.FriendsGet(Program.api.UserId);

            VkApiView.FillFriendsTable
                (
                myFriends,
                dataGridViewFriends
                );
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            VkApiView.FillFriendsTable
                (
                myFriends,
                dataGridViewFriends
                );
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();

            for (int i = 0; i < dataGridViewFriends.RowCount; i++)
            {
                if(dataGridViewFriends.Rows[i].Cells[0].Value.ToString().ToLower().Contains(searchText) == false &&
                   dataGridViewFriends.Rows[i].Cells[1].Value.ToString().ToLower().Contains(searchText) == false &&
                   dataGridViewFriends.Rows[i].Cells[2].Value.ToString().ToLower().Contains(searchText) == false &&
                   dataGridViewFriends.Rows[i].Cells[3].Value.ToString().ToLower().Contains(searchText) == false &&
                   dataGridViewFriends.Rows[i].Cells[4].Value.ToString().ToLower().Contains(searchText) == false &&
                   dataGridViewFriends.Rows[i].Cells[5].Value.ToString().ToLower().Contains(searchText) == false )
                {
                    dataGridViewFriends.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
