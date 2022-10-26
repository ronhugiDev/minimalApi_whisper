using System.Diagnostics;

public class RunPythonFromCli
{
    public static void Run(string pythonExePath, string pythonScript)
    {
        ValidateInput(pythonExePath, pythonScript);

        var cmd = $"-u {pythonScript}";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = cmd,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            },
            EnableRaisingEvents = true
        };
        process.ErrorDataReceived += Process_OutputDataReceived;
        process.OutputDataReceived += Process_OutputDataReceived;

        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
        process.WaitForExit();
        Console.Read();
    }

    private static void ValidateInput(string pythonExePath, string pythonScript)
    {
        if (!File.Exists(pythonExePath))
        {
            throw new FileNotFoundException($"File {pythonExePath} not found");
        }
        if (!File.Exists(pythonScript))
        {
            throw new FileNotFoundException($"File {pythonScript} not found");
        }
        
    }

    private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
}