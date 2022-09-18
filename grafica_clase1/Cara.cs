using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace grafica_clase1
{
    [DataContract]
    class Cara
    {
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private Vect3 color;
        [DataMember]
        private Dictionary<string, Vect3> vertices;
        public Cara()
        {
            vertices = new Dictionary<string, Vect3>();
        }

        public Cara(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
        }

        public Cara(Dictionary<string, Vect3> vertices, Vect3 centro, Vect3 color)
        {
            this.vertices = vertices;
            this.color = color;
            this.centro = centro;
        }

        public void addVertice(string key, Vect3 vertice)
        {
            this.vertices.Add(key, vertice);
        }

        public void addVertices(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
        }

        public void addColor(Vect3 color)
        {
            this.color = color;
        }

        public void addColor(Color color)
        {
            this.color = new Vect3(color.R, color.G, color.B);
        }

        public void setCentro(Vect3 centro)
        {
            this.centro = centro;
        }

        public void dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(this.color.X, this.color.Y, this.color.Z);
            foreach (var vector in vertices.Values)
            {
                GL.Vertex3(this.centro.X + vector.X, this.centro.Y + vector.Y, this.centro.Z + vector.Z);
            }
            GL.End();
        }


        public void rotar(float rotacion, float x, float y, float z)
        {
            GL.Translate(this.centro.X, this.centro.Y, this.centro.Z);
            GL.Rotate(rotacion, x, y, z);
            GL.Translate(-this.centro.X, -this.centro.Y, -this.centro.Z);
        }


    }
}
