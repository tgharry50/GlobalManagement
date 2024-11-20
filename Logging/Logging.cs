using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Identity.Client;

namespace GlobalManagement.Logging
{
    public class Logging(GlobalDatabase Context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = Context;
        public async Task<bool> CreateLogText(string Class, string Type, string Message, TimeSpan End)
        {
            LogToFile log = new()
            {
                Class = Class,
                Type = Type,
                Message = Message,
                End = End,
                CreatedAt = DateTime.Now
            };
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string folder = Path.Combine(baseDirectory, "Log");
                string log_file = Path.Combine(folder, $"Log_{date}.txt");
                if (Directory.Exists(folder))
                {
                    if (System.IO.File.Exists(log_file))
                    {
                        await using StreamWriter sw = System.IO.File.AppendText(log_file);
                        string Json = JsonSerializer.Serialize(log);
                        await sw.WriteLineAsync(Json + "\n");
                    }
                    else
                    {
                        System.IO.File.Create(log_file);
                        await using StreamWriter sw = System.IO.File.AppendText(log_file);
                        string Json = JsonSerializer.Serialize(log);
                        await sw.WriteLineAsync(Json + "\n");
                    }
                    return true;
                }
                else
                {
                    Directory.CreateDirectory(folder);
                    await using StreamWriter sw = System.IO.File.AppendText(log_file);
                    string Json = JsonSerializer.Serialize(log);
                    await sw.WriteLineAsync(Json + "\n");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private struct LogToFile(string @class, string type, string message, TimeSpan end, DateTime createdAt)
        {
            public string Class = @class;
            public string Type = type;
            public string Message = message;
            public TimeSpan End = end;
            public DateTime CreatedAt = createdAt;
        }

        public async Task LogToDatabase(string Class, string Type, string Message, TimeSpan End)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _Log_Model log = new()
            {
                Uuid = Guid.NewGuid(),
                Class = Class,
                Message = Message,
                End = End,
                CreatedDate = DateTime.Now
            };
            try
            {
                await CreateLogText(Class, Type, Message, End);
                await Context.Logs.AddAsync(log);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                stopwatch.Stop();
                await CreateLogText("FATAL", "Logger", e.Message, stopwatch.Elapsed);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failure to save log");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
    
}
