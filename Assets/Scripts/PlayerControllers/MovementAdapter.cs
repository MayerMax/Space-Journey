using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerControllers;

public class MovementAdapter : MonoBehaviour {

    [SerializeField]
    Transform FollowingObject;

    [SerializeField]
    BaseMovementController currentControl;

    public BaseMovementController CurrentControl {
        get { return currentControl; }

        set { currentControl = value; }
    }

    public bool IsInMove {
        get { return currentControl.IsActive; }
    }

    void Awake() {
        CurrentControl = new PlayerMovement(FollowingObject); 
    }
	
	// Update is called once per frame
	void Update () {
        CurrentControl.Move();
    }

    // Метод будет принимать параметр от GameManager, когда тот будет внедрен. 
    public void ConfigureControl(string mode) {
        if (mode.Equals("2d"))
                CurrentControl = new MoveUpOnly(FollowingObject);
                
        if (mode.Equals("3d")) 
            CurrentControl = new PlayerMovement(FollowingObject);
        

        if (mode.Equals("2dUp"))
            CurrentControl = new UpwardMovement(FollowingObject);
    }
}
