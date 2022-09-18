using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace grafica_clase1
{
    [DataContract]
    class Figura
    {
        [DataMember]
        private string nombre;
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private float x;
        [DataMember]
        private float y;
        [DataMember]
        private float z;
        [DataMember]
        private Color4 color;
        [DataMember]
        private Dictionary<string, Cara> caras;
        [DataMember]
        public float rotacion;


        public Figura()
        {
            caras = new Dictionary<string, Cara>();
        }

        public Figura(Vect3 centro, float x, float y, float z, Color4 color)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Centro = centro;
            Caras = new Dictionary<string, Cara>();
            this.Nombre = "Figura";
        }

        public Figura(string nombre, Vect3 centro, Dictionary<string, Cara> caras)
        {
            this.Nombre = nombre;
            this.Centro = centro;
            this.Caras = caras;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
        internal Dictionary<string, Cara> Caras { get => caras; set => caras = value; }
        public Color4 Color { get => color; set => color = value; }
        internal Vect3 Centro { get => centro; set => centro = value; }
        public string Nombre { get => nombre; set => nombre = value; }



        public void dibujar()
        {
            foreach (var cara in this.Caras.Values)
            {
                GL.PushMatrix();

                rotar(rotacion, 0.0f, 1.0f, 0.0f);
                cara.dibujar();

                GL.PopMatrix();
            }
        }

        public void rotar(float rotacion, float x, float y, float z)
        {
            foreach (var cara in this.caras.Values)
            {
                cara.rotar(rotacion, x, y, z);
            }

        }

    }
}
