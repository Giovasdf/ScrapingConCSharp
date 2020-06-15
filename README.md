# Como Hacer Scraping con .NetCore

_This is a project to be used as example, where Object Pooling pattern design is implemented_

_Este es un proyecto de introducción a Scraping con .NetCore_


### Pre-requisitos 📋

_Visual Sutdio con .NetCore_

_ChromeDriver_

_Selenium_

_Acceder correctamente a http://quotes.toscrape.com/_


## Preview 🛠️
_Previsualizacion del Proyecto Final_

_Obteniendo las citas y sus autores_


![](4.gif)

###  El metodo implementado 📋
_Program.cs_
```csharp
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
```




## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Da las gracias públicamente 🤓.

