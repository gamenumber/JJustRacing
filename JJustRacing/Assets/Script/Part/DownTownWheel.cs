using UnityEngine;

public class DownTownWheel : BasePart
{
	public ParticleSystem _particleSystem;
	public TerrainIntheCar _terrainIntheCar;
	public PlayerController _playerController;

	public override void OnGetPart(CarMoveSystem car)
	{
		_playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		_terrainIntheCar = GameObject.FindWithTag("Player").GetComponent<TerrainIntheCar>();
		if (_particleSystem == null)
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}
		base.OnGetPart(car);
		_playerController.b_buyDownTown = true;

	}
}