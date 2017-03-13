using UnityEngine;

public class Asteroid : MonoBehaviour {

    // Both fields for changing Asteroid size
    [SerializeField]
    float minBound;

    [SerializeField]
    float maxBound;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    GameObject explosion; 

    private Transform currentTransform;
    private Vector3 randomRotation;
    // always called before any Start functions, allows to order
    // initialization of scripts

    [SerializeField]
    private TimeControl timer;

    void Awake() {
        currentTransform = transform;
    }
    
    void Start () {
        currentTransform.localScale = RandomVector3Size();
        randomRotation = RandomVector3Rotation();
	}
	
	void Update () {
        currentTransform.Rotate(randomRotation * Time.deltaTime);	
	}

    private Vector3 RandomVector3Size() {
        return new Vector3(
            Random.Range(minBound, maxBound),
            Random.Range(minBound, maxBound),
            Random.Range(minBound, maxBound));
    }

    private Vector3 RandomVector3Rotation() {
        return new Vector3(
            Random.Range(min: -rotationSpeed, max: rotationSpeed),
            Random.Range(min: -rotationSpeed, max: rotationSpeed),
            Random.Range(min: -rotationSpeed, max: rotationSpeed));
    }

    public void OnCollisionEnter(Collision col) {
        foreach (ContactPoint point in col.contacts)
            InstatiateExplosion(point.point);
        
    }

    private void InstatiateExplosion(Vector3 pos) {
        GameObject expl = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(expl, 6f);
    }
}
