using UnityEngine;
using System.Collections;

public class HUDRotation : MonoBehaviour {

	private Camera myCamera;

	void Start(){
		myCamera = transform.parent.GetComponentInChildren<Camera>();
	}

	void Update () {
		//var camera = transform.parent.GetComponentInChildren<Camera>();
        var projectedLookDirection = Vector3.ProjectOnPlane(myCamera.transform.forward, Vector3.up);
        transform.rotation = Quaternion.LookRotation(projectedLookDirection);

        //Vector3 lookDirection = camera.transform.forward;
		//lookDirection = new Vector3(angle.x, 0, angle.z);
		//transform.rotation = Quaternion.LookRotation(lookDirection);

	}
}
