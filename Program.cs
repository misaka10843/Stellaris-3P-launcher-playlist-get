using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;

public class App
{
    public static string InstallPath = "../../../";
    static void Main()
    {
        byte[] launcher_v2 = ConsoleApp1.Resource1.launcher_v2_yhyz;
        UnZIP(launcher_v2, InstallPath);
    }

    public static void UnZIP(byte[] zip, string path)
    {
        //IL_0013: Unknown result type (might be due to invalid IL or missing references)
        //IL_0019: Expected O, but got Unknown
        path += "\\";
        ZipInputStream val = new ZipInputStream((Stream)new MemoryStream(zip));
        ZipEntry nextEntry;
        while ((nextEntry = val.GetNextEntry()) != null)
        {
            string directoryName = Path.GetDirectoryName("launcher-v2.sqlite");
            string fileName = Path.GetFileName("launcher-v2.sqlite");
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(path + directoryName);
            }
            if (!(fileName != string.Empty))
            {
                continue;
            }
            using FileStream fileStream = File.Create(path + nextEntry);
            int num = 2048;
            byte[] array = new byte[2048];
            while (true)
            {
                num = ((Stream)(object)val).Read(array, 0, array.Length);
                if (num > 0)
                {
                    fileStream.Write(array, 0, num);
                    continue;
                }
                break;
            }
        }
    }
}