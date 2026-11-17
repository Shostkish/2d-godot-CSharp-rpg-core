using Godot;
using System;

[GlobalClass]
public partial class ToneModulation : Resource
{
	[Export]
	public double pitchScale { get; set; } = 1.0;
	[Export]
	public double speedScale { get; set; } = 1.0; // coefficient
	[Export]
	public double volumeScale { get; set; } = 0.0; // In decibels
}
