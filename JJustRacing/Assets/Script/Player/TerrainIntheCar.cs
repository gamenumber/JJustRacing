using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainIntheCar : MonoBehaviour
{
	private TerrainDetector terrainDetector;
	private CarMoveSystem moveSystem;
	public float baseSpeed = 10f;
	public GameObject SlowPage;

	void Start()
	{ 
		moveSystem = GetComponent<CarMoveSystem>();
		terrainDetector = new TerrainDetector();
	}

	void Update()
	{
		if (!GameInstance.instance.DesertWheel && SceneManager.GetActiveScene().name == "Stage1" ||
			!GameInstance.instance.MountainWheel && SceneManager.GetActiveScene().name == "Stage2" || 
			!GameInstance.instance.DownTownWheel && SceneManager.GetActiveScene().name == "Stage3")
		{
			int activeTerrainTextureIdx = terrainDetector.GetActiveTerrainTextureIdx(transform.position);
			switch (activeTerrainTextureIdx)
			{
				case 0:
					moveSystem.Speed = baseSpeed;
					SlowPage.gameObject.SetActive(false);
					break;
				default:
					moveSystem.Speed = baseSpeed * 0.3f;
					SlowPage.gameObject.SetActive(true);
					break;
			}
		}
			
		
	}
}
