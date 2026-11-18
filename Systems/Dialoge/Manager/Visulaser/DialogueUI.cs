using Godot;
using System;

using Godot;

public partial class DialogueUI : CanvasLayer
{
	private NinePatchRect window;
	private AnimationPlayer animations;
	private AudioStreamPlayer audio;
	private TextureRect portrait;
	private RichTextLabel text;
	public override void _Ready()
	{
		window = GetNode<NinePatchRect>("Window");
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
		audio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		portrait = GetNode<TextureRect>("Window/Content/Portrait");]
		text = GetNode<RichTextLabel>("Window/Content/Text");
		
	}

	public void SetText(string text)
	{
		text.Text = text;
	}

	public void SetPortrait(Texture2D portrait)
	{
		portrait.Texture = portrait;
	}

	public void ShowDialogue()
	{
		window.Visible = true;
		animations.play("Dialouge_open");
	}

	public void HideDialogue()
	{
		animations.play("Dialouge_close");
		window.Visible = false;
	}
}
