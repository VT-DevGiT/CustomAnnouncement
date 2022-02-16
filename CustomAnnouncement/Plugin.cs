using Synapse.Api.Plugin;
using Synapse.Api;
using Synapse;
using Synapse.Api.Events.SynapseEventArguments;
using Synapse.Api.Events;

namespace CustomAnoucement
{
    [PluginInformation(
        Author = "Antoniofo",
        Description = "Make custom anouncement",
        LoadPriority = 0,
        Name = "CustomAnnoucement",
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v1.0.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - Class-D Escape")]
        public static ConfigDClass ConfigD { get; set; }
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - End Round")]
        public static ConfigEnd ConfigEnd { get; set; }
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - Class-D Escape")]
        public static ConfigPlayer ConfigPlayer { get; set; }
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - Resapwn (Chaos)")]
        public static ConfigRespawn ConfigRespawn { get; set; }
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - Scientist Escape")]
        public static ConfigScientist ConfigScientist { get; set; }
        [Synapse.Api.Plugin.Config(section = "CustomAnnouncement - RoundStart")]
        public static ConfigStart ConfigStart { get; set; }
        public override void Load()
        {
            base.Load();
            SynapseController.Server.Events.Round.RoundStartEvent += OnRoundStart;
            SynapseController.Server.Events.Round.TeamRespawnEvent += OnTeamSpawn;
            SynapseController.Server.Events.Player.PlayerEscapesEvent += OnEscape;
            SynapseController.Server.Events.Player.PlayerJoinEvent += OnJoin;
            SynapseController.Server.Events.Round.RoundEndEvent += OnRoundEnd;

        }

        public void OnRoundStart()
        {
            Server.Get.Map.Cassie(ConfigStart.Message, ConfigStart.makeHold, ConfigStart.isNoisy);
        }

        public void OnTeamSpawn(TeamRespawnEventArgs ev)
        {
            if (ev.TeamID == (int)Team.CHI)
            {
                Server.Get.Map.Cassie(ConfigRespawn.Message, ConfigRespawn.makeHold, ConfigRespawn.isNoisy);
            }
        }

        public void OnEscape(PlayerEscapeEventArgs ev)
        {
            if (ev.SpawnRole == (int)RoleType.ClassD)
            {
                Server.Get.Map.Cassie(ConfigD.Message, ConfigD.makeHold, ConfigD.isNoisy);
            }
            else if (ev.SpawnRole == (int)RoleType.Scientist)
            {
                Server.Get.Map.Cassie(ConfigScientist.Message, ConfigScientist.makeHold, ConfigScientist.isNoisy);
            }
        }

        public void OnJoin(PlayerJoinEventArgs ev)
        {
            foreach (string uid in ConfigPlayer.PlayerTrigger)
            {
                if (ev.Player.UserId == uid)
                {
                    Server.Get.Map.Cassie(ConfigPlayer.Message, ConfigPlayer.makeHold, ConfigPlayer.isNoisy);
                }
            }


        }

        public void OnRoundEnd()
        {
            Server.Get.Map.Cassie(ConfigEnd.Message, ConfigEnd.makeHold, ConfigEnd.isNoisy);

        }

        public override void ReloadConfigs()
        {
            base.ReloadConfigs();
        }
    }
}