using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vehicle))]
public class AIVehicle : MonoBehaviour {

    Vehicle m_Vehicle;

    public enum BrakeCondition{ NEVER_BREAK, TARGETDISTANCE }
    public BrakeCondition brakeCondition;
    [Tooltip("Target Brake Distance if Brake Condition")] [SerializeField] float targetBreakDistance;


    [SerializeField] private float m_SteerSensitivity = 0.05f;                                // how sensitively the AI uses steering input to turn to the desired direction
    [SerializeField] private float m_AccelSensitivity = 0.04f;                                // How sensitively the AI uses the accelerator to reach the current desired speed
    [SerializeField] private float m_BrakeSensitivity = 1f;

    Rigidbody m_rigidbody;

    // Use this for initialization
    void Start ()
    {
        m_Vehicle = GetComponent<Vehicle>();
        m_Vehicle.controllable = false;

        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
