using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace meshok_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWebDriver driver;
        private string href, tag, des, tourl;
        public List<lot> lots = new List<lot>();
        private string full;
        private bool triger = false;
        private IWebElement nameInput;
        public MainWindow()
        {
            InitializeComponent();
            //listBox1.Items.Add(lots[0].Text.ToString());

        }
        public class lot
        {
            public string Text { get; set; }
            public string GoURL { get; set; }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            IWebElement LogInput;
            IWebElement PasInput;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--user-data-dir=C:\\Users\\Admin\\AppData\\Local\\Google\\Chrome\\User Data\\Profile 1");
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1); //ожидание
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://meshok.net");
            /*
            LogInput = driver.FindElement(By.Name("LOGIN"));
            LogInput.SendKeys("Логин");
            PasInput = driver.FindElement(By.Name("password"));
            PasInput.SendKeys("Пароль" + OpenQA.Selenium.Keys.Enter);
            */
            listBox1.Items.Add("Вы вошли на сайт");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            driver.FindElement(By.Id("set")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cz2\"]/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"form2\"]/table[1]/tbody/tr[1]/th[6]/a")).Click(); ////*[@id="form2"]/a
            dann();
            //driver.FindElement(By.XPath("//*[@id=\"form2\"]/table[4]/tbody/tr/td[1]/span[2]/a")).Click();
            //dann();
            listBox1.Items.Add("Добавлено: " + lots.Count);
            dataGrid.ItemsSource = lots;
            for (int i = 0; i < lots.Count; i++)
            {
                driver.Navigate().GoToUrl(lots[i].GoURL);

                try
                {
                    des = driver.FindElement(By.XPath("//*[@id=\"desc\"]")).Text;
                }
                catch
                {
                    driver.Navigate().GoToUrl(lots[i].GoURL);
                    des = driver.FindElement(By.XPath("//*[@id=\"desc\"]")).Text;
                }
                //des = des.Substring(4);
                des = des.Substring(0, des.Length - 1445);// 1454 всего символов https:/ /text.ru/seo
                lots[i].Text = des;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (triger == true)
            {
                for (int i = 0; i < lots.Count; i++)
                {
                    driver.Navigate().GoToUrl(lots[i].GoURL);
                    //if (driver.FindElement(By.XPath("//*[@id=\"gInfo\"]/table/tbody/tr[2]/td[2]")).Text == "нет" && lots[i].Text.Length != 0)
                    //{
                    //if(driver.FindElement(By.XPath("//*[@id=\"gInfo\"]/table/tbody/tr[5]/td[1] ")).Text != "До конца торгов: ")
                    //{
                    tourl = new string(lots[i].GoURL.Where(x => char.IsDigit(x)).ToArray());
                    driver.Navigate().GoToUrl("https://meshok.net/post_a.php?edit_item=" + tourl);
                    nameInput = driver.FindElement(By.Name("name")); //наименование
                    nameInput.SendKeys(" " + lots[i].Text);
                    driver.FindElement(By.XPath("//*[@id=\"bbody\"]/form/table[2]/tbody/tr[16]/td/input[3]")).Click(); //фикс цена
                                                                                                                       //driver.FindElement(By.XPath("//*[@id=\"bbody\"]/form/table[2]/tbody/tr[19]/td/input[3]")).Click(); //аукцион
                    triger = false;
                    //}
                    Console.WriteLine("Осталось изменить: " + (lots.Count - i - 1));
                    //}
                }
            }

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string[] a = { "1003", "1005", "1010", "1020", "1021", "1025", "1026", "1027", "1029", "1030", "1045", "1047", "1048", "1051", "1059 ", "11/26", "1126" };
            for (int i = 0; i < lots.Count; i++)
            {
                for (int j = 0; j < lots[i].Text.Length; j++)
                {
                    if (lots[i].Text[j] == 'Д' || lots[i].Text[j] == 'д')
                    {
                        if (char.IsDigit(lots[i].Text[j + 1]) == true)
                        {
                            if (j != 0)
                            {
                                if (lots[i].Text[j - 1] == '/')
                                {
                                    break;
                                }
                            }
                            for (int p = j; p < lots[i].Text.Length; p++)
                            {
                                if (lots[i].Text[p] == ' ' || lots[i].Text[p] == '.' || lots[i].Text[p] == ',' || p == lots[i].Text.Length - 1)
                                {
                                    full += lots[i].Text[p];
                                    lots[i].Text = full;
                                    full = "";
                                    break;
                                }
                                else
                                {
                                    full += lots[i].Text[p];
                                }
                            }
                        }

                    }
                    if (j + 3 < lots[i].Text.Length) //проверка на договоры
                    {
                        foreach (string o in a)
                        {
                            try
                            {
                                if (lots[i].Text[j] == o[0] && lots[i].Text[j + 1] == o[1] && lots[i].Text[j + 2] == o[2] && lots[i].Text[j + 3] == o[3])
                                {
                                    if (j != 0)
                                    {
                                        if (lots[i].Text[j - 1] == 'U' || lots[i].Text[j - 1] == 'u')
                                        {
                                            full = "U";
                                        }
                                    }
                                    for (int p = j; p < lots[i].Text.Length; p++)
                                    {
                                        if (lots[i].Text[p] == ' ' || lots[i].Text[p] == '.' || lots[i].Text[p] == ',' || p == lots[i].Text.Length - 1)
                                        {
                                            full += lots[i].Text[p];
                                            lots[i].Text = full;
                                            full = "";
                                            break;
                                        }
                                        else
                                        {
                                            full += lots[i].Text[p];
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Возникло исключение!");
                            }
                        }
                    }
                }
            }
            triger = true;
        }

        public void dann()
        {
            IReadOnlyList<IWebElement> col = driver.FindElements(By.XPath(".//*[@id=\"form2\"]/table[2]/tbody/tr[1]/th"));
            IReadOnlyList<IWebElement> row = driver.FindElements(By.XPath(".//*[@id=\"form2\"]/table[2]/tbody/tr"));
            listBox1.Items.Add("Столбцов: " + col.Count);
            listBox1.Items.Add("Строк: " + row.Count);

            for (int i = 2; i < row.Count; i++)
            //for (int i = 2; i < 103; i++)
            {
                href = driver.FindElement(By.XPath("//*[@id=\"form2\"]/table[2]/tbody/tr[" + i + "]/td[3]/a")).GetAttribute("href");
                tag = driver.FindElement(By.XPath("//*[@id=\"form2\"]/table[2]/tbody/tr[" + i + "]/td[3]/a")).Text;
                if (tag.Contains("/") || tag.Contains("Д1") || tag.Contains("Д2") || tag.Contains("Д3") || tag.Contains("д1") || tag.Contains("д2") || tag.Contains("д3"))
                {
                    listBox1.Items.Add("Не добавлены: " + tag);
                }
                else
                {
                    lots.Add(new lot() { Text = "", GoURL = href });
                }
            }
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}
