using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGlScene
{
    public class Shader
    {
        public string shaderCode;

        public Shader(string filePath)
        {
            string dir = Directory.GetCurrentDirectory();
            string source = File.ReadAllText(dir+filePath);
            shaderCode = source;
        }
    }
}
