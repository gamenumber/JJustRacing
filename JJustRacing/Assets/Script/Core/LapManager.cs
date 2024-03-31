using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapManager : MonoBehaviour
{
	public TextMeshProUGUI PlayerLapCount;

	public int MaxLabCount = 3;
	private int currentPlayerLapCount = 0;
	private int currentEnemyLapCount = 0;

	public GameObject WinPage;
	public GameObject LosePage;

	public bool bGameEnd;

	private void Update()
	{
		currentPlayerLapCount = GameInstance.instance.PlayerLapCount;
		currentEnemyLapCount = GameInstance.instance.EnemyLapCount;
		PlayerLapCount.text =  $" {currentPlayerLapCount} / {MaxLabCount}";
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameInstance.instance.PlayerLapCount += 1;
			if (currentPlayerLapCount >= MaxLabCount - 1)
			{
				GameManager.Instance.GameEnd();
				Time.timeScale = 0f;
				WinPage.SetActive(true);
				currentEnemyLapCount = 0;
				currentPlayerLapCount = 0;
			}
		}

		else if (other.CompareTag("Competitor"))
		{
			GameInstance.instance.EnemyLapCount += 1;
			if (currentEnemyLapCount >= MaxLabCount)
			{
				Time.timeScale = 0f;
				LosePage.SetActive(true);
			}
		}
	}
}
