using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace VULauncher.Modules
{
    public class ProcessUtils
    {
        private Process p { get; set; }
        private ProcessStartInfo psi { get; set; }

        public Process Start(string workingDirectory, string command, params object[] args)
        {
            if (CreateProcessStartInfo(workingDirectory, command, args))
            {
                p = Process.Start(psi);
            }
            return p;
        }

        public void Kill()
        {
            if (IsAlive())
            {
                p.Kill();
            }
            p = null;
        }

        public void Exception()
        {
            if (IsAlive())
            {
                p.WaitForExit();
                if (p.ExitCode != 0)
                {
                    var except = new ProcessException(p.ExitCode, "ops", string.Format("Execution of {0} with arguments {1} failed with exit code {2}", psi.FileName, psi.Arguments, p.ExitCode));
                    p = null;
                    throw except;
                }
            }
            else
            {
                p = null;
            }
        }

        public bool CreateProcessStartInfo(string workingDirectory, string command, params object[] args)
        {
            psi = new ProcessStartInfo();
            var resolved = PathLookup(command, null);
            if (resolved == null) throw new FileNotFoundException("Cannot find application: " + command, command);
            if (resolved.EndsWith(".cmd", StringComparison.OrdinalIgnoreCase) || resolved.EndsWith(".bat", StringComparison.OrdinalIgnoreCase))
            {
                args = new[] { "/c", command }.Concat(args).ToArray();
                command = "cmd.exe";
            }

            psi.FileName = command;
            psi.WorkingDirectory = workingDirectory;
            psi.Arguments = GetArguments(args);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            return psi != null;
        }

        private static bool ContainsSpecialCharacters(string str)
        {
            return str.Any(y => !(char.IsLetterOrDigit(y) || y == '\\' || y == '|' || y == '/' || y == '.' || y == ':' || y == '-'));
        }

        public static string PathLookup(string file, string additionalSearchFolder)
        {
            if (file.Contains("/") || file.Contains("\\")) return file;
            if (file == "cmd.exe") return file;
            IEnumerable<string> paths = Environment.GetEnvironmentVariable("path").Split(';').Select(x => Environment.ExpandEnvironmentVariables(x)).ToList();
            if (additionalSearchFolder != null) paths = new[] { additionalSearchFolder }.Concat(paths);

            foreach (var p_ in paths)
            {
                var p = p_;
                if (!p.EndsWith("\\")) p += "\\";
                var pfile = p + file;
                if (File.Exists(pfile))
                {
                    var ext = Path.GetExtension(pfile).ToLower();
                    if (ext == ".exe" || ext == ".cmd" || ext == ".bat") return pfile;
                }
                if (File.Exists(pfile + ".exe")) return pfile + ".exe";
                if (File.Exists(pfile + ".cmd")) return pfile + ".cmd";
                if (File.Exists(pfile + ".bat")) return pfile + ".bat";

            }
            return null;
        }

        public static string GetArguments(params object[] arguments)
        {
            return string.Join(" ", arguments.Select(x =>
            {
                if (x is CommandLineNamedArgument) return x.ToString();
                if (x is RawCommandLineArgument) return x.ToString();
                var str = Convert.ToString(x, CultureInfo.InvariantCulture);
                if (ContainsSpecialCharacters(str) || string.IsNullOrEmpty(str)) return "\"" + str + "\"";
                return str;
            }).ToArray());
        }

        public static string GetCommandLine(string file, params object[] arguments)
        {
            return "\"" + file + "\" " + GetArguments(arguments);
        }

        public bool IsAlive()
        {
            return p != null && !p.HasExited;
        }

        public StreamReader ReadData()
        {
            var stderr = new StringWriter();

            p.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    stderr.Write(e.Data);
                    stderr.Write('\n');
                }
            };
            p.BeginErrorReadLine();

            var wrapped = new WrappedStreamReader(p.StandardOutput.BaseStream, stderr);
            return new StreamReader(wrapped, p.StandardOutput.CurrentEncoding, false);
        }

        public static CommandLineNamedArgument NamedArgument(string name, object value)
        {
            return new CommandLineNamedArgument(name, value);
        }

        public class RawCommandLineArgument
        {
            public string Value { get; private set; }
            public RawCommandLineArgument(string value)
            {
                this.Value = value;
            }

            public override string ToString()
            {
                return Value;
            }
        }

        public class CommandLineNamedArgument
        {

            public CommandLineNamedArgument(string name, object value)
            {
                this.Name = name;
                this.Value = value;
            }

            public string Name { get; private set; }
            public object Value { get; private set; }
            public override string ToString()
            {
                var v = Convert.ToString(Value, CultureInfo.InvariantCulture);
                return Name + (ContainsSpecialCharacters(v) ? "\"" + v + "\"" : v);
            }
        }

        private class WrappedStreamReader : Stream
        {
            private Stream baseStream;
            private StringWriter stderr;

            public WrappedStreamReader(Stream baseStream, StringWriter stderr)
            {
                this.baseStream = baseStream;
                this.stderr = stderr;
            }

            public override bool CanRead { get { return true; } }

            public override bool CanSeek { get { return false; } }

            public override bool CanWrite { get { return false; } }

            public override long Length { get { throw new NotSupportedException(); } }

            public override long Position { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

            public override void Flush()
            {
                throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                var k = baseStream.Read(buffer, offset, count);
                return k;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
        }
    }

    public class ProcessException : Exception
    {
        public int ExitCode { get; private set; }
        public string ErrorText { get; private set; }

        public ProcessException(int exitCode)
        {
            this.ExitCode = exitCode;
        }

        public ProcessException(int exitCode, string errorText, string message)
            : base(message)
        {
            this.ExitCode = exitCode;
            this.ErrorText = errorText;
        }
    }

}
