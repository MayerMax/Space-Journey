using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    [SerializeField]
    TrailFume fume;

    [SerializeField]
    TimeControl timer;
    public void ActivateEngine(bool isActive = false) {
        FumesInteraction(isActive);
    }

    private void FumesInteraction(bool state) {
                   fume.Activate(state);
        
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Here!");
        if (col.collider.tag == "Asteroid")
            timer.SlowMotion();

    }

    
}
