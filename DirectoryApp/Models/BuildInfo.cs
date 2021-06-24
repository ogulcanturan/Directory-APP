using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DirectoryApp.Models
{
    public sealed class BuildInfo
    {
        private readonly int majorVersion;
        private readonly int minorVersion;
        private readonly int year;
        private readonly int dayOfYear;
        private readonly int versionNumberOfTheDay;

        private BuildInfo()
        {
            Tag = Assembly.GetEntryAssembly().GetName().Version.ToString(); //1.0.21172.1
            string[] assemblyVersion = Tag.Split('.');
            _ = int.TryParse(assemblyVersion[0], out majorVersion);
            _ = int.TryParse(assemblyVersion[1], out minorVersion);
            _ = int.TryParse($"{DateTime.Today.Year.ToString().Substring(0, 2)}{assemblyVersion[2].Substring(0, 2)}", out year);
            _ = int.TryParse(assemblyVersion[2].Substring(2), out dayOfYear);
            _ = int.TryParse(assemblyVersion[3], out versionNumberOfTheDay);
            ReleaseDate = new DateTime(Year, 1, 1).AddDays(DayOfYear - 1);
            VersionText = $"Version: {MajorVersion}.{MinorVersion} Build {VersionNumberOfTheDay}({ReleaseDate:MMMM/dd/yy})";
        }

        private static readonly object lockObject = new object();
        private static BuildInfo instance = null;
        public static BuildInfo Instance
        {
            get
            {
                lock (lockObject)
                {
                    return instance ??= new BuildInfo(); // or instance = instance == null ? new BuildInfo() : instance; or if else control or instance == instance ?? new BuildInfo();  
                }
            }
        }
        
        public int MajorVersion => majorVersion;
        public int MinorVersion => minorVersion;
        public int Year => year;
        public int DayOfYear => dayOfYear;
        public DateTime ReleaseDate { get; }
        public int VersionNumberOfTheDay => versionNumberOfTheDay;
        public string VersionText { get; }
        public string Tag { get; }
    }
}