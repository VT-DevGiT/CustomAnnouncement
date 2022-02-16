using Synapse.Config;
using System.ComponentModel;
using System.Security;

namespace CustomAnoucement
{

  public class ConfigDClass : IConfigSection
  {
    [Description("Message played by cassie at the escape of D boi (leave blank for none)")]
    public string Message { get; set; } = "Escape D";

    [Description("Make the cassie announcement Glitchy")]
    public bool makeHold { get; set; } = false;

    [Description("Make the cassie annouce Noisy")]
    public bool isNoisy { get; set; } = false;
  }
}