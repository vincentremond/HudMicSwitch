using System.IO;

namespace HudMicSwitch
{
    public static class Yaml
    {
        public static T GetFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return GetFromString<T>(content);
        }
        public static T GetFromString<T>(string content)
        {
            var deserializer = new YamlDotNet.Serialization.Deserializer();
            return deserializer.Deserialize<T>(content);
        }
    }
}
