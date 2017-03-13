using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Cameras;
using UnityEngine;

public class Main3dCameraAlternative : MonoBehaviour, ICamera {

    [SerializeField]
    Vector3 startPosition;

    [SerializeField]
    Transform target;
    
    // Читать доки про то, как работает Vector3.SmothDamp
    [SerializeField]
    Vector3 velocity = Vector3.one;

    private Func<Vector3> cameraLogic;

    public Vector3 currentCameraPosition
    {
        get
        {
            return transform.position;
        }
         set {

            transform.position = value;
        }
    }

    public Quaternion currentRotation
    {
        get
        {
            return transform.rotation;
        }
        private set {
            transform.rotation = value;
        }
    }

    public Transform followingObject
    {
        get
        {
            return target;
        }
    }

    // Use this for initialization
    void Start () {
        cameraLogic = SmoothFollow;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        currentCameraPosition = cameraLogic();
        CameraLooksAt();
    }

    private Vector3 SmoothFollow() {
        Vector3 destination = followingObject.position + (followingObject.rotation * startPosition);
        return SmoothVector(destination, 0.1f);
    }

    private Vector3 TwoDimensionalMovement() {
        Vector3 destination = followingObject.position + followingObject.right * 18 + followingObject.up * 2;
        return SmoothVector(destination, 0.089f);
        
       
    }

    private Vector3 UpTwoDimensionalMovement() {
        Vector3 destination = followingObject.position + followingObject.up * 18 - followingObject.forward * 2;
        return SmoothVector(destination, 0.1f);
    }

    private void CameraLooksAt() {
        transform.LookAt(followingObject, followingObject.up);
    }

    private Vector3 SmoothVector(Vector3 destination, float smooth) {
        Vector3 smothDestination = Vector3.SmoothDamp(
            currentCameraPosition,
            destination,
            ref velocity,
            smooth);

        return smothDestination;
    }

    public void CameraControl(string mode) {
        if (mode == "2d")
        {
            cameraLogic = TwoDimensionalMovement;
            
        }
        if (mode == "3d")
        {
            cameraLogic = SmoothFollow;
            
        }

        if (mode == "2dUp") {
            cameraLogic = UpTwoDimensionalMovement;
        }
    }
}
