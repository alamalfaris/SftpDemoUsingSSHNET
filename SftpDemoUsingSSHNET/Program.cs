using Renci.SshNet;

namespace SftpDemoUsingSSHNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(SftpClient client = new SftpClient(new PasswordConnectionInfo("host/ip", "username", "password")))
            {
                client.Connect();

                // Upload file to SFTP server
                //string sourceFile = $"C:\\mydata\\alam\\ttd.png";
                //using (Stream stream = File.OpenRead(sourceFile))
                //{
                //    client.UploadFile(stream, $"\\TestSftp\\" + Path.GetFileName(sourceFile));
                //}

                // Download file to SFTP Client
                //string serverFile = $"\\TestSftp\\test.txt";
                //string localFile = $"C:\\mydata\\alam\\" + Path.GetFileName(serverFile);
                //using (Stream stream = File.OpenWrite(localFile))
                //{
                //    client.DownloadFile(serverFile, stream);
                //}

                // Read file
                //string serverFile = $"\\TestSftp\\test.txt";
                //var results = client.ReadAllText(serverFile);
                //Console.WriteLine(results);

                // Delete file
                //string serverFile = $"\\TestSftp\\ttd.png";
                //client.DeleteFile(serverFile);

                // List
                string serverDirectory = $"\\TestSftp";
                var files = client.ListDirectory(serverDirectory).ToList();
                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        Console.WriteLine(file.Name);
                        Console.WriteLine(file.FullName);
                    }
                }

                client.Disconnect();
            }
        }
    }
}