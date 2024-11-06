﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class WebForm1Test
{
    private WebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void InicioTest()
    {
        driver.Navigate().GoToUrl("http://localhost:57825/WebForm1.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("prueba1@ubu.es");
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("prueba1");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("prueba1");
        driver.FindElement(By.Id("btnAceptar")).Click();
        Assert.That(driver.FindElement(By.CssSelector("html")).Text, Is.EqualTo("Inicio de sesión\\\\n    Usuario  \\\\nContraseña\\\\n              Usuario y/o contraseña incorrecto.    \\\\n     "));
        driver.FindElement(By.CssSelector("tr:nth-child(3)")).Click();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("gdyagsfugasf");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("prueba1");
        driver.FindElement(By.Id("btnAceptar")).Click();
        Assert.That(driver.FindElement(By.CssSelector("html")).Text, Is.EqualTo("Inicio de sesión\\\\n    Usuario  \\\\nContraseña\\\\n              Usuario y/o contraseña incorrecto.    \\\\n     "));
        driver.FindElement(By.CssSelector("tr:nth-child(3)")).Click();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("prueba1@ubu.essdsd");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("dasfasasasas");
        driver.FindElement(By.Id("btnAceptar")).Click();
        Assert.That(driver.FindElement(By.CssSelector("html")).Text, Is.EqualTo("Inicio de sesión\\\\n    Usuario  \\\\nContraseña\\\\n              Usuario y/o contraseña incorrecto.    \\\\n     "));
        driver.FindElement(By.CssSelector("tr:nth-child(3)")).Click();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("prueba1@ubu.es");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("prueba1");
        driver.FindElement(By.Id("btnAceptar")).Click();
        Assert.That(driver.FindElement(By.CssSelector("html")).Text, Is.EqualTo("Inicio de sesión correcto"));
    }
}