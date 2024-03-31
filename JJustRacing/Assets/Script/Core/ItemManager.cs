using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumTypes
{
	public enum ItemName
	{
		Boost, Booost, Shop, SmallGold, MiddleGold, BigGold
	}

	public enum PartName
	{
		DesertWheel, MountainWheel, DownTownWheel, SixEngine, EightEngine
	}
}

[System.Serializable]
public class Item
{
	public EnumTypes.ItemName Name;
	public GameObject ItemPrefab;
}

public class BaseItem : MonoBehaviour
{
	public virtual void OnGetItem(PlayerController player){}
}

public class ItemManager : BaseManager
{
	public List<Item> items = new List<Item>();
	public List<Transform> Waypoints = new List<Transform>();
	public List<GameObject> CurrentspawnItems = new List<GameObject>();
	public float Interval = 30f;
	public int MaxSpawnCount = 3;

	private void Start()
	{
		Waypoints = GameManager.Instance.spawnManager.waypoints;
		InvokeRepeating("SpawnIntheWorld", Interval, Interval);
	}

	public void SpawnItems(GameObject itemPrefab, Vector3 position)
	{
		Instantiate(itemPrefab, position, Quaternion.identity);
	}

	public Vector3 SetPos(Vector3 t)
	{
		t += new Vector3(0, 100, 0);
		RaycastHit hit;
		if (Physics.Raycast(t, Vector3.down, out hit))
		{
			t = hit.point;
		}
		return t;
	} 

	public void SpawnIntheWorld()
	{
		foreach (Transform waypoint in Waypoints)
		{
			if (Random.Range(0, 5) == 0)
			{
				int spawnCount = Random.Range(1, MaxSpawnCount + 1);
				for (int i = 0; i < spawnCount; i++)
				{
					int spawnIndex = Random.Range(0, items.Count);
					Vector3 spawnposition = new Vector3(waypoint.position.x + Random.Range(-1, 2) * 3f, 0, waypoint.position.z);
					spawnposition = SetPos(spawnposition);
					GameObject instance = Instantiate(items[spawnIndex].ItemPrefab, spawnposition, Quaternion.identity);
					CurrentspawnItems.Add(instance);
				}
			}
		}
	}
}
