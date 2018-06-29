using System;
using Tao.FreeGlut;
using OpenGL;
using System.Collections.Generic;
using System.IO;

namespace OpenGlScene
{
    public static class Data
    {
        public static int width = 1280, height = 720;
        public static string dir = Directory.GetCurrentDirectory();
        public static ShaderProgram program;
        public static List<SceneObject> objects = new List<SceneObject>();
        public static bool isTimeRotate = false;
        public static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        public static Texture curTexture;
        public static bool lighting = true;
        public static bool left, right, up, down = false;
        public static float xangle, yangle = 0;
        public static Vector3 lightDir = new Vector3(0.0f, 0.0f, 1.0f);
        public static Vector3 cameraPos = new Vector3(0.0f, 0.0f, 10.0f);
        public static Vector3 cameraFront = new Vector3(0.0f, 0.0f, -1.0f);
        public static Vector3 cameraUp = new Vector3(0.0f, 1.0f, 0.0f);
    }
}
