using System;
using Tao.FreeGlut;
using OpenGL;

namespace OpenGlScene
{
    public abstract class SceneObject
    {
        public VBO<Vector3> vertexes;
        public VBO<Vector3> normals;
        public VBO<Vector3> colors;
        public VBO<Vector2> texture;
        public VBO<int> indexes;

        public abstract void Draw();
    }
}
