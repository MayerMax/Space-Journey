using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {

    // как сильно занизить время
    public float slowDownFactor = 0.05f;
    // продолжительность
    public float slowDownLength = 4f;

   public void SlowMotion() {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; 
    }
	
	
	// Update is called once per frame
	void Update () {
        Time.timeScale += (1f / slowDownLength ) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1f);
		
	}
}
