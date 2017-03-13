using UnityEngine;
using Assets.Scripts.Cameras;

public class GameControll : MonoBehaviour
{


    [SerializeField]
    MovementAdapter controller;

    private ICamera curCam;

    [SerializeField]
    Main3dCameraAlternative camera;


    [SerializeField]
    Plane spaceShip;



    
    void Update()
    {
        PlaneMovement();
        ConfigureControl();


    }

    private void PlaneMovement()
    {
        spaceShip.ActivateEngine(controller.IsInMove);
    }

    public void ConfigureControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.ConfigureControl("2d");
            camera.CameraControl("2d");
            
        }
         if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            controller.ConfigureControl("3d");
            camera.CameraControl("3d");
        }

        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            controller.ConfigureControl("2dUp");
            camera.CameraControl("2dUp");
        }


    }
}

