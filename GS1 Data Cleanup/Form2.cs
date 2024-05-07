using GS1_Data_Cleanup.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GS1_Data_Cleanup
{
    public partial class Form2 : Form
    {
        public string TestName = "";
        SqlConnection myConn2;

        public class CardInfo
        {
            public string ID = "";
            public string Symbology = "";
            public string data_scannername = "";
            public string data_scannerdata = "";
            public string data_computername = "";
        }
        List<CardInfo> cards = new List<CardInfo>();
        List<string> StartAndEndID = new List<string>();

        public class dataIDdictElement
        {
            public string data = "";
            public string computerName="";
            public string cardId = "";
        }
        // List to store all the data that is read from the reference csv file
        List<dataIDdictElement> dataIDdictElements= new List<dataIDdictElement>();

        // Dictionary that stores the <Key:scanned data value:<key:computer name value:1>>
        Dictionary<string, List<string>> data_ID_numDict = new Dictionary<string, List<string>>();
        HashSet<string> cardIDSinTest = new HashSet<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text += " - " + TestName;

            try
            {
                myConn2 = new SqlConnection(Settings.Default.connectionString);
                myConn2.Open();

                string mySQL = "select id, data_symbolset, data_scannername,data_scannerdata,data_computername from testdata where data_testname = '" + TestName + "' and _status is null order by id;";
                SqlCommand myCMD = new SqlCommand(mySQL, myConn2);
                try 
                {
                    SqlDataReader myReader = myCMD.ExecuteReader();
                    while(myReader.Read()) 
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                        row.Cells[0].Value = myReader[0].ToString();
                        row.Cells[1].Value = myReader[1].ToString();
                        row.Cells[2].Value = myReader[2].ToString();
                        row.Cells[3].Value = myReader[3].ToString();
                        row.Cells[5].Value = myReader[4].ToString();
                        dataGridView1.Rows.Add(row);
                    }
                    try
                    {
                        LoadExpected(Settings.Default.expected);
                    }
                    catch { }

                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    myCMD.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { myConn2.Close(); }
            Cursor.Current = Cursors.Default;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try { myConn2.Close(); } catch { }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Cursor.Current= Cursors.WaitCursor;
            dataGridView1.Rows.Clear();

            try
            {
                myConn2 = new SqlConnection(Settings.Default.connectionString);
                myConn2.Open();

                string mySQL = "select id, data_symbolset, data_scannername,data_scannerdata,data_computername from testdata where data_testname = '" + TestName + "' and data_computername in ('echo1','omron1', 'alpha4')  and _status is null order by id;";
                SqlCommand myCMD = new SqlCommand(mySQL, myConn2);
                try
                {
                    SqlDataReader myReader = myCMD.ExecuteReader();
                    while (myReader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                        row.Cells[0].Value = myReader[0].ToString();
                        row.Cells[1].Value = myReader[1].ToString();
                        row.Cells[2].Value = myReader[2].ToString();
                        row.Cells[3].Value = myReader[3].ToString();
                        row.Cells[5].Value = myReader[4].ToString();
                        dataGridView1.Rows.Add(row);
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    myCMD.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { myConn2.Close(); }
            Cursor.Current = Cursors.Default;
        }

        // Fetches the data from the database and loads them in the datagrid
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.Rows.Clear();

            try
            {
                myConn2 = new SqlConnection(Settings.Default.connectionString);
                myConn2.Open();

                string mySQL = "select id, data_symbolset, data_scannername,data_scannerdata,data_computername from testdata where data_testname = '" + TestName + "' and _status is null order by id;";
                SqlCommand myCMD = new SqlCommand(mySQL, myConn2);
                try
                {
                    SqlDataReader myReader = myCMD.ExecuteReader();
                    while (myReader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                        row.Cells[0].Value = myReader[0].ToString();
                        row.Cells[1].Value = myReader[1].ToString();
                        row.Cells[2].Value = myReader[2].ToString();
                        row.Cells[3].Value = myReader[3].ToString();
                        row.Cells[5].Value = myReader[4].ToString();
                        dataGridView1.Rows.Add(row);
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    myCMD.Dispose();
                }
                LoadExpected(openFileDialog1.FileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { myConn2.Close(); }
            Cursor.Current = Cursors.Default;
        }


        //Loads the data into the data grid from the csv file
        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = Settings.Default.expected;
            openFileDialog1.ShowDialog();
            LoadExpected(openFileDialog1.FileName);
        }

        private void LoadExpected(string file)
        {
            
            if (file != "")
            {
                try
                {
                    // Reads the contents from the csv file that has data,cardid,computername
                    // and loads them into the list of cards
                    using (System.IO.StreamReader _in = new System.IO.StreamReader(file))
                    {
                        while (_in.Peek() != -1)
                        {
                            string data = _in.ReadLine();
                            if (data is null) continue;

                            string[] info = data.Split(new char[] { ',' });

                            dataIDdictElement tmp = new dataIDdictElement();
                            tmp.data = info[3].Replace("\r", "").Replace("\n", "").Replace("\r\n", "");
                            tmp.computerName = info[2];
                            tmp.cardId = info[1];
                            
                            dataIDdictElements.Add(tmp);
                        }
                    }

                    // We remove first record that has card,data, computername that is the first line of the csv
                    dataIDdictElements.RemoveAll(x=>x.cardId=="card");

                    // We remove all the ocr scans as it has only the card id that might be wrongly places
                    dataIDdictElements.RemoveAll(x => x.computerName == "OMRON1");

                    // We also remove the PE events as they can also have only card id's
                    dataIDdictElements.RemoveAll(x => x.data == "PE event");
                    
                    createDictionary();
                    
                    foreach(dataIDdictElement e in dataIDdictElements)
                    {
                        cardIDSinTest.Add(e.cardId);
                    }
                    List<string> cardIDSinTest1=cardIDSinTest.ToList();
                    if (!OrderAsc.Checked)
                    {
                        CardIDsForTheTest.Clear();
                        foreach (string cardID in cardIDSinTest1)
                        {
                            CardIDsForTheTest.Text = CardIDsForTheTest.Text + cardID + "\n";
                        }
                    }
                    else
                    {
                        CardIDsForTheTest.Clear();
                        for (int i = cardIDSinTest1.Count - 1; i >= 0; i--)
                        {
                            {
                                CardIDsForTheTest.Text = CardIDsForTheTest.Text + cardIDSinTest1[i] + "\n";
                            }
                        }
                    }
                    CardIDsForTheTest.Text.Trim('\n');
                    Settings.Default.expected = file;
                    openFileDialog1.FileName = file;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        // Creates a dictionanry of card items <data:<cardId:number>>
        private void createDictionary()
        {
            foreach(dataIDdictElement d in dataIDdictElements)
            {
                if (data_ID_numDict.ContainsKey(d.data))
                {
                    if (data_ID_numDict[d.data].Contains(d.cardId))
                    {
                        continue;
                    }
                    else
                    {
                        data_ID_numDict[d.data].Add(d.cardId);
                    }
                }
                else
                {
                    List<string> temp = new List<string>
                    {
                        d.cardId
                    };
                    data_ID_numDict[d.data] = temp;
                }
            }
            
        }

        // Button when clicked changes the status of the records to 1 i.e., _status=1
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            string startID = (tbStartID.Text.ToString());
            string EndID = (tbEndID.Text.ToString());

            try
            {
                myConn2 = new SqlConnection(Settings.Default.connectionString);
                myConn2.Open();

                string mySQL = "update testdata set _status=1 where data_testname = '" + TestName + "' and id<"+startID+";" +
                    "update testdata set _status=1 where data_testname = '" + TestName + "' and id>"+ EndID + ";";
                SqlCommand myCMD = new SqlCommand(mySQL, myConn2);
                try
                {
                    int myReader = myCMD.ExecuteNonQuery();
                    MessageBox.Show(myReader.ToString() + " Records changed status to null");
                    btnRefresh.PerformClick();
                    
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    myCMD.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { myConn2.Close(); }
            Cursor.Current = Cursors.Default;


        }

        // Orders the cards in ascending or descending oreder when the checkbox is changed
        private void OrderAsc_CheckedChanged(object sender, EventArgs e)
        {
            List<string> cardIDSinTest1 = cardIDSinTest.ToList();
            if (!OrderAsc.Checked)
            {
                CardIDsForTheTest.Clear();
                foreach (string cardID in cardIDSinTest1)
                {
                    CardIDsForTheTest.Text = CardIDsForTheTest.Text + cardID + "\n";
                }
            }
            else
            {
                CardIDsForTheTest.Clear();
                for (int i = cardIDSinTest1.Count - 1; i >= 0; i--)
                {
                    {
                        CardIDsForTheTest.Text = CardIDsForTheTest.Text + cardIDSinTest1[i] + "\n";
                    }
                }

            }
            CardIDsForTheTest.Text.Trim('\n');
        }

        //to change the ID'S in the table before 
         private void btnChangeIDs_Click(object sender, EventArgs e)
        {
            DialogResult result =MessageBox.Show("Please clear all the null cards beore pressing this button. If cleared press yes","Check",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnPushUpdates.Visible= true;
                string lastID = "";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CardInfo c = new CardInfo();
                    c.ID = (string)row.Cells[0].Value;
                    c.Symbology = (string)row.Cells[1].Value;
                    c.data_scannername = (string)row.Cells[2].Value;
                    c.data_scannerdata = (string)row.Cells[3].Value;
                    c.data_computername = (string)row.Cells[5].Value;
                    cards.Add(c);
                    
                }
                cards.RemoveAt(cards.Count - 1);
                int PECount = 0;
                
                Dictionary<string, int> IDindex = new Dictionary<string, int>();
                int index = 0;
                foreach (CardInfo c in cards)
                {
                    IDindex[c.ID] = index;
                    index++;
                    lastID = c.ID;
                    if (c.data_scannerdata == "PE event") PECount++;

                    if (c.data_scannername == "delimiter" || PECount == 81)
                    {
                        if (PECount == 81)
                        {
                            PECount = 1;
                        }
                        else
                        {
                            PECount = 0;
                        }
                        StartAndEndID.Add(c.ID);
                    }
                }
                StartAndEndID.Add(lastID);

                List<string> cardsIntest ;
                cardsIntest = CardIDsForTheTest.Text.Split('\n').ToList();
                cardsIntest.Remove("\n");
                string card="";
                for (int i = 0; i < StartAndEndID.Count - 1; i = i + 2)
                {
                    //int start = Convert.ToInt32(StartAndEndID[i]);
                    //int end = Convert.ToInt32(StartAndEndID[i+2]);

                    card="";
                    for (int j = IDindex[StartAndEndID[i]];j< IDindex[StartAndEndID[i + 2]]; j++)
                    {
                        card = "";
                        if (data_ID_numDict.ContainsKey(cards[j].data_scannerdata))
                        {
                            int CardsCount = data_ID_numDict[cards[j].data_scannerdata].Count;
                            for(int k= 0;k< CardsCount;k++)
                            {
                                string key;
                                if (OrderAsc.Checked) key = data_ID_numDict[cards[j].data_scannerdata][CardsCount - k - 1];
                                else key = data_ID_numDict[cards[j].data_scannerdata][k];
                                if (cardsIntest.Contains(key))
                                {
                                    card = key;
                                    data_ID_numDict[cards[j].data_scannerdata].Remove(key);
                                    cardsIntest.Remove(key);
                                    if (data_ID_numDict[cards[j].data_scannerdata].Count == 0)
                                    {
                                        data_ID_numDict.Remove(cards[j].data_scannerdata);
                                        
                                    }
                                    break;
                                }
                            }
                        }
                        if (card != "") break;
                        
                    }

                    for (int j = IDindex[StartAndEndID[i]]; j < IDindex[StartAndEndID[i + 2]]; j++)
                    {
                        dataGridView1.Rows[j].Cells[4].Value = card;
                        StartAndEndID[i + 1] = card;
                    }


                }
                dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[4].Value = card;

            }
                
        }

        private void btnPushUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                myConn2 = new SqlConnection(Settings.Default.connectionString);
                myConn2.Open();
                for(int i = 0; i < StartAndEndID.Count - 1; i = i + 2)
                {
                    string start = StartAndEndID[i];
                    string card = StartAndEndID[i + 1];
                    string end = StartAndEndID[i + 2];
                    string mySQL = "update testdata set data_symbolset='"+card+"' " +
                        "where id>="+start+" and id<"+end+";" +
                        "update testdata set data_scannerdata='"+card+"' " +
                        "where id>="+start+" and id<"+end+ " and data_computername='OMRON1';";
                    SqlCommand myCMD = new SqlCommand(mySQL, myConn2);
                    try
                    {
                        int myReader = myCMD.ExecuteNonQuery();
                        //MessageBox.Show(myReader.ToString() + " Records changed status to null");
                        //btnRefresh.PerformClick();

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    finally
                    {
                        myCMD.Dispose();
                    }
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { myConn2.Close(); }
            Cursor.Current = Cursors.Default;
        }
    }
}
