using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exepciones;
using ClasesInstanciables;
using EntidadesAbstractas = ClasesAbstractas;
using Archivos;

namespace MiTestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidaExepcionAlumnoRepetido()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            //Act
            uni += a1;
            uni += a1;
            //Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidaExepcionDniInvalido()
        {
            //Arrange
            Profesor profersorPrueba = new Profesor(99, "Fede", "Davila", "A9999999", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
            //Act
            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ValidaExepcionArchivo()
        {
            //Arrange
            Texto archivoPrueba = new Texto();
            string datos;
            //Act
            archivoPrueba.Leer("CualquierArchivo", out datos);
            //Assert
        }
        [TestMethod]
        public void ValidaInstaciaColeccion()
        {
            //Arrange
            Profesor profersorPrueba = new Profesor(99, "Fede", "Davila", "13606674", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada jornadaPrueba = new Jornada(Universidad.EClases.Programacion, profersorPrueba);
            //Act

            //Assert
            Assert.IsNotNull(jornadaPrueba.Alumnos);
        }
    }
}
