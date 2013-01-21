using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebConfigTransformRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Wrong number of arguments");
                Console.WriteLine("WebConfigTransformer ConfigFilename TransformFilename ResultFilename");
                Environment.Exit(1);
            }
            if (!System.IO.File.Exists(args[0]) || !System.IO.File.Exists(args[1]))
            {
                Console.WriteLine("The config or transform file do not exist!");
                Environment.Exit(2);
            }
            using (var doc = new Microsoft.Web.XmlTransform.XmlTransformableDocument())
                {
                    doc.Load(args[0]);
                    using (var tranform = new Microsoft.Web.XmlTransform.XmlTransformation(args[1]))
                    {
                        if (tranform.Apply(doc))
                        {
                            doc.Save(args[2]);
                        }
                        else
                        {
                            Console.WriteLine("Could not apply transform");
                            Environment.Exit(3);
                        }
                    }
                }
            }
        
    }
}
