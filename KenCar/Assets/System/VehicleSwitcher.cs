using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSwitcher : MonoBehaviour{
	
    public List<Vehicle> vehicles = new List<Vehicle>();
	
	int index = 0;
	
	void Start(){
		
		foreach(Vehicle vehicle in vehicles){ vehicle.controllable = false; }
		
		SelectVehicle();
		
	}
	
	void Update(){ SelectVehicle(); }
	
	void SelectVehicle(){
		
		vehicles[index].controllable = false;
		vehicles[index].transform.GetComponent<VehicleCamera>().camera.depth = -1;
		
		if(Input.GetKeyDown("v")){
			
			if(index < vehicles.Count - 1){ index++; }else{ index = 0; }
			
		}
		
		vehicles[index].controllable = true;
		vehicles[index].transform.GetComponent<VehicleCamera>().camera.depth = 1;
		
	}
	
}