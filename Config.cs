using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace AutoTeamJoin {
    internal static class Config {
        public static int Team = 0;

        private static readonly string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "AutoTeamJoin.json");
        private static readonly Preferences Configuration = new Preferences(ConfigPath);

        public static void Load() {
            var success = ReadConfig();

            if (success) return;

            ErrorLogger.Log("Failed to read AutoTeamJoin's Config file. Recreating config...");
            CreateConfig();
        }

        private static bool ReadConfig() {
            if (!Configuration.Load()) return false;

            var team = "";
            Configuration.Get("Team", ref team);

            switch (team.ToLower()) {
                case "red":    Team = 1; break;
                case "green":  Team = 2; break;
                case "blue":   Team = 3; break;
                case "yellow": Team = 4; break;
                case "purple": Team = 5; break;
                default:       Team = 0; break;
            }

            return true;
        }

        private static void CreateConfig() {
            Configuration.Clear();
            Configuration.Put("Team", "red");
            Configuration.Save();
        }
    }
}
