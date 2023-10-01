using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;
using Proyecto_OpenTK.Figuras;
using Proyecto_OpenTK.Utilidades;

namespace Proyecto_OpenTK
{
    class Game : GameWindow
    {

        public static Objeto objeto;
        public static Objeto objeto2;
        public static Objeto objeto3;


        public Game(int width, int height)
             : base(width, height)
        {
            Location = new System.Drawing.Point(900, 100);
        }

        protected override void OnLoad(EventArgs e)
        {
            float[] luz_posicion = { 0, 100, 80 };
            float[] luz_ambiente = { 0.9f, 0.5f, 0.2f };
            GL.Light(LightName.Light0, LightParameter.Position, luz_posicion);
            GL.Light(LightName.Light0, LightParameter.Ambient, luz_ambiente);


            GL.ClearColor(Color4.Yellow);
            //------------------------------
            objeto = new Objeto();
            objeto2 = new Objeto();
            objeto3 = new Objeto();


            //Partes a = GetBaseCasa();
            Partes b = GetPlano();
            Partes c = GetCarroInferior();
            Partes d = GetCarroSuperior();
            Partes z = GetRueda();
            Partes f = GetRueda();
            Partes g = GetRueda();
            Partes h = GetRueda();




            objeto.SetParte("estante", b);

            objeto.GetParte("estante").SetOrigen(0, 0, 0);
            objeto.Escalar(1.0f, 1.0f, 1.0f);
            objeto.Rotar(5, -5, 0);


            objeto2.SetParte("carroInferior", c);
            objeto2.SetParte("carroSuperior", d);
            objeto2.GetParte("carroInferior").SetOrigen(-30, -1f, 0);
            objeto2.GetParte("carroInferior").Escalar(0.2f, 0.15f, 0.3f);
            objeto2.GetParte("carroSuperior").SetOrigen(-30, 1.5f, 0);
            objeto2.GetParte("carroSuperior").Escalar(0.1f, 0.1f, 0.15f);

            objeto2.SetParte("rueda1", z);
            objeto2.SetParte("rueda2", f);
            objeto2.SetParte("rueda3", g);
            objeto2.SetParte("rueda4", h);

            objeto2.GetParte("rueda1").SetOrigen(-32, -2.5f, 3);
            objeto2.GetParte("rueda2").SetOrigen(-28, -2.5f, 3);
            objeto2.GetParte("rueda3").SetOrigen(-32, -2.5f, -3);
            objeto2.GetParte("rueda4").SetOrigen(-28, -2.5f, -3);

            objeto2.GetParte("rueda1").Escalar(0.02f, 0.05f, 0.05f);
            objeto2.GetParte("rueda2").Escalar(0.02f, 0.05f, 0.05f);
            objeto2.GetParte("rueda3").Escalar(0.02f, 0.05f, 0.05f);
            objeto2.GetParte("rueda4").Escalar(0.02f, 0.05f, 0.05f);
            objeto2.Trasladar(25, 18,0);
            objeto2.Rotar(5, -5, 0);
            objeto2.Escalar(1f, 1f, 1f);


            base.OnLoad(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            this.capturarTeclado();
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);


            GL.Enable(EnableCap.Light0);

            GL.LoadIdentity();
            //-----------------------

            objeto.Dibujar();

            objeto2.Dibujar();

            GL.Normal3(5.0, 0.0, 0.0);

            //-----------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        public void capturarTeclado()
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Q))
            {
                objeto.Rotar(0.8f, 0, 0);
                objeto2.Rotar(0.8f, 0, 0);

            }
            if (input.IsKeyDown(Key.W))
            {
                objeto.Rotar(-0.8f, 0.0f, 0);
                objeto2.Rotar(-0.8f, 0.0f, 0);


            }
            if (input.IsKeyDown(Key.E))
            {
                objeto.Rotar(0, 0, 0.8f);
                objeto2.Rotar(0, 0, 0.8f);


            }
            if (input.IsKeyDown(Key.A))
            {
                objeto.Trasladar(-1f, 0, 0);
                objeto2.Trasladar(-1f, 0, 0);

            }
            if (input.IsKeyDown(Key.S))
            {
                objeto.Trasladar(1f, 0, 0);
                objeto2.Trasladar(1f, 0, 0);

            }
            if (input.IsKeyDown(Key.D))
            {
                objeto.Trasladar(0, 1.0f, 0);
                objeto2.Trasladar(0, 1.0f, 0);

            }
            if (input.IsKeyDown(Key.F))
            {
                objeto.Trasladar(0, -1.0f, 0);
                objeto2.Trasladar(0, -1.0f, 0);

            }
            if (input.IsKeyDown(Key.G))
            {
                objeto.Trasladar(0, 0, 1.0f);
                objeto2.Trasladar(0, 0, 1.0f);

            }
            if (input.IsKeyDown(Key.H))
            {
                objeto.Trasladar(0, 0, -1.0f);
                objeto2.Trasladar(0, 0, -1.0f);
            }

            if (input.IsKeyDown(Key.Z))
            {
                objeto.Escalar(0.9f, 0, 0);
                objeto2.Escalar(0.9f, 0, 0);
            }
            if (input.IsKeyDown(Key.X))
            {
                objeto.Escalar(1.1f, 0, 0);
                objeto2.Escalar(1.1f, 0, 0);
            }
            if (input.IsKeyDown(Key.C))
            {
                objeto.Escalar(0, 0.9f, 0);
                objeto2.Escalar(0, 0.9f, 0);
            }
            if (input.IsKeyDown(Key.V))
            {
                objeto.Escalar(0, 1.1f, 0);
                objeto2.Escalar(0, 1.1f, 0);
            }
            if (input.IsKeyDown(Key.B))
            {
                objeto.Escalar(0, 0, 0.9f);
                objeto2.Escalar(0, 0, 0.9f);

            }
            if (input.IsKeyDown(Key.N))
            {
                objeto.Escalar(0, 0, 1.1f);
                objeto2.Escalar(0, 0, 1.1f);
            }

        }

        protected override void OnResize(EventArgs e)
        {
            float d = 40;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }

        private void Iluminar()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);

            float[] luz_posicion = { 20, 20, 80 };
            float[] luz_ambiente = { 0.5f, 0.0f, 0.0f };
            GL.Light(LightName.Light0, LightParameter.Position, luz_posicion);
            GL.Light(LightName.Light0, LightParameter.Ambient, luz_ambiente);
            
            GL.Enable(EnableCap.Light0);

        }

        public Partes GetPlano() //todos el mismo origen
        {
            Dictionary<string, Poligono> caras = new Dictionary<string, Poligono>
                         {
                            //atras
                            {
                                "cara1",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -30.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 30.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 30.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -30.0f, -10.0f) }
                                    },
                                    Color.Orange,
                                    new Punto(0, 0, -10.0f)
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10.0f, 15f, -10.0f) },
                                        { "2", new Punto(-10.0f, 15f, 0.0f) },
                                        { "3", new Punto(10.0f, 15f, 0.0f) },
                                        { "4", new Punto(10.0f, 15f, -10.0f) }
                                    },
                                    Color.DarkSlateGray,
                                    new Punto(0, -10.0f, 0)
                                )
                            },

                         };
            return new Partes(new Punto(0, 0, 0), 5, 5, 5, caras);
        }


        public Partes GetCarroInferior() //todos el mismo origen
        {
            Dictionary<string, Poligono> poligonos = new Dictionary<string, Poligono>
                         {
                            //atras
                            {
                                "cara1",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.White,
                                    new Punto(0, 0, -10.0f)
                                )
                            },
                            //izquierda
                            {
                                "cara2",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(-10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.White,
                                    new Punto(-10.0f, 0, 0)
                                )
                            },
                            //derecha
                            {
                                "cara3",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.White,
                                    new Punto(10.0f, 0, 0)
                                )
                            },
                            //superior
                            {
                                "cara4",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, 10.0f, 10.0f) }
                                    },
                                    Color.White,
                                    new Punto(0, 10.0f, 0)
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "2", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "3", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.DarkBlue,
                                    new Punto(0, -10.0f, 0)
                                )
                            },
                           // frente
                            {
                                "cara6",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.White,
                                    new Punto(0, 0, 10)
                                )
                            },

                         };

            return new Partes(new Punto(0, 0, 0), 2, 2, 2, poligonos);
        }


        public Partes GetCarroSuperior() //todos el mismo origen
        {
            Dictionary<string, Poligono> poligonos = new Dictionary<string, Poligono>
                         {
                            //atras
                            {
                                "cara1",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(0, 0, -10.0f)
                                )
                            },
                            //izquierda
                            {
                                "cara2",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(-10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(-10.0f, 0, 0)
                                )
                            },
                            //derecha
                            {
                                "cara3",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(10.0f, 0, 0)
                                )
                            },
                            //superior
                            {
                                "cara4",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, 10.0f, 10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(0, 10.0f, 0)
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "2", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "3", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(0, -10.0f, 0)
                                )
                            },
                           // frente
                            {
                                "cara6",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.Blue,
                                    new Punto(0, 0, 10)
                                )
                            },

                         };

            return new Partes(new Punto(0, 0, 0), 2, 2, 2, poligonos);
        }


        public Partes GetRueda() //todos el mismo origen
        {
            Dictionary<string, Poligono> poligonos = new Dictionary<string, Poligono>
                         {

                            
                            //atras
                            {
                                "cara1",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.BlanchedAlmond,
                                    new Punto(0, 0, -10.0f)
                                )
                            },
                            //izquierda
                            {
                                "cara2",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(-10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.Black,
                                    new Punto(-10.0f, 0, 0)
                                )
                            },
                            //derecha
                            {
                                "cara3",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.Black,
                                    new Punto(10.0f, 0, 0)
                                )
                            },
                            //superior
                            {
                                "cara4",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, -10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, -10.0f) },
                                        { "punto4", new Punto(10.0f, 10.0f, 10.0f) }
                                    },
                                    Color.BlanchedAlmond,
                                    new Punto(0, 10.0f, 0)
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10.0f, -10.0f, -10.0f) },
                                        { "2", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "3", new Punto(10.0f, -10.0f, 10.0f) },
                                        { "4", new Punto(10.0f, -10.0f, -10.0f) }
                                    },
                                    Color.BlanchedAlmond,
                                    new Punto(0, -10.0f, 0)
                                )
                            },
                           // frente
                            {
                                "cara6",
                                new Poligono(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Polygon,
                                    new Dictionary<string, Punto>
                                    {
                                        { "punto1", new Punto(-10.0f, -10.0f, 10.0f) },
                                        { "punto2", new Punto(-10.0f, 10.0f, 10.0f) },
                                        { "punto3", new Punto(10.0f, 10.0f, 10.0f) },
                                        { "punto4", new Punto(10.0f, -10.0f, 10.0f) }
                                    },
                                    Color.BlanchedAlmond,
                                    new Punto(0, 0, 10)
                                )
                            },

                         };

            return new Partes(new Punto(0, 0, 0), 2, 2, 2, poligonos);
        }
    }
}
