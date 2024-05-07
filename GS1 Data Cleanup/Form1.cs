using GS1_Data_Cleanup.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS1_Data_Cleanup
{
    public partial class Form1 : Form
    {
        SqlConnection myConn;
        int PECount = 0;
        int OCRCount = 0;
        bool backToggle = false;
        public class ScanEvent
        {
            public Int64 id;
            public string TestName;
            public string SymbolSet;
            public string ScannerName;
            public DateTime _DateTime;
            public string ScannerData;
            public string ComputerName;
        }
        List<ScanEvent> myScans = new List<ScanEvent>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { this.Text += " (" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + ")"; } catch { }
            LoadSettings();

        }


        #region Cross threading
        delegate void UpdateTestD(string data);
        private void UpdateTest(string data)
        {
            if(lbTests.InvokeRequired)
            {
                UpdateTestD d = new UpdateTestD(UpdateTest);
                lbTests.Invoke(d, new object[] {data});
            }
            else
            {
                if (data == "")
                    lbTests.Items.Clear();
                else
                    lbTests.Items.Add(data);    
            }
        }

        delegate void UpdateStatusD(string data);
        private void UpdateStatus(string data)
        {
            if (lbStatus.InvokeRequired)
            {
                UpdateStatusD d = new UpdateStatusD(UpdateStatus);
                lbStatus.Invoke(d, new object[] { data });
            }
            else
            {
                if(lbStatus.Items.Count==0)
                    lbStatus.Items.Add(data);
                else
                    lbStatus.Items.Insert(0, data);

                if (lbStatus.Items.Count > 3)
                    lbStatus.Items.RemoveAt(3);
            }
        }

        delegate void UpdateDataGridD(ScanEvent data);
        private void UpdateDataGrid(ScanEvent data)
        {
            if(dataGridView1.InvokeRequired)
            {
                UpdateDataGridD d = new UpdateDataGridD(UpdateDataGrid);
                dataGridView1.Invoke(d, new object[] { data });
            }   
            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = data.id;
                row.Cells[1].Value = data.TestName;
                row.Cells[2].Value = data.SymbolSet;
                row.Cells[3].Value = data.ScannerName;
                row.Cells[4].Value = data._DateTime;
                row.Cells[5].Value = data.ScannerData;
                row.Cells[6].Value = data.ComputerName;

                dataGridView1.Rows.Add(row);
                //int rowIndex = dataGridView1.Rows.Count - 1;    
                //if (rowIndex>1 &&
                //    backToggle && 
                //    dataGridView1.Rows[rowIndex].Cells[0].Value!= dataGridView1.Rows[rowIndex-1].Cells[0].Value
                //   )
                //{
                //    backToggle
                //}
            }
        }

        #endregion

        #region
        private void LoadSettings()
        {
            txtConnection.Text = Settings.Default.connectionString;
        }

        private void SaveSettings()
        {
            Settings.Default.connectionString = txtConnection.Text;
            Settings.Default.Save();
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                myConn= new SqlConnection(txtConnection.Text);
                myConn.Open();
                UpdateStatus("Connected...");
                LoadTests();
                btnConnect.Enabled = false;
                btnReload.Enabled = true;
                btnProcess.Enabled = true;
                btnRaw.Enabled = true;
                Settings.Default.connectionString =txtConnection.Text;
                Settings.Default.Save();    

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if(lbTests.SelectedIndex == -1)
            {
                MessageBox.Show("Select a test","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            PECount = 0;   
            OCRCount = 0;
            myScans.Clear();
            dataGridView1.Rows.Clear(); 
            btnProcess.Enabled = false; 
            string mySQL = "select id, Data_TestName, Data_SymbolSet, Data_ScannerName,Data_DateTime,Data_ScannerData," +
                           "Data_ComputerName from testdata where data_testname = '" + lbTests.SelectedItem + "' and _status is null order by id";
            SqlCommand myCMD = new SqlCommand(mySQL,myConn);
            try
            {
                SqlDataReader myReader = myCMD.ExecuteReader();
                UpdateStatus("Test data retreived...");
                Cursor.Current = Cursors.WaitCursor;
                while(myReader.Read()) 
                {
                    ScanEvent _tmp = new ScanEvent();
                    _tmp.id = Convert.ToInt64(myReader[0].ToString());
                    _tmp.TestName = myReader[1].ToString();
                    _tmp.SymbolSet = myReader[2].ToString().Replace("\n","");
                    _tmp.ScannerName = myReader[3].ToString();
                    _tmp._DateTime = Convert.ToDateTime(myReader[4].ToString());
                    _tmp.ScannerData = myReader[5].ToString();
                    _tmp.ComputerName = myReader[6].ToString();

                    myScans.Add(_tmp);

                    if(_tmp.ScannerData=="PE event") PECount++;

                    if (_tmp.ScannerName == "delimiter" || PECount == 81)
                    {
                        if (PECount == 81) { PECount = 1; }
                        else { PECount = 0; }
                        UpdateDataGrid(_tmp);
                        
                    }
                }

                myReader.Close();
                UpdateDataGrid(myScans[myScans.Count - 1]); 

                UpdateStatus(lbTests.SelectedItem + " processing completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myCMD.Dispose();
            }
            CheckCardIDs();
            Cursor.Current = Cursors.Default;
            btnProcess.Enabled = true;
        }

        private void LoadTests()
        {            
            string mySQL = "select distinct data_testname from testdata order by data_testname";
            SqlCommand myCMD = new SqlCommand(mySQL, myConn);
            try
            { 
                SqlDataReader myReader = myCMD.ExecuteReader();
                while(myReader.Read()) 
                {
                    UpdateTest(myReader[0].ToString());
                }
                myReader.Close();
                UpdateStatus("Tests loaded...");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateStatus("Test load failed");
                UpdateTest("Test load failed");
            }
            finally
            { 
                myCMD.Dispose(); 
            }
        }

        private void WriteSQL(string data)
        {
            try
            {
                using (System.IO.StreamWriter _out = new System.IO.StreamWriter("c:\\temp\\try.txt", true))
                {
                    _out.WriteLine(data);
                }
            }
            catch(Exception ex1)
            { MessageBox.Show(ex1.Message); }   

            SqlCommand myCMD = new SqlCommand(data, myConn);
            try
            {
                myCMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myCMD.Dispose();
            }
            

        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            UpdateTest("");
            LoadTests();
        }

        private void CheckCardIDs()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowCount = dataGridView1.Rows.Count;

                bool grayToggle = false;
                for (int j = 0; j <rowCount-2; j+=2)
                {
                    if(grayToggle)
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.LightBlue;
                        dataGridView1.Rows[j+1].DefaultCellStyle.BackColor = Color.LightBlue;
                        grayToggle = !grayToggle;
                    }
                    else
                        grayToggle = !grayToggle;
                }


                string currentCard = ""; // dataGridView1.Rows[0].Cells[0].Value.ToString();
                bool toggle = false;

                for (int i = 0; i < rowCount - 2; i++)
                {
                    currentCard = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if(dataGridView1.Rows[i + 1].Cells[2].Value.ToString() != currentCard )
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;                        
                    }
                    else
                        i++;
                }
            }

        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            /*
             *  declare @startid as int =3487423; 
                declare @stopid as int = 3487736;
                declare @cardid as varchar(50) ='ID0236';
                --select * from testdata where id>=@startid and id<=@stopid
                update testdata set Data_SymbolSet = @cardid where id >=@startid and id <=@stopid;

                update testdata set Data_ScannerData= @cardid
                where id >=@startid and id <=@stopid and Data_ComputerName = 'Omron1';
             */

            //if((dataGridView1.Rows.Count) % 2 !=0)  //minus 1 for "add" row
            //{
            //    MessageBox.Show("There are an uneven number of rows", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            Cursor.Current = Cursors.WaitCursor;

            int rowCount = dataGridView1.Rows.Count;
           
            for(int i = 0; i < rowCount-4; i+=2) 
            {
                string id1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int id2 = Convert.ToInt32(dataGridView1.Rows[i+2].Cells[0].Value.ToString())-1;
                string cardID = dataGridView1.Rows[i].Cells[2].Value.ToString().Replace("\r","").Replace("\n","").Replace("\r\n","");
                string computerName = dataGridView1.Rows[rowCount - 2].Cells[6].Value.ToString();

                string mySQL = "update testdata set Data_SymbolSet = '" + cardID + "'";

                if (cardID == "xxxxxx")
                    mySQL = mySQL + " , _status = 1 ";
                mySQL = mySQL + " where id >= " + id1.ToString() +
                               " and id <= " + id2.ToString() +
                               " and data_testname = '" + lbTests.SelectedItem.ToString()  + "'; " +
                               "update testdata set Data_ScannerData= '" + cardID + "' where id >= " + id1.ToString() +
                           " and id <= " + id2.ToString() + " and Data_ComputerName = 'Omron1';"; ;

                WriteSQL(mySQL);
            }
            string id3 = dataGridView1.Rows[rowCount-4].Cells[0].Value.ToString();
            int id4 = Convert.ToInt32(dataGridView1.Rows[rowCount-2].Cells[0].Value.ToString());
            string computerName2 = dataGridView1.Rows[rowCount - 2].Cells[6].Value.ToString();
            string cardID2 = dataGridView1.Rows[rowCount-2].Cells[2].Value.ToString().Replace("\r", "").Replace("\n", "").Replace("\r\n", "");

            string mySQL2 = "update testdata set Data_SymbolSet = '" + cardID2 +
                           "' where id >= " + id3.ToString() +
                           " and id <= " + id4.ToString() +
                           " and data_testname = '" + lbTests.SelectedItem.ToString() + "'; " +
                           "update testdata set Data_ScannerData= '" + cardID2 + "' where id >= " + id3.ToString() + 
                           " and id <= " + id4.ToString() + " and Data_ComputerName = '" + computerName2 + "';";

            WriteSQL(mySQL2);
            UpdateStatus("Done generating SQL Statements...");
            btnProcess.PerformClick();
            Cursor.Current = Cursors.Default;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-2; i+=2)
            {
                string id1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int id2 = Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value.ToString());
                string cardID = dataGridView1.Rows[i].Cells[2].Value.ToString();

                if (cardID != "xxxxxx")
                    continue;

                string mySQL = "update testdata set _status = 1 where id >= " + id1.ToString() +
                               " and id <= " + id2.ToString() + " and data_testname = '" + lbTests.SelectedItem.ToString() + "'";
                SqlCommand myCMD = new SqlCommand(mySQL, myConn);
                try
                {
                    myCMD.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myCMD.Dispose();
                }
            }
        }

        private void lbTests_DoubleClick(object sender, EventArgs e)
        {
            btnProcess.PerformClick();
        }

        private void btnRaw_Click(object sender, EventArgs e)
        {
            Form2 myFrm = new Form2();
            myFrm.TestName = lbTests.SelectedItem.ToString();
            Cursor.Current = Cursors.WaitCursor;
            myFrm.Show();
        }
    }
}
