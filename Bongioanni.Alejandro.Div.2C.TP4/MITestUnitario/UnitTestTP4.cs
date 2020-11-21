using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesExcepciones;
using ClasesVehiculos;

namespace MITestUnitario
{
    [TestClass]
    public class UnitTestTP4
    {
        [TestMethod]
        [ExpectedException(typeof(PatenteException))]
        public void VerificaPatenteErronea()
        {
            //Arrange
            Vehiculo automovil = new Automovil();
            //Act
            automovil.Patente = "&5665767-";
            //Assert
        }
        [TestMethod]

        public void VerificaInstanciaVehiculo()
        {
            //Arrange
            Vehiculo automovil = new Automovil("AD623QX",DateTime.Now);
            //Act
            //Assert
            Assert.IsNotNull(automovil);
        }
        [TestMethod]
        [ExpectedException(typeof(ImporteHoraException))]
        public void VerificaImporteNegativo()
        {
            //Arrange
            //Act
            Automovil.ValorHora = "-45";
            //Assert
        }
    }
}
