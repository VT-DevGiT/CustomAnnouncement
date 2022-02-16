using Synapse.Command;
using Synapse.Api;
using Synapse.Api.Plugin;
using CustomAnoucement;
using System.Runtime.Remoting.Messaging;

namespace repos.Commands
{
  [CommandInformation(
      Name = "playannounce",
      Aliases = new string[] { "pa" },
      Description = "play an announce",
      Permission = "ca.play",
      Platforms = new[] { Platform.RemoteAdmin },
      Usage = "playannounce {sci, player, chaos, d, start, end} v/p"
      )]
  public class PlayAnnounce : ISynapseCommand
  {
    public CommandResult Execute(CommandContext context)
    {
      var result = new CommandResult();
      if (context.Arguments.Count == 2)
      {
        string announcetype = context.Arguments.Array[1];
        string txtAud = context.Arguments.Array[2];

        switch (announcetype.ToLower())
        {
          case "player":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigPlayer.Message, Plugin.ConfigPlayer.makeHold, Plugin.ConfigPlayer.isNoisy);
            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigPlayer.Message;

            }

            break;
          case "chaos":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigRespawn.Message, Plugin.ConfigRespawn.makeHold, Plugin.ConfigRespawn.isNoisy);

            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigRespawn.Message;

            }
            break;
          case "d":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigD.Message, Plugin.ConfigD.makeHold, Plugin.ConfigD.isNoisy);
            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigD.Message;

            }
            break;
          case "sci":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigScientist.Message, Plugin.ConfigScientist.makeHold, Plugin.ConfigScientist.isNoisy);

            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigScientist.Message;

            }
            break;
          case "start":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigStart.Message, Plugin.ConfigStart.makeHold, Plugin.ConfigStart.isNoisy);

            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigStart.Message;

            }
            break;
          case "end":
            if (txtAud.ToLower() == "p" || txtAud.ToLower() == "play")
            {
              Server.Get.Map.Cassie(Plugin.ConfigEnd.Message, Plugin.ConfigEnd.makeHold, Plugin.ConfigEnd.isNoisy);

            }
            else if (txtAud.ToLower() == "t" || txtAud.ToLower() == "text")
            {
              result.Message = Plugin.ConfigEnd.Message;

            }
            break;
        }
        result.State = CommandResultState.OK;

      }
      else
      {
        result.State = CommandResultState.Error;
        result.Message = "Incorrect numbers of argument";
      }

      return result;
    }
  }
}