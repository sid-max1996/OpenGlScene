using System;
using Tao.FreeGlut;
using OpenGL;

namespace OpenGlScene
{
    public static class Functions
    {
        public static void OnClose()
        {
            foreach(var ob in Data.objects)
            {
                ob.vertexes.Dispose();
                ob.indexes.Dispose();
                if(ob.colors != null)
                    ob.colors.Dispose();
                if (ob.texture != null)
                    ob.texture.Dispose();
            }
            Data.program.DisposeChildren = true;
            Data.program.Dispose();
        }//OnClose end

        public static void OnDisplay()
        {

        }//OnDisplay end

        public static void OnRenderFrame()
        {
            Data.watch.Stop();
            float deltaTime = (float)Data.watch.ElapsedTicks /
                System.Diagnostics.Stopwatch.Frequency;
            Data.watch.Restart();
            if (Data.isTimeRotate)
            {
                Data.xangle += deltaTime / 2;
                Data.yangle += deltaTime;
            }

            if (Data.right) Data.yangle += deltaTime;
            if (Data.left) Data.yangle -= deltaTime;
            if (Data.up) Data.xangle -= deltaTime;
            if (Data.down) Data.xangle += deltaTime;

            Gl.Viewport(0, 0, Data.width, Data.height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.UseProgram(Data.program);

            //Vector3 cameraLook = Data.cameraPos + Data.cameraFront;
            Data.program["view_matrix"].SetValue(Matrix4.LookAt(Data.cameraPos,
                Data.cameraFront, Data.cameraUp));
            Data.program["light_direction"].SetValue(Data.lightDir);
            Data.program["enable_lighting"].SetValue(Data.lighting);
            foreach (var ob in Data.objects)
                ob.Draw();
   
            Glut.glutSwapBuffers();
        }//OnRenderFrame end

        public static void OnReshape(int width, int height)
        {
            Data.width = width;
            Data.height = height;

            Data.program.Use();
            Data.program["projection_matrix"].SetValue(
                Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
        }//OnReshape end

        public static void OnKeyboardDown(byte key, int x, int y)
        {
            if (key == 'w') Data.up = true;
            else if (key == 's') Data.down = true;
            else if (key == 'd') Data.right = true;
            else if (key == 'a') Data.left = true;
            else if (key == '-') Data.cameraPos.z += 0.1f;
            else if (key == '+' || key == '=') Data.cameraPos.z -= 0.1f;
            else if (key == '4') Data.cameraPos.x -= 0.1f;
            else if (key == '6') Data.cameraPos.x += 0.1f;
            else if (key == '7') Data.lightDir.x += 0.5f;
            else if (key == '8') Data.lightDir.y += 0.5f;
            else if (key == '9') Data.lightDir.z -= 0.5f;
            else if (key == '1') Data.lightDir.x -= 0.5f;
            else if (key == '2') Data.lightDir.y -= 0.5f;
            else if (key == '3') Data.lightDir.z -= 0.5f;
            else if (key == 27) Glut.glutLeaveMainLoop();
        }

        public static void OnKeyboardUp(byte key, int x, int y)
        {
            if (key == 'w') Data.up = false;
            else if (key == 's') Data.down = false;
            else if (key == 'd') Data.right = false;
            else if (key == 'a') Data.left = false;
            else if (key == ' ') Data.isTimeRotate = !Data.isTimeRotate;
            else if (key == 'l') Data.lighting = !Data.lighting;
        }


    }
}
