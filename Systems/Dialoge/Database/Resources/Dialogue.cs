using Godot;

[GlobalClass]
public partial class Dialogue : Resource
{
	[Export]
	public DialogueLine[] Lines { get; set; } = [];
}
