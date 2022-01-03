using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace VULauncher.Util
{
    public class ProcessUtils // TODO Hacky class i wonder who did this :')
    {
        private Process Process { get; set; }
        private ProcessStartInfo ProcessStartInfo { get; set; }

        public Process Start(string workingDirectory, string command, string[] args)
        {
            if (CreateProcessStartInfo(workingDirectory, command, args))
            {
                Process = Process.Start(ProcessStartInfo);
            }

            return Process;
        }

        public void Kill()
        {
            if (IsAlive())
            {
                Process.Kill();
            }

            Process = null;
        }

        public void Exception()
        {
            if (IsAlive())
            {
                Process.WaitForExit();

                if (Process.ExitCode != 0)
                {
                    var except = new ProcessException(Process.ExitCode, "ops", string.Format("Execution of {0} with arguments {1} failed with exit code {2}", ProcessStartInfo.FileName, ProcessStartInfo.Arguments, Process.ExitCode));
                    Process = null;
                    throw except;
                }
            }
            else
            {
                Process = null;
            }
        }

        public bool CreateProcessStartInfo(string workingDirectory, string command, string[] args)
        {
            ProcessStartInfo = new ProcessStartInfo();

            var resolved = PathLookup(command, null);

            if (resolved == null) 
                throw new FileNotFoundException("Cannot find application: " + command, command);

            if (resolved.EndsWith(".cmd", StringComparison.OrdinalIgnoreCase) || resolved.EndsWith(".bat", StringComparison.OrdinalIgnoreCase))
            {
                args = new[] { "/c", command }.Concat(args).ToArray();
                command = "cmd.exe";
            }

            ProcessStartInfo.FileName = command;
            ProcessStartInfo.WorkingDirectory = workingDirectory;
            ProcessStartInfo.Arguments = string.Join(" ", args.Select(a => a));
            ProcessStartInfo.UseShellExecute = false;
            ProcessStartInfo.CreateNoWindow = true;
            ProcessStartInfo.RedirectStandardError = true;
            ProcessStartInfo.RedirectStandardOutput = true;

            return ProcessStartInfo != null;
        }

        private static bool ContainsSpecialCharacters(string str)
        {
            return str.Any(y => !(char.IsLetterOrDigit(y) || y == '\\' || y == '|' || y == '/' || y == '.' || y == ':' || y == '-'));
        }

        public static string PathLookup(string file, string additionalSearchFolder) // TODO: wth is this ugly mess
        {
            if (file.Contains("/") || file.Contains("\\")) 
                return file;

            if (file == "cmd.exe") 
                return file;

            IEnumerable<string> paths = Environment.GetEnvironmentVariable("path")?.Split(';').Select(Environment.ExpandEnvironmentVariables).ToList();

            if (additionalSearchFolder != null) 
                paths = new[] { additionalSearchFolder }.Concat(paths);

            foreach (var ps in paths)
            {
                var path = ps;

                if (!path.EndsWith("\\")) 
                    path += "\\";

                var filePath = path + file;

                if (File.Exists(filePath))
                {
                    var ext = Path.GetExtension(filePath).ToLower();

                    if (ext == ".exe" || ext == ".cmd" || ext == ".bat") 
                        return filePath;
                }

                if (File.Exists(filePath + ".exe")) 
                    return filePath + ".exe";

                if (File.Exists(filePath + ".cmd")) 
                    return filePath + ".cmd";

                if (File.Exists(filePath + ".bat")) 
                    return filePath + ".bat";

            }

            return null;
        }

        public bool IsAlive()
        {
            return Process != null && !Process.HasExited;
        }

        public StreamReader ReadData()
        {
            var stderr = new StringWriter();

            Process.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    stderr.Write(e.Data);
                    stderr.Write('\n');
                }
            };

            Process.BeginErrorReadLine();

            var wrapped = new WrappedStreamReader(Process.StandardOutput.BaseStream, stderr);
            return new StreamReader(wrapped, Process.StandardOutput.CurrentEncoding, false);
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

            public override bool CanRead => true;

            public override bool CanSeek => false;

            public override bool CanWrite => false;

            public override long Length => throw new NotSupportedException();

            public override long Position
            {
                get => throw new NotSupportedException(); 
                set => throw new NotSupportedException();
            }

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
