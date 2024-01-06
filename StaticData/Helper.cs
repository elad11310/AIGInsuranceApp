using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AIGInsuranceApp.StaticData
{
    public static class Helper
    {


        public static string GetFilePath(string folderName, string fileName)
        {

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory; // Get the application's base directory
            DirectoryInfo parentDir = Directory.GetParent(currentDirectory); // Go up from bin/Debug
            parentDir = Directory.GetParent(parentDir.FullName);

            string projectDirectory = parentDir.FullName.Substring(0, parentDir.FullName.Length - 4);

            string resultsFolderPath = Path.Combine(projectDirectory, folderName);
            return Path.Combine(resultsFolderPath, fileName);
        }

        public static string ReadFromFile(string filePath)
        {
            StringBuilder res = new StringBuilder();
            try
            {
                // Reading all lines from the text file
                string[] lines = File.ReadAllLines(filePath);


                foreach (string line in lines)
                {
                    res.Append(line);
                }
                return res.ToString();
            }
            catch (IOException e)
            {
                throw new FileLoadException($"Error reading the file: {e.Message}");
            }
        }


        public static async Task<string> MakeAPIRequest(string url, List<KeyValuePair<string, string>> parameters, Dictionary<string, string> headers = null)
        {
            // Constructing the URL with query  parameters
            string urlWithParams = ConstructUrlWithParameters(url, parameters);


            using (HttpClient client = new HttpClient())
            {
                // Adding headers if there any
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlWithParams);

                    // Checking if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading content as string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Error: {response.StatusCode}");
                        return "";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request Exception: {e.Message}");
                    return "";
                }

            }
        }

        
        public static string ConstructUrlWithParameters(string baseUrl, List<KeyValuePair<string, string>> parameters)
        {
            // Constructing the URL with parameters
            if (parameters != null && parameters.Count > 0)
            {
                baseUrl += "?";
                baseUrl += string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
            }
            return baseUrl;
        }

    }
}
