using Godot;

[GlobalClass]
public partial class DialogueLine : Resource
{
	[Export]
	public string[] Translations { get; set; } = [];
	
	[Export]
	public DialogueCharacter Character { get; set; }
	
	[Export]
	public string Expression { get; set; } = "";
	
	[Export]
	public ToneModulation tone { get; set; }
}
