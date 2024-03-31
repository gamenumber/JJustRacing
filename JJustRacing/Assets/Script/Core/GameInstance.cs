using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
	public static GameInstance instance;
	public float GamePlayTime;
	public int Coin;
	public int Score;
	public int PlayerLapCount;
	public int EnemyLapCount;
	public float PlayerCarSpeed;
	public List<Part> partsList = new List<Part>();
	public Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>();

	public bool SixEngine;
	public bool EightEngine;
	public bool DesertWheel;
	public bool MountainWheel;
	public bool DownTownWheel;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void LapCountPlus()
	{
		PlayerLapCount =+ 1;
	}
	public void AddPart(Part part)
	{
		partsList.Add(part);
	}

	public void PurchaseItem(string itemName)
	{
		if (!purchasedItems.ContainsKey(itemName))
		{
			purchasedItems[itemName] = true;
			PlayerPrefs.SetInt(itemName, 1);
			PlayerPrefs.Save();
		}
	}


	public bool IsItemPurchased(string itemName)
	{
		if (purchasedItems.ContainsKey(itemName))
		{
			return purchasedItems[itemName];
		}
		else
		{
			int purchased = PlayerPrefs.GetInt(itemName, 0);
			bool isPurchased = purchased == 1;
			purchasedItems[itemName] = isPurchased;
			return isPurchased;
		}
	}

}


