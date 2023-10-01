using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_OpenTK.Figuras
{
    class Poligono
    {
        public Punto origen;
        public Punto cm;
        public Punto rotacionCm;
        public Punto rotacionP;
        public Punto rotacionO;
        public Dictionary<string, Punto> lista;
        public Color color;
        public PrimitiveType tipo;

        public Poligono()
        {
            this.lista = new Dictionary<string, Punto>();
            this.origen = new Punto();
            this.tipo = PrimitiveType.LineLoop;
            this.color = Color.Pink;
            this.cm = new Punto();
            this.rotacionCm = new Punto();
            this.rotacionP = new Punto();
            this.rotacionO = new Punto();
        }


        public Poligono(Punto origen, PrimitiveType tipo, Dictionary<string, Punto> puntos, Color c, Punto cm)
        {
            this.lista = puntos;
            this.origen = new Punto(origen);
            this.tipo = tipo;
            this.color = c;
            this.cm = new Punto(cm);
            this.rotacionCm = new Punto();
            this.rotacionP = new Punto();
            this.rotacionO = new Punto();
        }

        public Poligono(Poligono cara)
        {
            this.origen = new Punto(cara.origen);
            this.cm = new Punto(cara.cm);
            this.tipo = cara.tipo;
            this.color = cara.color;
            this.lista = new Dictionary<string, Punto>();
            this.rotacionCm = new Punto();
            this.rotacionP = new Punto();
            this.rotacionO = new Punto();
            foreach (var puntos in cara.lista)
                Adicionar(puntos.Key, new Punto(puntos.Value));
        }

        public void Adicionar(string name, Punto x)
        {
            if (lista.ContainsKey(name))
            {
                lista.Remove(name);
            }
            lista.Add(name, x);
        }

        public Punto Get(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }

        public void Dibujar()
        {
            GL.PushMatrix();
            this.AplicarTransformacion();
            GL.Begin(tipo); //tipo de figura
            GL.Color4(color); //color de la cara

            foreach (var vertice in lista.Values)
                GL.Vertex3((vertice.x), (vertice.y), (vertice.z));
            GL.End();
            GL.PopMatrix();
        }

        public void Rotar(float x, float y, float z)
        {
            rotacionCm.acumular(x, y, z);
        }


        public void Escalar(float x, float y, float z)
        {
            if (x <= 0) x = 1;
            if (y <= 0) y = 1;
            if (z <= 0) z = 1;
            this.cm.multiplicar(x, y, z);
            foreach (var vertice in lista.Values)
                vertice.multiplicar(x, y, z);
        }

        public void Trasladar(float x, float y, float z)
        {
            origen.acumular(x, y, z);
        }

        public void RotarP(float x, float y, float z)
        {
            rotacionP.acumular(x, y, z);
        }
        public void RotarO(float x, float y, float z)
        {
            rotacionO.acumular(x, y, z);
        }





        private void AplicarTransformacion()
        {
            this.rotar(new Punto(), rotacionO);
            this.rotar(origen, rotacionO);
            this.rotar(cm, rotacionCm);
            GL.Translate(-cm.x, -cm.y, -cm.z);
        }
        private void rotar(Punto ori, Punto rot)
        {
            GL.Translate(ori.x, ori.y, ori.z);
            GL.Rotate(rot.x, 1, 0, 0);
            GL.Rotate(rot.y, 0, 1, 0);
            GL.Rotate(rot.z, 0, 0, 1);
        }
    }
}
