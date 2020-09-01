using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; // Selenium을 위함

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; // Excel을 위함
using System.Threading;

namespace naverCrawling
{
    public partial class Form1 : Form
    {
        //protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;

        private string[] blog;
        private int blogcnt = 0;
        private string keyword = "";

        Excel.Application excelApp = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            try
            {
                // _driverService = ChromeDriverService.CreateDefaultService();
                //_driverService.HideCommandPromptWindow = true;
                //_options = new ChromeOptions();
                //_options.AddArgument("disable-gpu");

            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            keyword = "";
            keyword = textBox1.Text;
            if (String.IsNullOrEmpty(keyword)) {
                MessageBox.Show("유효한 값을 입력해주세요");
                return;
            }
            blog = new string[100];
            blogcnt = 0;


            _options = new ChromeOptions();
            _options.AddArgument("disable-gpu");
            _driver = new ChromeDriver(Application.StartupPath, _options);
            _driver.Navigate().GoToUrl("https://www.naver.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            DateTime startTime = System.DateTime.Now;

            var searchBox = _driver.FindElementByXPath("//*[@id='query']");
            searchBox.SendKeys(textBox1.Text);           

            var searchButton = _driver.FindElementByXPath("//*[@id='search_btn']");
            searchButton.Click();

            var plusButton = _driver.FindElementByXPath("//*[@id='_nx_lnb_more']/a/span");
            plusButton.Click();


            // 검색 후 블로그로 이동 
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var blogButton = _driver.FindElementByClassName("lnb3");
            blogButton.Click();
            //추출
            try
            {
                for (int j = 1; j <= 10; j++)
                {
                    
                    if (j != 1 && j < 7)
                    {
                        string pageXpath = "//*[@id='main_pack']/div[3]/a[" + j + "]";
                        var pageMoveButton = _driver.FindElementByXPath(pageXpath);
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
                        pageMoveButton.Click();
                    }
                    if (j > 6)
                    {
                        string pageXpath = "//*[@id='main_pack']/div[3]/a[" + 6 + "]";
                        var pageMoveButton = _driver.FindElementByXPath(pageXpath);
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
                        pageMoveButton.Click();
                    }

                    for (int i = 1; i <= 10; i++)
                    {
                        string xpath = "//*[@id='sp_blog_" + i + "']/dl/dt/a";
                        var moveButton = _driver.FindElementByXPath(xpath);
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
                        moveButton.Click();
                        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                        string[] info = (_driver.Url).Split('/');                      

                        blog[blogcnt] = info[info.Length - 2] + "@naver.com";                        
                        blogcnt++;
                        progressBar1.Value = blogcnt;
                        labelProgress.Text = blogcnt + "%";

                        progressBar1.Refresh();
                        labelProgress.Refresh();
                        Application.DoEvents(); //!

                        _driver.Close();
                        _driver.SwitchTo().Window(_driver.WindowHandles.First());
                    }
                }                
                blog = blog.Distinct().ToArray(); //중복제거

                //엑셀생성
                excelApp = new Excel.Application();
                wb = excelApp.Workbooks.Add();
                ws = wb.Worksheets.Item["Sheet1"];
                ws.Name = "result";
                for (int i = 1; i <= blog.Length; i++)
                {
                    ws.Cells[i, 1] = blog[i-1];
                }
                string savepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                wb.SaveAs(savepath + "\\" + textBox1.Text + System.DateTime.Now.ToString(" MM월dd일_mm")+ ".xlsx");

                //메모리 해제를 위한 처리
                wb.Close();
                excelApp.Quit();
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
                            
                DateTime endTime = System.DateTime.Now;
                TimeSpan runTime = endTime - startTime;

                int runMin = runTime.Minutes;
                int runSec = runTime.Seconds;

                _driver.Close();
                _driver.Dispose();
                this.BringToFront();
                MessageBox.Show("[" +textBox1.Text+endTime.ToString(" MM월dd일_mm") 
                    + ".xlsx] 저장완료\n소요시간 : "+runMin+"분"+runSec+"초");
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류명 :"+ex.Message);//검색어 오류,블로그 수 부족,엑셀 에러, 로딩속도
            }

            
            textBox1.Text = "";
            progressBar1.Value = 0;
            labelProgress.Text = "00%";
        }
        private void ReleaseExcelObject(object obj)
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
