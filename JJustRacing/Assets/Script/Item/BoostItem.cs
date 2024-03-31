using Cinemachine;
using UnityEngine;

public class BoostItem : BaseItem
{
	public float BoostSpeed = 5f;
	private CinemachineVirtualCamera playerCamera;
	private Vector3 forwardDirection; 
	public Rigidbody rb;
	public AudioSource Boost;
	public override void OnGetItem(PlayerController player)
	{
		base.OnGetItem(player);
		rb.velocity += forwardDirection * BoostSpeed;
		Boost.Play();
	}

	void Start()
	{
		rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
		playerCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
		Transform transform = GameObject.Find("Audio").GetComponent<Transform>();
		Boost = transform.GetChild(3).GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		forwardDirection = playerCamera.transform.forward;
		forwardDirection.y = 0f;
		forwardDirection.Normalize();
	}
}