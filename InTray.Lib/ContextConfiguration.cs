using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace InTray.Lib
{
    public class ContextConfiguration
    {
        [YamlMember(Alias = "application_name")]
        public string ApplicationName { get; set; }
        [YamlMember(Alias = "executable_paths")]
        public string[] ExecutablePaths { get; set; }
        [YamlMember(Alias = "icon_path")]
        public string IconPath { get; set; }
        [YamlMember(Alias = "main_window_class")]
        public string MainWindowClass { get; set; }
        [YamlMember(Alias = "main_window_text_regexp")]
        public string MainWindowTextRegexp { get; set; }

        private static IDeserializer deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
        private static ISerializer serializer = new SerializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

        public static ContextConfiguration ImportFromFile(string file)
        {
            var fileText = File.ReadAllText(file);
            var config = deserializer.Deserialize<ContextConfiguration>(fileText);
            return config;
        }

        public static void ExportToFile(string file, ContextConfiguration config)
        {
            var fileText = serializer.Serialize(config);
            File.WriteAllText(file, fileText);
        }
    }
}
