using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
	private CarMoveSystem _carMoveSystem;
	public float BoostSpeed = 7000;
	public GameObject CrushEffect;
	public float EffectDestoryTime = 1f;
	public float DelayTime = 3.6f;

	public bool bStageStart = false;

	public GameObject SixEngine;
	public GameObject EightEngine;
	public GameObject DesertWheel;
	public GameObject DownTownWheel;
	public GameObject MountainWheel;


	public AudioSource CountDown;
	public AudioSource GetItem;
	public AudioSource Boost;
	public AudioSource Crush;

	public bool b_buySix;
	public bool b_buyEight;
	public bool b_buyDesert;
	public bool b_buyMountain;
	public bool b_buyDownTown;
	private void Start()
	{
		b_buyEight = GameInstance.instance.EightEngine;
		b_buySix = GameInstance.instance.SixEngine;
		b_buyDesert = GameInstance.instance.DesertWheel;
		b_buyMountain= GameInstance.instance.MountainWheel;
		b_buyDownTown = GameInstance.instance.DownTownWheel;
		CountDown.Play();
		StartCoroutine(PlayerCountDown());
		_carMoveSystem = GetComponent<CarMoveSystem>();
	}
	private void FixedUpdate()
	{
		if (b_buyEight)
		{
			EightEngine.SetActive(true);
			GameInstance.instance.EightEngine = true;
		}
		if (b_buySix)
		{
			SixEngine.SetActive(true);
			GameInstance.instance.SixEngine = true;
		}
		if (b_buyDesert)
		{
			DesertWheel.SetActive(true);
			GameInstance.instance.DesertWheel = true;
		}
		if (b_buyMountain)
		{
			MountainWheel.SetActive(true);
			GameInstance.instance.MountainWheel = true;
		}
		if (b_buyDownTown)
		{
			DownTownWheel.SetActive(true);
			GameInstance.instance.DownTownWheel = true;
		}
		if (bStageStart)
		{
			MoveInput();
		}
	}
	public void MoveInput()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Boost.Play();
			_carMoveSystem.rb.AddForce(transform.forward * BoostSpeed, ForceMode.Impulse);
		}
		float speed = Input.GetAxis("Vertical");
		float Steer = Input.GetAxis("Horizontal");
		bool isbreak = Input.GetKey(KeyCode.Space);
		_carMoveSystem.CarMove(speed, Steer, isbreak);
	}

	IEnumerator PlayerCountDown()
	{
		yield return new WaitForSeconds(DelayTime);	
		bStageStart = true;
	}
	private void OnTriggerEnter(Collider other)
	{
		BaseItem item = other.GetComponent<BaseItem>();	
		if (item != null)
		{
			GetItem.Play();
		
			item.OnGetItem(this);
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Crush.Play();
		UnityEngine.Vector3 direction = (collision.transform.position - transform.position).normalized;
		float dotForward = UnityEngine.Vector3.Dot(transform.forward, direction);
		float dotRight = UnityEngine.Vector3.Dot(transform.right, direction);
		if (dotForward > 0.5f)
		{
			_carMoveSystem.Speed -= 0.02f;
			SpawnImpactEffect(collision.contacts[0].point);

		}
		else if (dotForward < -0.5f)
		{
			_carMoveSystem.rb.AddForce(transform.forward * 10000, ForceMode.Impulse);
			SpawnImpactEffect(collision.contacts[0].point);

		}
		else if (dotRight > 0.5f)
		{
			_carMoveSystem.Speed -= 0.05f;
			SpawnImpactEffect(collision.contacts[0].point);

		}

		else if (dotRight < -0.5f)
		{
			_carMoveSystem.Speed -= 0.05f;
			SpawnImpactEffect(collision.contacts[0].point);

		}
	}

	private void SpawnImpactEffect(UnityEngine.Vector3 position)
	{
		if (CrushEffect != null)
		{
			GameObject impactEffect = Instantiate(CrushEffect, position, Quaternion.identity);
			Destroy(impactEffect, 0.7f);
		}
	}


}
