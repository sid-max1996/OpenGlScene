using System;
using Tao.FreeGlut;
using OpenGL;

namespace OpenGlScene
{
    class Program
    {     
        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(Data.width, Data.height);
            Glut.glutCreateWindow("OpenGL Ind");

            Glut.glutIdleFunc(Functions.OnRenderFrame);
            Glut.glutDisplayFunc(Functions.OnDisplay);
            Glut.glutKeyboardFunc(Functions.OnKeyboardDown);
            Glut.glutKeyboardUpFunc(Functions.OnKeyboardUp);
            Glut.glutCloseFunc(Functions.OnClose);
            Glut.glutReshapeFunc(Functions.OnReshape);

            Gl.Enable(EnableCap.DepthTest);
            Gl.ClearColor(0, 0.6f, 0.56f, 1);

            Shader VertexShader = new Shader("\\shaders\\vertex_shader.txt");
            Shader FragmentShader = new Shader("\\shaders\\fragment_shader.txt");
            Data.program = new ShaderProgram(VertexShader.shaderCode, 
                FragmentShader.shaderCode);

            Data.program.Use();
          
            Data.program["projection_matrix"].SetValue(
                Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)Data.width / 
                Data.height, 0.1f, 1000f));
            Data.program["view_matrix"].SetValue(Matrix4.LookAt(Data.cameraPos,
                Data.cameraFront, Data.cameraUp));
            Data.program["light_direction"].SetValue(Data.lightDir);
            Data.program["enable_lighting"].SetValue(Data.lighting);

            Data.objects.Add(new Pyramid());
            Data.curTexture = new Texture(Data.dir+ "\\im\\crate.jpg");
            Data.objects.Add(new Cube(true));
            Data.objects.Add(new Plane(
                new Vector3(-2, 20, -40),
                new Vector3(100, 20, -10),
                new Vector3(100, -0.5f, -5),
                new Vector3(-2, -0.5f, -35),
                new Vector3(0.6f, 0.75f, 0.6f)
            ));

            Data.objects.Add(new Plane(
              new Vector3(-2, 20, -40),
              new Vector3(-100, 20, -10),
              new Vector3(-100, -0.5f, -5),
              new Vector3(-2, -0.5f, -35),
              new Vector3(0.2f, 0.2f, 0.64f)
          ));


            Data.objects.Add(new Plane(
              new Vector3(-200, -1.0f, 1000),
              new Vector3(-200, -1.0f, -1000),
              new Vector3(200, -1.0f, -1000),
              new Vector3(200, -1.0f, 1000),
              new Vector3(0.2f, 0.85f, 0.64f)
          ));

            if (Data.isTimeRotate)
                Data.watch = System.Diagnostics.Stopwatch.StartNew();
            Glut.glutMainLoop();
        }
    }
}
