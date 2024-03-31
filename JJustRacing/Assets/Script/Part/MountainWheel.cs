using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainWheel : BasePart
{
	public ParticleSystem _particleSystem;
	public TerrainIntheCar _terrainIntheCar;
	public PlayerController _playerController;
	public override void OnGetPart(CarMoveSystem car)
	{
		_playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		_terrainIntheCar = GameObject.FindWithTag("Player").GetComponent<TerrainIntheCar>();
		_particleSystem = GetComponent<ParticleSystem>();
		_particleSystem.Play();
		base.OnGetPart(car);
		_playerController.b_buyMountain = true;

	}
}
