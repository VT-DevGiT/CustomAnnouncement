using Synapse.Config;
using System.ComponentModel;

namespace CustomAnoucement
{

  public class ConfigPlayer : IConfigSection
  {
    [Description("List of player tiggering cassie message when joining the server")]
    public List<String> PlayerTrigger { get; set; } = new List<String>(){
      "ExempleID@steam"
    };
    
    [Description("The message said by cassie when a player trigger cassie via joining")]
    public string Messages { get; set; } = "Player joined";

    [Description("Make the cassie announcement Glitchy")]
    public bool makeHold { get; set; } = false;

    [Description("Make the cassie annouce Noisy")]
    public bool isNoisy { get; set; } = false;
  }
}