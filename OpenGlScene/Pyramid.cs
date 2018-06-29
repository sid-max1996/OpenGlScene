using System;
using OpenGL;

namespace OpenGlScene
{
    public class Pyramid : SceneObject
    {
        public Pyramid()
        {
            vertexes = new VBO<Vector3>(new Vector3[] {
                new Vector3(0, 1, 0), new Vector3(-1, -1, 1), new Vector3(1, -1, 1),        // front face
                new Vector3(0, 1, 0), new Vector3(1, -1, 1), new Vector3(1, -1, -1),        // right face
                new Vector3(0, 1, 0), new Vector3(1, -1, -1), new Vector3(-1, -1, -1),      // back face
                new Vector3(0, 1, 0), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1) });   // left face
            normals = new VBO<Vector3>(new Vector3[] {
                new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1),
                new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0),
                new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1),
                new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0) });
            colors = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1),
                new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 1, 0),
                new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1),
                new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 1, 0) });
            indexes = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, BufferTarget.ElementArrayBuffer);
        }

        public override void Draw()
        {
            Data.program["model_matrix"].SetValue(
                Matrix4.CreateRotationY(Data.yangle) * Matrix4.CreateRotationX(Data.xangle) *
                Matrix4.CreateTranslation(new Vector3(-2.0f, 0, 0)));
            Data.program["enable_texture"].SetValue(false);
            Gl.BindBufferToShaderAttribute(vertexes, Data.program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(colors, Data.program, "vertexColor");
            Gl.BindBufferToShaderAttribute(normals, Data.program, "vertexNormal");
            Gl.BindBuffer(indexes);

            Gl.DrawElements(BeginMode.Triangles, indexes.Count,
                DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

    }
}
