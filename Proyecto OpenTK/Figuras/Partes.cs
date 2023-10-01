using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_OpenTK.Figuras
{
    class Partes
    {
        public Punto origen;
        public float ancho;
        public float alto;
        public float profundidad;
        public Dictionary<string, Poligono> lista;

        public Partes()
        {
            this.lista = new Dictionary<string, Poligono>();
            this.origen = new Punto();
            this.ancho = this.alto = this.profundidad = 0;
        }

        public Partes(Punto origen, float ancho, float alto, float profundidad, Dictionary<string, Poligono> poligonos)
        {
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.lista = poligonos;
            foreach (var poligono in lista.Values)
            {
                poligono.origen.x = this.origen.x;
                poligono.origen.y = this.origen.y;
                poligono.origen.z = this.origen.x;
            }

        }
        public Partes(Partes partes)
        {
            this.origen = new Punto(partes.origen);
            this.ancho = partes.ancho;
            this.alto = partes.alto;
            this.profundidad = partes.profundidad;
            this.lista = new Dictionary<string, Poligono>();
            foreach (var poligono in partes.lista)
                this.setPoligono(poligono.Key, new Poligono(poligono.Value));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void setPoligono(string name, Poligono x)
        {
            if (lista.ContainsKey(name))
            {
                lista.Remove(name);
            }
            lista.Add(name, x);
        }

        public void SetOrigen(float x, float y, float z)
        {
            foreach (var caras in lista.Values)
            {
                caras.origen.x = x;
                caras.origen.y = y;
                caras.origen.z = z;
            }
        }
        public Poligono GetPoligono(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }

        public void Dibujar()
        {
            foreach (var caras in lista.Values)
                caras.Dibujar();
        }


        public void Rotar(float x, float y, float z)
        {
            foreach (var caras in lista.Values)
                caras.RotarP(x, y, z);
        }

        public void Escalar(float x, float y, float z)
        {
            foreach (var caras in lista.Values)
                caras.Escalar(x, y, z);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var caras in lista.Values)
                caras.Trasladar(x, y, z);
        }

        public void RotarO(float x, float y, float z)
        {
            foreach (var caras in lista.Values)
                caras.RotarO(x, y, z);
        }
    }
}
