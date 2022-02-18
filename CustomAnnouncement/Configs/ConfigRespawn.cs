using Synapse.Config;
using System.ComponentModel;

namespace CustomAnoucement
{

  public class ConfigRespawn : IConfigSection
  {
    [Description("Message played by cassie at the spawn of chaos (leave blank for none)")]
    public string Message { get; set; } = "";
    
    [Description("Make the cassie announcement Glitchy")]
    public bool makeHold { get; set; } = false;

    [Description("Make the cassie annouce Noisy")]
    public bool isNoisy { get; set; } = false;
  }
}