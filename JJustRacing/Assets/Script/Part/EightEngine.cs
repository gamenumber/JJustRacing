using UnityEngine;

public class EightEngine : BasePart
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
		_terrainIntheCar.baseSpeed =+ 4;
		_playerController.b_buyEight= true;

	}
}