using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AutoTeamJoin {
    class AutoTeamJoinPlayer : ModPlayer {
        public override void OnEnterWorld(Player player) {
            if (Main.LocalPlayer != player) return;

            Config.Load();
            Main.LocalPlayer.team = Config.Team;
        }
    }
}
