using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerUI : MonoBehaviour
{
	private Rigidbody _rb;
	public TextMeshProUGUI PlayerTime;
	public TextMeshProUGUI Speed;
	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		PlayerTime.text = "Time : " + GameInstance.instance.GamePlayTime.ToString("0.00");
		Speed.text = "Speed : " + _rb.velocity.magnitude.ToString("0.00");
	}
}
