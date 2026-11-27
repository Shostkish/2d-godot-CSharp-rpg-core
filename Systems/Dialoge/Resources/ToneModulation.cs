using Godot;
using System;

[GlobalClass]
public partial class ToneModulation : Resource
{
	[Export]
	public float pitchScale { get; set; } = 1.0f;
	[Export]
	public float speedScale { get; set; } = 1.0f; // coefficient
	[Export]
	public float volumeScale { get; set; } = 0.0f; // In decibels
}
