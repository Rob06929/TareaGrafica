using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_OpenTK.Figuras
{
    class Objeto
    {
        public Dictionary<string, Partes> lista;

        public Objeto()
        {
            this.lista = new Dictionary<string, Partes>();
        }


        public Partes GetParte(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }


        public void SetParte(string name, Partes x)
        {
            if (lista.ContainsKey(name)) { lista.Remove(name); }
            lista.Add(name, x);
        }

        public void Dibujar()
        {
            //this.AplicarTransformacion();
            foreach (var parte in lista.Values)
                parte.Dibujar();
        }

        public void Rotar(float x, float y, float z)
        {
            foreach (var parte in lista.Values)
                parte.RotarO(x, y, z);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var parte in lista.Values)
                parte.Trasladar(x, y, z);
        }

        public void Escalar(float x, float y, float z)
        {
            foreach (var parte in lista.Values)
                parte.Escalar(x, y, z);
        }

    }
}
