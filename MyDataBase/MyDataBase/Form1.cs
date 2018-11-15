using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyDataBase
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder builder;
        DataTable table;
        BindingSource binding;

        int pageNum;
        int pageSize;
        public Form1()
        {
            InitializeComponent();
            pageNum = 1;
            pageSize = 4;
            Connect();
            SelectAll();
        }

        private void LeftClick(object sender, EventArgs e)
        {
            if (pageNum != 1)
                pageNum--;
            button3.Text = pageNum.ToString() + " page";
            SelectAll();
        }

        private void RightClick(object sender, EventArgs e)
        {
            if (grid.DisplayedRowCount(true) > 1)
                pageNum++;
            button3.Text = pageNum.ToString() + " page";
            SelectAll();
        }

        private void Search(object sender, EventArgs e)
        {
            string text = searchText.Text;

            if (text == "") return;

            connection.Open();

            DoIt("SELECT * FROM persons WHERE FirstName = '" + text + "'");

            connection.Close();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            adapter.Update(table);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            string msg = grid.SelectedRows[0].ToString();

            bool qwe = false;
            string q = "";

            for (int i = 0; i < msg.Length; ++i)
            {
                if (msg[i] == '}') qwe = false;

                if (qwe)
                {
                    q = q + msg[i];
                }

                if (msg[i] == '=') qwe = true;
            }

            int index = int.Parse(q);

            index++;

            DoIt("DELETE FROM persons WHERE cid = " + index.ToString());
        }
        private void CreateClick(object sender, EventArgs e)
        {
            string name = nameText.Text;

            string number = numberText.Text;
            string currentDate = DateTime.Today.ToShortDateString();

            string _name = "'" + name + "'";

            string[] values = currentDate.Split('.');
            string date = values[2] + "-" + values[1] + "-" + values[0];

            string _date = "'" + date + "'";
            string _number = "'" + number + "'";

            DoIt("INSERT INTO persons(`cid`, `FirstName`, `CreationDate`, `Telephone`) " +
                 "VALUES ('8', " + _name + "," + _date + "," + _number + ")");

            SelectAll();

        }

        private void SortClickAsc(object sender, EventArgs e)
        {
            connection.Open();

            DoIt("SELECT * FROM persons ORDER BY CreationDate ASC");

            connection.Close();
        }

        private void SortClickDesc(object sender, EventArgs e)
        {
            connection.Open();

            DoIt("SELECT * FROM persons ORDER BY CreationDate DESC");

            connection.Close();
        }

        private void Connect()
        {
            connection = new MySqlConnection(
                "SERVER=localhost; SslMode=none;" +
                "DATABASE = mydb;" +
                "UID = root;" +
                "PASSWORD = ");
        }

        private void SelectAll()
        {
            connection.Open();

            DoIt("SELECT * FROM persons WHERE cid BETWEEN " + ((pageNum - 1) * pageSize + 1).ToString()
                + " AND " + (pageNum * pageSize).ToString());

            connection.Close();
        }

        private void DoIt(string msg)
        {
            adapter = new MySqlDataAdapter(msg, connection);
            builder = new MySqlCommandBuilder(adapter);

            if (!msg.Contains("INSERT"))
            {
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.DeleteCommand = builder.GetUpdateCommand();
                adapter.InsertCommand = builder.GetUpdateCommand();
            }

            table = new DataTable();
            adapter.Fill(table);
            binding = new BindingSource();
            binding.DataSource = table;
            bindingNavigator1.BindingSource = binding;
            grid.DataSource = binding;
        }

        private void numberText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}