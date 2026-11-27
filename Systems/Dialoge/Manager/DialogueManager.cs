using Godot;
using System;
using System.Threading.Tasks;

public partial class DialogueManager : Node
{
	public DialogueUI UI;
	
	[Export]
	public Dialogue test;
	// for test
	
	
	//public enum LanguagesData {
		//English,
		//Example
	//}
	// for future translation system
	
	public async override void _Ready() 
	{
		GD.Print("Entered tree. \n ");
		
		UI = GetNode<DialogueUI>("dialougeUI");
		
		GD.Print("Starting dialogue...");
		await StartDialogue(test); // test
	}
	
	public async Task StartDialogue(Dialogue dialogue) 
	{
		GD.Print("Dialogue started.");
		UI.ShowDialogue();
		GD.Print("Showing animation played.");
		
		foreach (DialogueLine line in dialogue.Lines) {
			GD.Print("Outputing text ", line);
			await UI.TypeText(line.Translations[0], 
			line.tone.speedScale,
			line.tone.pitchScale, 
			line.tone.volumeScale);
		}
		
		UI.HideDialogue();
		GD.Print("finishing");
		return;
	} 
}
