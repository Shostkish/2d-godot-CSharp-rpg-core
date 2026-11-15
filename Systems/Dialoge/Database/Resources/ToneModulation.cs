using Godot;
using System;

[GlobalClass]
public partial class ToneModulation : Resource
{
	[Export]
	public string name { get; set; } = "";
	[Export]
	public double pitchScale { get; set; } = 0.0; // coefficient
	[Export]
	public double speedScale { get; set; } = 0.0; // coefficient
	[Export]
	public double volumeScale { get; set; } = 0.0; // In decibels
}
