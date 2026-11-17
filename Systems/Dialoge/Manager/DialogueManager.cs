using Godot;

public partial class DialogueManager : Node
{
	[Export]
	public int ActiveLanguageIndex = 0;

	public void StartDialogue(Dialogue dialogue)
	{
		foreach (DialogueLine line in dialogue.Lines)
		{
			GD.Print(line.Translations[ActiveLanguageIndex]);
		}
	}

	public override void _Ready()
	{
		Dialogue dialogue = GD.Load<Dialogue>("res://Systems/Dialoge/Database/Test.tres");
		StartDialogue(dialogue);
	}
}
