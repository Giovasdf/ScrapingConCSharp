using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;

namespace ScrapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = GetDriver();
            GoToQuotes(driver);
            GetQuotes(driver);

            var miListaCitas = GetQuotes(driver);
            foreach (var cita in miListaCitas)
            {
                string Formato = $"Cita: {cita.cita} \n Autor:{cita._autor} \n";
                Console.WriteLine(Formato);
            }
        }
        public static IWebDriver GetDriver()
        {
            var user_agent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.50 Safari/537.36";
            ChromeOptions options = new ChromeOptions();
            //Descomenta ela siguiente linea para usar el mode headless de Chrome
            //options.AddArgument("--headless"); 
            options.AddArgument("--disable-gpu");
            options.AddArgument($"user_agent={user_agent}");
            options.AddArgument("--ignore-certificate-errors");
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            return driver;
        }

        public static void GoToQuotes(IWebDriver driver)
        {
            string url = "http://quotes.toscrape.com/";
            driver.Navigate().GoToUrl(url);
        }

        public static List<Cita> GetQuotes(IWebDriver driver)
        {
            Cita.citas = new List<Cita>();        

            var _quotes = driver.FindElements(By.ClassName("quote"));
            for (int i = 0; i < _quotes.Count; i++)
            {
                //Generamos un objeto nuevo para almacenar la informacion de la nueva cita.
                Cita cita = new Cita();
                var _authors = driver.FindElements(By.XPath($".//Div/span/small[contains(@class, 'author')]"));

                cita.cita = _quotes[i].Text;
                cita._autor = _authors[i].Text;


                Cita.citas.Add(cita);
            }

            return Cita.citas;
        }

    }
}
