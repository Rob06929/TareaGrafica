using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Proyecto_OpenTK.Figuras
{
    class Cuarto
    {
        private double angle, rx, ry, rz;
        private double x, y, z, anchoX, altoY, largoZ;
        Color pintura;
        public Cuarto(Color color, double x = -14, double y = -4, double z = 10, double ancho = 1.0, double alto = 1.0, double largo = 1.0)
        {
            this.x = x; this.y = y; this.z = z;
            this.anchoX = ancho; this.altoY = alto; this.largoZ = largo;
            angle = 0; rx = 0; ry = 0; rz = 0;
            pintura = color;
        }

        public void Dibujar()
        {
            Color color = pintura;
            GL.PushMatrix();
                GL.Scale(this.anchoX, this.altoY, this.largoZ);//Variar Escala
                GL.Translate(this.x, this.y, this.z);          //Variar Posicion
                GL.Rotate(angle, rx, ry, rz);                  //Variar Rotacion
                Espaldar(Color.Brown);

                Repisa(Color.White);
                Ruedas(Color.DarkBlue);
                Chasis(Color.Black);
                Luz(Color.Black);

            GL.PopMatrix();

        }

        private void Chasis(Color color)
        {
            GL.PushMatrix();
            GL.Scale(2, 1, 1.4);
            GL.Translate(0.8, 13,3);
            Cubo3D(Color.DarkGray);
            GL.PopMatrix();

            GL.PushMatrix();//Tabla base
            GL.Scale(1, 0.5, 1);
            GL.Translate(1.5, 29, 4.2);
            Cubo3D(Color.White);
            GL.PopMatrix();
        }

        private void Luz(Color color)
        {
            GL.PushMatrix();
            GL.Scale(0.1, 0.4, 0.4);
            GL.Translate(-4, 32, 9);
            Cubo3D(Color.Yellow);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Scale(0.1,0.4,0.4);
            GL.Translate(-4, 32,12);
            Cubo3D(Color.Yellow);
            GL.PopMatrix();
        }
        private void Repisa(Color color)
        {
            GL.PushMatrix();
            GL.Scale(15, 0.5 , 5);
            GL.Translate(0, 20, 1);

            Cubo3D(color);
            GL.PopMatrix();
        }

        private void Ruedas(Color color)
        {
            GL.PushMatrix();
            GL.Scale(0.8, 1, 0.2);
            GL.Translate(0.5, 12, 27);
            Cubo3D(color);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Scale(0.8, 1, 0.2);
            GL.Translate(0.5, 12, 14);
            Cubo3D(color);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Scale(0.8, 1, 0.2);
            GL.Translate(3.5, 12, 27);
            Cubo3D(color);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Scale(0.8, 1, 0.2);
            GL.Translate(3.5, 12, 14);
            Cubo3D(color);
            GL.PopMatrix();

        }

        private void Espaldar(Color color)
        {

            GL.PushMatrix();// Espaldar
                GL.Scale(15, 15, 0.5);
                GL.Translate(0, 0,0);
                Cubo3D(color);
            GL.PopMatrix();
        }

        public void Rotar(double angulo, double x, double y, double z)
        {
            angle = angulo; rx = x; ry = y; rz = z;
        }
        public void Escalar(double ancho, double alto, double largo)
        {
            this.anchoX = ancho; this.altoY = alto; this.largoZ = largo;
        }
        public void Trasladar(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        private void Cubo3D(Color color)
        {
            GL.Begin(PrimitiveType.Quads);
            //Tomando referencia los numeros de un Dado, tomo los sgtes lados:
            GL.Color3(color);
            //Lado #1(Frente)
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-1.0, -1.0, 1.0);
            GL.Vertex3(1.0, -1.0f, 1.0);
            GL.Vertex3(1.0, 1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, 1.0);

            //Lado #2 (Izquierda)
            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(-1.0, -1.0, -1.0);
            GL.Vertex3(-1.0, -1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, -1.0);

            //Lado #3 (Inferior)
            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            //Lado #4 (Superior)
            GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            //Lado #5 (Derecha)
            GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            //Lado #6 (Atras)
            GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.End();
        }
    }
}
  