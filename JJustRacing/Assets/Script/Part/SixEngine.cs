using UnityEngine;

public class SixEngine : BasePart
{
	public ParticleSystem _particleSystem;
	public TerrainIntheCar _terrainIntheCar;
	public PlayerController _playerController;

	public override void OnGetPart(CarMoveSystem car)
	{
		_playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		_terrainIntheCar = GameObject.FindWithTag("Player").GetComponent<TerrainIntheCar>();
		_particleSystem.Play();
		base.OnGetPart(car);
		_terrainIntheCar.baseSpeed =+ 2;
		_playerController.b_buySix = true;

	}
}