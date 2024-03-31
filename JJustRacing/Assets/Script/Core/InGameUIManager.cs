using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
	private Transform _playerTransform;
	public bool bIspaused = false;
	public GameObject PauseImage;
	public GameObject F1Page;

	public GameObject Boost;
	public GameObject Booost;
	public GameObject Shop;
	public GameObject SmallGold;
	public GameObject MiddleGold;
	public GameObject BigGold;

	private void Start()
	{
		_playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>(); 
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			F1Page.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			PauseGame();
			bIspaused = true;
		}
		else if (!bIspaused)
		{
			GameInstance.instance.GamePlayTime += Time.deltaTime;
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;
		PauseImage.gameObject.SetActive(true);
	}

	public void RestartGame()
	{
		bIspaused = false;
		Time.timeScale = 1f;
		PauseImage.gameObject.SetActive(false);	
	}

	public void GoingMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void BigGoldItem()
	{
		Instantiate(BigGold, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}

	public void SmallGoldItem()
	{
		Instantiate(SmallGold, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}

	public void MiddleGoldItem()
	{
		Instantiate(MiddleGold, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}

	public void ShopItem()
	{
		Instantiate(Shop, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}

	public void BoostItem()
	{
		Instantiate(Boost, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}

	public void BooostItem()
	{
		Instantiate(Booost, _playerTransform.position, Quaternion.identity);
		F1Page.gameObject.SetActive(false);
	}


}
