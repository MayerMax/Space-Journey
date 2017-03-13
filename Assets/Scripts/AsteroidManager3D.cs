using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager3D : MonoBehaviour {

    [SerializeField]
    Asteroid asteroid;

    [SerializeField]
    int numberOfAsteroids;

    [SerializeField]
    int distanceBetweenAsteroids;

	// Use this for initialization
	void Start () {
        PlaceAsteroids();
	}

    void PlaceAsteroids() {
        for (int x = 0; x < numberOfAsteroids; x++) {
            for (int y = 0; y < numberOfAsteroids; y++) {
                for (int z = 0; z < numberOfAsteroids; z++) {
                    InstantiateAsteroid(x, y, z);
                }
            } 
        }   
    }

    private void InstantiateAsteroid(float x, float y, float z) {
        Vector3 offset = PositionWithNoise(
            transform.position + new Vector3(x, y, z) * distanceBetweenAsteroids);

        Instantiate(asteroid, offset, Quaternion.identity, transform);
    }

    private Vector3 PositionWithNoise(Vector3 position) {
        var halfDistance = distanceBetweenAsteroids /2;

        position.x -= Random.Range(halfDistance * -1, halfDistance);
        position.y -= Random.Range(halfDistance * -1, halfDistance);
        position.z -= Random.Range(halfDistance * -1, halfDistance);

        return position;
    }
}
