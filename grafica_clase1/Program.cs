using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafica_clase1
{
    class Program
    {
        static void Main(string[] args)
        {
            guardarJsonCubo();
            guardarJsonPiramide();

            Ventana window = new Ventana(800, 600);
            window.Run();
        }

        public static void guardarJsonCubo()
        {
            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            Vect3 centro = new Vect3(-2.0, 0.0, 0.0);
            lista1.Add("v1", new Vect3(-1.0f, 1.0f, 1.0f));
            lista1.Add("v2", new Vect3(-1.0f, 1.0f, -1.0f));
            lista1.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            Cara face = new Cara(lista1, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("f1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista2.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista2.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista2.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista2, centro, new Vect3(1.0f, 0.0f, 1.0f));
            caras.Add("f2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista3.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            face = new Cara(lista3, centro, new Vect3(0.0f, 1.0f, 1.0f));
            caras.Add("f3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista4.Add("v3", new Vect3(-1.0f, 1.0f, -1.0f));
            lista4.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista4, centro, new Vect3(1.0f, 0.0f, 0.0f));
            caras.Add("f4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(1.0f, 1.0f, -1.0f));
            lista5.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(-1.0f, 1.0f, -1.0f));
            face = new Cara(lista5, centro, new Vect3(0.0f, 1.0f, 0.0f));
            caras.Add("f5", face);

            Dictionary<string, Vect3> lista6 = new Dictionary<string, Vect3>();
            lista6.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista6.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista6.Add("v3", new Vect3(-1.0f, -1.0f, 1.0f));
            lista6.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista6, centro, new Vect3(0.0f, 0.0f, 1.0f));
            caras.Add("f6", face);

            string nombre = "Cubo";
            Figura figura = new Figura(nombre, centro, caras);

            string nombreArchivo = "Cubo.json";

            string jsonString = JsonConvert.SerializeObject(figura, Formatting.Indented, 
                new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

            File.WriteAllText(nombreArchivo, jsonString);
            Console.WriteLine(File.ReadAllText(nombreArchivo));

        }

        public static void guardarJsonPiramide()
        {
            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            Vect3 centro = new Vect3(2.0, 0.0, 0.0);
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            lista1.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista1.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            Cara face = new Cara(lista1);
            face.addColor(Color.Green);
            face.setCentro(centro);
            faces.Add("f1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista2.Add("v2", new Vect3(-1.0f, -1.0f, 1.0f));
            lista2.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista2);
            face.addColor(Color.Yellow);
            face.setCentro(centro);
            faces.Add("f2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista3);
            face.addColor(Color.HotPink);
            face.setCentro(centro);
            faces.Add("f3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista4.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista4);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("f4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista5.Add("v2", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista5);
            face.addColor(Color.Gold);
            face.setCentro(centro);
            faces.Add("f5", face);

            string nombre = "Piramide";
            Figura obj = new Figura(nombre, centro, faces);

            string nombreArchivo = "Piramide.json";

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented,
                    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            File.WriteAllText(nombreArchivo, jsonString);
            Console.WriteLine(File.ReadAllText(nombreArchivo));


        }

    }
}
