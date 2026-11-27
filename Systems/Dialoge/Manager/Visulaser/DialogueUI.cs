using Godot;
using System;
using System.Threading.Tasks;


[GlobalClass]
public partial class DialogueUI : Node
{
	// conected nodes
	private NinePatchRect window;
	private AnimationPlayer animations;
	private AudioStreamPlayer audio;
	private TextureRect portrait;
	private RichTextLabel text;
	private Timer timer;
	
	public bool skipDialouge = false;
	
	// data
	private float textShowSpeed = 0.04f;
	private float pitchScale = 1.0f;
	
	byte beepStep = 2; 
	byte currentCharStep = 0;
	// spaces in characters between "Beep" sounds
	
	public override void _Ready()
	{
		window = GetNode<NinePatchRect>("../Window");
		animations = GetNode<AnimationPlayer>("../AnimationPlayer");
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
		portrait = GetNode<TextureRect>("../Window/Content/Portrait");
		text = GetNode<RichTextLabel>("../Window/Content/Text");
		timer = GetNode<Timer>("../Timer");
	}
	public async Task TypeText(string endText, float speed, float pitchScale, float soundScale)
	{
		GD.Print("Entered TypeText");
		double VisibleRatioStep = 1.0 / endText.Length;
		// calculates the step for V.R. changing  for each iteration
		
		currentCharStep = 0;
		audio.PitchScale = pitchScale;
		audio.VolumeDb = soundScale;
		
		text.VisibleRatio = 0;
		text.Text = endText;
		// sets data
		
		
		GD.Print("Starting typing...");
		for (int i = 0; i < endText.Length; i++) {
			
			text.VisibleRatio += (float)VisibleRatioStep;
			Beep();
			timer.Start(0.075 / speed);
			
			
			await ToSignal(timer, Timer.SignalName.Timeout);
			// typewriter effect
			
			GD.Print("Beep");
			
			if (skipDialouge == true) {
				skipDialouge = false;
				GD.Print("Skiped");
				break;
			}
		}
		
		text.VisibleRatio = 1;
		
		GD.Print("Replica finished! \n",
		 "Waiting for input...");
		while (!skipDialouge) await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		skipDialouge = false;
		
		GD.Print("Input recived! \n", 
		"Finished typing replica.");
		
		return;
	}

	public void SetPortrait(Texture2D newPortrait)
	{
		portrait.Texture = newPortrait;
	} 

	public void ShowDialogue()
	{
		GD.Print("Animation method exists");
		animations.Play("Dialogue_open");
		return;
	}
	
	public void HideDialogue()
	{
		animations.Play("Dialogue_close");
		return;
	}
	
	// detects "enter" input
	public override void _UnhandledInput(InputEvent @event) 
	{
		if (@event.IsActionPressed("ui_accept")) skipDialouge = true;
	}
	
	public void Beep() 
	{
	currentCharStep++;
		if (currentCharStep >= beepStep)
		{
			audio.Play();
			currentCharStep = 0;
		}
	}
}  
