using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
public class TrailFume : MonoBehaviour {

    TrailRenderer renderer;
    private Light lighter;

    void Awake() {
        renderer = GetComponent<TrailRenderer>();
        lighter = GetComponent<Light>();
    }

    public void Activate(bool active = true) {
        renderer.enabled = lighter.enabled = active;
    }

	void Start () {
        lighter.enabled = renderer.enabled = true;
	}
}
