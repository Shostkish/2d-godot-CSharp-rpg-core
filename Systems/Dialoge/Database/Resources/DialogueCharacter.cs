using Godot;

[GlobalClass]
public partial class DialogueCharacter : Resource
{
	[Export] 
	public string CharacterId { get; set; }
	
	[Export] 
	public string DisplayName { get; set; }
	
	[Export]
	public Godot.Collections.Dictionary<string, Texture2D>
		Expressions { get; set; } = new();
}
