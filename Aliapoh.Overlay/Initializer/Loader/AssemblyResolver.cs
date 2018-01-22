using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Aliapoh.Overlay
{
    public class AssemblyResolver : IDisposable
    {
        public static readonly string parseString = @"(?<name>.+?), Version=(?<version>.+?), Culture=(?<culture>.+?), PublicKeyToken=(?<pubkey>.+)";
        public static readonly Regex assemblyNameParser = new Regex(parseString, RegexOptions.Compiled);
        public List<string> Directories { get; set; }

        public AssemblyResolver(IEnumerable<string> dirs)
        {
            Directories = new List<string>();
            if (dirs != null)
            {
                Directories.AddRange(dirs);
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        public AssemblyResolver() : this(null)
        {

        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            foreach (var dir in Directories)
            {
                var BinPath = "";
                var match = assemblyNameParser.Match(e.Name);
                if (match.Success)
                {
                    var BinFile = match.Groups["name"].Value + ".dll";
                    if (match.Groups["cluture"].Value == "neutral")
                    {
                        BinPath = Path.Combine(dir, BinFile);
                    }
                    else
                    {
                        BinPath = Path.Combine(dir, match.Groups["culture"].Value, BinFile);
                    }
                }
                else
                {
                    BinPath = Path.Combine(dir, e.Name + ".dll");
                }

                if (File.Exists(BinPath))
                {
                    var ASM = Assembly.LoadFile(BinPath);
                    OnAssemblyLoaded(ASM);
                    return ASM;
                }
            }
            return null;
        }

        private Assembly GetAssembly(string path)
        {
            try
            {
                var result = Assembly.LoadFrom(path);
                return result;
            }
            catch (Exception e)
            {
                OnExceptionOccured(e);
            }

            return null;
        }

        protected void OnExceptionOccured(Exception exception)
        {
            ExceptionOccured?.Invoke(this, new ExceptionOccuredEventArgs(exception));
        }

        protected void OnAssemblyLoaded(Assembly assembly)
        {
            AssemblyLoaded?.Invoke(this, new AssemblyLoadEventArgs(assembly));
        }

        public event EventHandler<ExceptionOccuredEventArgs> ExceptionOccured;
        public event EventHandler<AssemblyLoadEventArgs> AssemblyLoaded;

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }
    }
}
