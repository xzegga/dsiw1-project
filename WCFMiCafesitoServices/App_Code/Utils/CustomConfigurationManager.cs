using Newtonsoft.Json;
using System;
using System.IO;


public class CustomConfigurationManager
{
    public string ConnectionString { get; private set; }
    public string Patron { get; private set; }

    public CustomConfigurationManager()
    {
        string jsonFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "keys.json"
        );

        try
        {
            using (StreamReader reader = File.OpenText(jsonFilePath))
            {
                string json = reader.ReadToEnd();
                dynamic configData = JsonConvert.DeserializeObject(json);
                ConnectionString = configData.connectionString;
                Patron = configData.patron;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar la conexión a la base de datos: " + ex.Message);
        }
    }

    public static implicit operator string(CustomConfigurationManager v)
    {
        throw new NotImplementedException();
    }
}