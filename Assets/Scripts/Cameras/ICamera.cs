using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public interface ICamera
    {
        Transform followingObject { get; }

        Vector3 currentCameraPosition { get;}

        Quaternion currentRotation { get; }
    }
}
