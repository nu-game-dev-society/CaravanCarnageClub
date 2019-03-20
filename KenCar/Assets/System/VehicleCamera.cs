using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VehicleCamera : MonoBehaviour{
	
	public enum View { Full, HalfTop, HalfBottom, HalfLeft, HalfRight, QuarterTopLeft, QuarterTopRight, QuarterBottomLeft, QuarterBottomRight };
	
	[Header("Components")]
	
	public Transform cameraRig;
	
	[Header("Settings")]
	
	public View view = View.Full;
	
	[Range(1, 20)] public float followSpeed	= 16;
	[Range(1, 20)] public float rotationSpeed = 12;
	
	public bool followRotation = true;
	
	// Private
	
	Vector3 cameraPositionOffset;
	Vector3 cameraRotationOffset;
	
	[HideInInspector] public Camera camera;
	
	// Functions
	
	void Awake(){
		
		// Remember offset set in editor
		
		cameraPositionOffset = cameraRig.localPosition;
		cameraRotationOffset = cameraRig.localEulerAngles;
		
		// Get camera
		
		camera = cameraRig.GetChild(0).GetComponent<Camera>();
		
		// Set camera
		
		UpdateCamera();
		
	}
	
	void UpdateCamera(){
		
		// Set camera viewport based on selected option
		
		switch(view){
			
			case View.Full:					camera.rect	= new Rect(  0,   0,   1,   1); break;
			case View.HalfTop:				camera.rect = new Rect(  0, .5f,   1, .5f); break;
			case View.HalfBottom:			camera.rect = new Rect(  0,   0,   1, .5f); break;
			case View.HalfLeft:				camera.rect	= new Rect(  0,   0, .5f,   1); break;
			case View.HalfRight:			camera.rect = new Rect(.5f,   0, .5f,   1); break;
			
			case View.QuarterTopLeft:		camera.rect	= new Rect(  0, .5f, .5f, .5f); break;
			case View.QuarterTopRight:		camera.rect	= new Rect(.5f, .5f, .5f, .5f); break;
			case View.QuarterBottomLeft:	camera.rect	= new Rect(  0,   0, .5f, .5f); break;
			case View.QuarterBottomRight:	camera.rect	= new Rect(.5f,   0, .5f, .5f); break;
			
		}
		
	}
	
	void FixedUpdate(){
		
		// Camera follow
		
		cameraRig.position = Vector3.Lerp(cameraRig.position, transform.position + cameraPositionOffset, Time.deltaTime * followSpeed);
		if(followRotation){ cameraRig.rotation = Quaternion.Lerp(cameraRig.rotation, Quaternion.Euler(transform.eulerAngles + cameraRotationOffset), Time.deltaTime * rotationSpeed); }
		
	}
	
}