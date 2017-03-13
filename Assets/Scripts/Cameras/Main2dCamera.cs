using UnityEngine;
using Assets.Scripts.Cameras;
using System;

public class Main2dCamera : MonoBehaviour, ICamera {

    private Vector3 offsetToMove = new Vector3(5,2,-1);
     
    private Transform target;

    public Vector3 currentCameraPosition
    {
        get { return transform.position; }

        private set { transform.position = value; }
    }

    public Quaternion currentRotation
    {
        get {return  transform.rotation; }

        private set { transform.rotation = value; }
    }

    public Transform followingObject
    {
        get {return target; }

        private set { target = value; }
    }

    public Main2dCamera(Transform followingObj) {
        followingObj = target;
    }

    // Use this for initialization
    void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {

        
    }

    void LateUpdate() {

        transform.LookAt(followingObject.transform);
        transform.position = followingObject.transform.position + new Vector3(8, 3, 0);
    }

    
}
