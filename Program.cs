using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TP1.Paralelismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Threads
            //Stopwatch stopwatch = new();
            //stopwatch.Start();

            //List<Thread> threads = new()
            //{
            //    new Thread(LavarLouca),
            //    new Thread(LavarRoupa),
            //    new Thread(FazerJantar)
            //};

            //foreach (Thread thread in threads)
            //{
            //    thread.Start();
            //}

            //foreach (Thread thread in threads)
            //{
            //    thread.Join();
            //}            

            //new Thread(LavarLouca).Start();
            //new Thread(LavarRoupa).Start();
            //new Thread(FazerJantar).Start();

            //LavarLouca();
            //LavarRoupa();
            //FazerJantar();

            //stopwatch.Stop();

            //WriteLine($"Todo o processo durou: {stopwatch.ElapsedMilliseconds} ms");
            #endregion

            List<string> files = new();
            files.Add("vs.exe");
            files.Add("note.exe");
            files.Add("calc.exe");
            files.Add("word.exe");

            Stopwatch stopwatch = new();
            stopwatch.Start();

            ParallelOptions op = new();
            op.MaxDegreeOfParallelism = 2;

            Parallel.For(0, files.Count, op, i =>
            {
                DownloadFile(files[i]);
            });

            Parallel.ForEach(files, op, file =>
            {
                DownloadFile(file);
            });

            //foreach (string file in files)
            //    DownloadFile(file);

            //Parallel.Invoke(op, () => DownloadFile("chrome.exe"),
            //                () => DownloadFile("opera.exe"),
            //                () => DownloadFile("ie.exe"),
            //                () => DownloadFile("mozila.exe"));

            stopwatch.Stop();
            WriteLine($"Tempo total: {stopwatch.ElapsedMilliseconds} milissegundos");
        }

        public static void DownloadFile(string file)
        {
            Thread.Sleep(5000);
            WriteLine($"Download done: {file} - ThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }

        #region Threads
        static void LavarLouca()
        {
            WriteLine($"Inicio: Lavar louça - Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);            
            WriteLine("Fim: Lavar louça");
        }

        static void LavarRoupa()
        {
            WriteLine($"Inicio: Lavar roupa - Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            WriteLine("Fim: Lavar roupa");
        }

        static void FazerJantar()
        {
            WriteLine($"Inicio: Fazer o jantar - Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(8000);
            WriteLine("Fim: Fazer o jantar");
        }
        #endregion
    }
}