using System;
using System.Collections.Generic;
using OpenGL;

namespace OpenGlScene
{
    public class Plane:SceneObject
    {
        public Plane(Vector3 first, Vector3 second, Vector3 third, 
            Vector3 fourth, Vector3 color)
        {
            vertexes = new VBO<Vector3>(new Vector3[] {
                first, second, third, fourth
            });
            normals = new VBO<Vector3>(new Vector3[] {
                new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1) });
            colors = new VBO<Vector3>(new Vector3[] {
                color, color, color, color
            });
            indexes = indexes = new VBO<int>(new int[] { 0, 1, 2, 3},
                BufferTarget.ElementArrayBuffer
            );
        }

        public override void Draw()
        {
            Data.program["model_matrix"].SetValue(
                Matrix4.CreateTranslation(new Vector3(1.5f, 0, 0)));
            Data.program["enable_texture"].SetValue(false);
            Gl.BindBufferToShaderAttribute(vertexes, Data.program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(colors, Data.program, "vertexColor");
            Gl.BindBuffer(indexes);

            Gl.DrawElements(BeginMode.Quads, indexes.Count,
                DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
        
    }
}
