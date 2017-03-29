using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {

    public float jumpElevationInDegrees = 45;
    public float[] jumpSpeedInCMPS = { 200, 400, 700 };
    //public float jumpGroundClearance = 2;
    //public float jumpSpeedTolerance = 5;

    public int collisionCount = 0;
    public int hopCount = 0;

    void OnCollisionEnter()
    {
        collisionCount++;
    }

    void OnCollisionExit()
    {
        collisionCount--;
    }

	void Update () {

		bool isOnGround = collisionCount > 0;

        if (isOnGround)
        {
            hopCount = 0;
        }

		//if (GvrViewer.Instance.Triggered)
        if (GvrViewer.Instance.Triggered && hopCount < jumpSpeedInCMPS.Length)

		{
            var camera = GetComponentInChildren<Camera>();
            // get cam look direction projected on horizontal ground plane
            var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            // convert jump angle
            var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
            // rotate projected look direction upward
            var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
            // normalize and create jump vector
            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInCMPS[hopCount];

            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);

            hopCount++;
		}
	}
}
