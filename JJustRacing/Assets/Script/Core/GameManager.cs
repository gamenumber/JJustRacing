using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{ 
	public static GameManager Instance;
	public AISpawnManager spawnManager;
	public ItemManager itemManager;
	public ShopManager shopManager;
	public PartManager partManager;
	public TextMeshProUGUI CountDownText;
	public bool bStageStarted = false;
	IEnumerator CountDown()
	{
		CountDownText.text = "3";
		yield return new WaitForSeconds(1f);
		CountDownText.text = "2";
		yield return new WaitForSeconds(1f);
		CountDownText.text = "1";
		yield return new WaitForSeconds(1f);
		CountDownText.gameObject.SetActive(false);
		yield return null;	
	}
	private void Start()
	{
		StartCoroutine(CountDown());
		if (spawnManager)
			spawnManager.Init(this);
		if (itemManager)
			itemManager.Init(this);
		if (shopManager)
			shopManager.Init(this);
		if (partManager) 
			partManager.Init(this);
	}

	public void LapCountInit()
	{
		GameInstance.instance.PlayerLapCount = 0;
		GameInstance.instance.EnemyLapCount = 0;
	}
	private void Awake()
	{
		if(Instance)
		{
			Destroy(Instance);
		}
		else
		{
			Instance = this;
		}
	}
	public void AddCoin(int coin)
	{
		GameInstance.instance.Coin += coin;
	}
	public void AddScore(int score)
	{
		GameInstance.instance.Score += score;
	}
	public void ReloadScene()
	{
		LapCountInit();
		SceneManager.LoadScene($"{SceneManager.GetActiveScene().name}");
		Time.timeScale = 1f;
	}
	public void LoadNextScene()
	{
		if (SceneManager.GetActiveScene().name == "Stage1")
		{
			LapCountInit();
			GameInstance.instance.GamePlayTime = 0f;
			Time.timeScale = 1f;
			SceneManager.LoadScene("Stage2");
		}
		else if (SceneManager.GetActiveScene().name == "Stage2")
		{
			LapCountInit();
			GameInstance.instance.GamePlayTime = 0f;
			Time.timeScale = 1f;
			SceneManager.LoadSceneAsync("Stage3");
		}
		else
		{
			LapCountInit();
			GameInstance.instance.GamePlayTime = 0f;
			Time.timeScale = 1f;
			SceneManager.LoadScene("Stage1");
		}
	}
	public void GoingResult()
	{
		LapCountInit();
		SceneManager.LoadScene("Result");
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F2))
		{
			shopManager.IsFree = true;
			shopManager.GoingShop();
		}

		else if (Input.GetKeyDown(KeyCode.F3))
		{
			ReloadScene();
		}

		else if (Input.GetKeyDown(KeyCode.F4))
		{
			LoadNextScene();
		}

		else if (Input.GetKeyDown(KeyCode.F6))
		{
			GameInstance.instance.LapCountPlus();
		}

		else if (Input.GetKeyDown(KeyCode.F7))
		{
			GoingResult();
		}

	}
	public void GameEnd()
	{
		if (GameInstance.instance.GamePlayTime < 300)
		{
			AddScore(200);
			AddCoin(10000000);
		}
		else if (GameInstance.instance.GamePlayTime < 260)
		{
			AddScore(150);
			AddCoin(10000000);
		}

		else if (GameInstance.instance.GamePlayTime < 200)
		{
			AddScore(100);
			AddCoin(10000000);
		}

		else
		{
			AddScore(50);
			AddCoin(10000000);
		}
	}
	public void GameStart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Stage1");
	}
	public void GameQuit()
	{
		Application.Quit();
	}

}
