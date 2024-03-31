using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : BaseItem
{
    public int GetGold;
	public override void OnGetItem(PlayerController player)
	{
		base.OnGetItem(player);
		GameManager.Instance.AddCoin(GetGold);
	}
}
