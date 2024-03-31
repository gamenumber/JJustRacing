using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WheelInfo
{
	public WheelCollider Left;
	public WheelCollider Right;
	public bool Motor;
	public bool Steer;
}

public class CarMoveSystem : MonoBehaviour
{
	public WheelInfo[] WheelInfo;
	public float Speed;
	public float MaxMotor;
	public float MaxSteer;
	public float BreakForce;
	public Rigidbody rb;
	private void Start()
	{
		GameInstance.instance.PlayerCarSpeed = Speed;
	}
	public void CarMove(float motor, float steer, bool bIsbreak)
	{
		motor *= MaxMotor * Speed;
		steer *= MaxSteer;

		foreach (var wheel in WheelInfo) 
		{
			if (wheel.Motor)
			{
				wheel.Left.motorTorque = motor;
				wheel.Right.motorTorque = motor;
			}

			if (wheel.Steer)
			{
				wheel.Left.steerAngle = steer;
				wheel.Right.steerAngle = steer;
			}

			float isbreak = (bIsbreak ? 1 : 0);

			wheel.Left.brakeTorque = BreakForce * isbreak;
			wheel.Right.brakeTorque = BreakForce * isbreak;

		}
	}
}
