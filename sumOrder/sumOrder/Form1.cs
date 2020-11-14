using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace sumOrder
{
    public partial class Form1 : Form
    {
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        Stack<string> filepaths;
        public Form1()
        {
            InitializeComponent();
        }
                      
        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < s.Length; i++)
            {
                listBox1.Items.Add(s[i]);                                
            }
        }
        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            using (openFileDialog1 = new OpenFileDialog())
            {

                openFileDialog1.Filter = "Excel File|*.xlsx|Excel File|*.xls";
                openFileDialog1.Title = "엑셀 파일 선택";
                openFileDialog1.Multiselect = true; // 파일 다중 선택
                                                    //dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepaths = new Stack<string>();
                    excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성                    

                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        filepaths.Push(openFileDialog1.FileNames[i]);
                        listBox1.Items.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileNames[i]));
                    }

                }
            }
        }
        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                listView1.Items.RemoveAt(listView1.FocusedItem.Index);
            else
                MessageBox.Show("선택된 항목이 없습니다.");
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBoxName.Text))
                if (!String.IsNullOrEmpty(comboBoxOption.Text))
                    if (!String.IsNullOrEmpty(textBoxPrice1.Text))
                        if (!String.IsNullOrEmpty(textBoxPrice2.Text))
                            {
                                ListViewItem items = new ListViewItem();
                                items.Text = comboBoxName.Text;
                                items.SubItems.Add(comboBoxOption.Text);
                                int price1;
                                int price2;
                                if (int.TryParse(textBoxPrice1.Text, out price1))
                                    if (int.TryParse(textBoxPrice2.Text, out price2))
                                    { 
                                            items.SubItems.Add(textBoxPrice1.Text);
                                            items.SubItems.Add(textBoxPrice2.Text);
                                            listView1.Items.Add(items);
                                            clearDetails();

                                            comboBoxName.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("판매단가에는 숫자만 입력할 수 있습니다.");
                                        textBoxPrice2.Text = "";
                                        textBoxPrice2.Focus();
                                    }
                                else
                                {
                                    MessageBox.Show("공급단가에는 숫자만 입력할 수 있습니다.");
                                    textBoxPrice1.Text = "";
                                    textBoxPrice1.Focus();
                                }
                            }
                        else
                            MessageBox.Show("판매단가 입력이 필요합니다.");
                    else
                        MessageBox.Show("공급단가 입력이 필요합니다.");
                else
                    MessageBox.Show("옵션 입력이 필요합니다");
            else
                MessageBox.Show("제품명 이름이 필요합니다");
        }

       
        private void SumFileBtn_Click(object sender, EventArgs e)
        {

            bool flag = false;

            string result = "";            
            int mPrice1sum = 0;
            int mPrice2sum = 0;
            try
            {
                foreach (string path in filepaths)
                {
                    excelApp = new Excel.Application();
                    workBook = excelApp.Workbooks.Open(path);
                    workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 첫번째 워크시트 가져오기
                    Excel.Range range = workSheet.UsedRange; // 가로,세로 값 가져오기

                    int price1sum = 0;
                    int price2sum = 0;

                    int row = range.Rows.Count;
                    int colunm = range.Columns.Count;

                    int r = 0;


                    if (flag)
                        r = 2;
                    else
                        r = 1;
                    for (; r <= row; r++) // 가져온 행 만큼 반복
                    {
                        if (!String.IsNullOrEmpty((range.Cells[r, 5] as Excel.Range).Value2)) // 구분인자로 전화번호 공백여부 사용
                        {
                            for (int c = 1; c <= colunm; c++) // 가져온 열 만큼 반복 
                            {
                                result += (range.Cells[r, c] as Excel.Range).Value2; // 셀 데이터 가져옴
                                result += "##"; // 셀 바꿈
                            }

                            if (!flag)
                            {
                                result += "공급 단가";
                                result += "##";
                                result += "판매 단가";
                                result += "##";
                            }
                            if (flag)
                            {
                                for (int i = 0; i < listView1.Items.Count; i++)
                                {
                                    ListViewItem item = listView1.Items[i];
                                    string product = (range.Cells[r, 1] as Excel.Range).Value2;
                                    if (item.Text == product)
                                    {
                                        string option = (range.Cells[r, 2] as Excel.Range).Value2;
                                        if (item.SubItems[1].Text == option)
                                        {
                                            double count = (range.Cells[r, 3] as Excel.Range).Value2; // int > 에러뜸
                                            int price1 = int.Parse(item.SubItems[2].Text);
                                            int price2 = int.Parse(item.SubItems[3].Text);

                                            result += (price1 * count);
                                            //result += "원##";
                                            result += "##";
                                            mPrice1sum += (price1 * Convert.ToInt32(count));
                                            price1sum += (price1 * Convert.ToInt32(count));

                                            result += (price2 * count);
                                            //result += "원##";
                                            result += "##";
                                            mPrice2sum += (price2 * Convert.ToInt32(count));
                                            price2sum += (price2 * Convert.ToInt32(count));
                                        }
                                    }
                                }
                            }
                            flag = true;
                            result += "!!"; //줄 바꿈
                        }
                    }
                    string names = Path.GetFileNameWithoutExtension(path);
                    string[] name = names.Split('_');

                    result += ("## ## ## ## ## ## ## ## ##"+name[1] +"##단가 :##");
                    result += price1sum.ToString() + "##" + price2sum.ToString() + "## !!";
                }
                
            }catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(workBook);
                excelApp.Quit();
                ReleaseExcelObject(excelApp);
            }
            try
            {                
                result += ("## ## ## ## ## ## ## ## ## ##단가 총액 :##");
                result += mPrice1sum.ToString() + "##" + mPrice2sum.ToString() + "## !!";

                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add();//엑셀 기본 생성
                workSheet = workBook.Worksheets.Add(); //기본 시트 후에 생성
                workSheet.Name = "result";

                string[] row = result.Split(new string[] { "!!" }, StringSplitOptions.None);
                for(int r=0; r<row.Length-1; r++)
                {
                    string[] colunm = row[r].Split(new string[] { "##" }, StringSplitOptions.None);
                    for(int c=0; c<colunm.Length-1; c++)
                    {
                        workSheet.Cells[r+1, c+1] = colunm[c];
                    }
                }
                
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                DirectoryInfo di = new DirectoryInfo(path + "\\발주서합산");
                if (di.Exists == false)
                    di.Create();
                path += "\\발주서합산\\" + System.DateTime.Now.ToString("MM월dd일_") + "발주서합산" + System.DateTime.Now.ToString("mmss") + ".xlsx";
                workBook.SaveAs(path);
                workBook.Close(true);
                MessageBox.Show("[ " + path + " ] \n파일 생성완료");

                clearDetails();
                listBox1.Items.Clear();
                listView1.Items.Clear();
                filepaths.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(workBook);
                excelApp.Quit();
                ReleaseExcelObject(excelApp);
            }
        }       

        public void clearDetails()
        {
            comboBoxName.Text = "";
            comboBoxOption.Text = "";
            textBoxPrice1.Text = "";
            textBoxPrice2.Text = "";
        }
        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }




    }
}
