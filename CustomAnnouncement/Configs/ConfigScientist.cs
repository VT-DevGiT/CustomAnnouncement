using Synapse.Config;
using System.ComponentModel;

namespace CustomAnoucement
{

  public class ConfigScientist : IConfigSection
  {
    [Description("Message played by cassie at the escape of scientist (leave blank for none)")]
    public string SciEscapeMessage { get; set; } = "Scientist escape";

    [Description("Make the cassie announcement Glitchy")]
    public bool makeHold { get; set; } = false;

    [Description("Make the cassie annouce Noisy")]
    public bool isNoisy { get; set; } = false;
  }
}