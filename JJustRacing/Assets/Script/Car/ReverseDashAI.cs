using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReverseDashAI : MonoBehaviour
{
	private CarMoveSystem _carMoveSystem;
	public List<Transform> Waypoint;
	private Vector3 _targetPosition;
	public float MoveSpeed = 10;
	private int _waypointCount = 0;
	public bool bStageStart = false;
	public float DelayTime = 3.6f;

	IEnumerator AICountDown()
	{
		yield return new WaitForSeconds(DelayTime);
		bStageStart = true;
	}
	private void FixedUpdate()
	{
		if (bStageStart)
		{
			MoveAI();
		}
	}
	private void Start()
	{
		StartCoroutine(AICountDown());
		Waypoint = GameManager.Instance.spawnManager.waypoints;
		_carMoveSystem = GetComponent<CarMoveSystem>();
	}

	public void MoveAI()
	{
		FindNearWaypoint();
		Vector3 Distance = transform.InverseTransformPoint(_targetPosition);
		Distance = Distance.normalized;
		float steer = Distance.x;
		_carMoveSystem.CarMove(MoveSpeed, steer, false);
	}

	public void FindNearWaypoint()
	{
		if (Vector3.Distance(transform.position, _targetPosition) <= 3f)
		{
			if (Waypoint.Count - 1 > _waypointCount)
			{
				_waypointCount++;
			}

			else
			{
				_carMoveSystem.CarMove(0, 0, true);
				return;
			}
		}
	}

}
