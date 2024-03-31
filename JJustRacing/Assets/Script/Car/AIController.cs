using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;

public class AIController : MonoBehaviour
{
	private CarMoveSystem _carMoveSystem;
	public List<Transform> WayPoints; 
	private Vector3 _targetPoint;
	private int _wayPointCount;
	public float MoveSpeed = 5;
	public bool bStageStart = false;
	public float DelayTime = 3.6f;

	private void Start()
	{
		StartCoroutine(AICountDown());
		WayPoints = GameManager.Instance.spawnManager.waypoints;
		_carMoveSystem = GetComponent<CarMoveSystem>();
	}

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

	void MoveAI()
	{
		FindNearWaypoint();

		Vector3 WaypointDistance = transform.InverseTransformPoint(_targetPoint);
		WaypointDistance = WaypointDistance.normalized;
		float steering = WaypointDistance.x;

		_carMoveSystem.CarMove(1, steering, false);
	}

	void FindNearWaypoint()
	{
		_targetPoint = WayPoints[_wayPointCount].position;
		if (Vector3.Distance(transform.position, _targetPoint) <= 3f)
		{
			if (WayPoints.Count - 1 > _wayPointCount)
			{
				_wayPointCount++;
			}
			else
			{
				_carMoveSystem.CarMove(0, 0, true);
				return;
			}
		}
	}

}