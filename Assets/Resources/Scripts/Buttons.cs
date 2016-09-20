using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

    Vector3 bTarget;
    float v = 0f;

	// Use this for initialization
	void Start () {
        bTarget = new Vector3(-12, 25, 0);
    }

    public void move() {
        StartCoroutine("swap");
    }

    public IEnumerator swap() {
        int x = 0;
        while (x < 2) {
            active = !active;
            yield return new WaitForSeconds(5);
        }
    }

    public bool active = false;
	
	// Update is called once per frame
	void Update () {
        if (active) { 
            float newPos = Mathf.SmoothDamp(transform.position.y, bTarget.y, ref v, .2f);
            transform.position = new Vector3(transform.position.x, newPos, 0);
        }
        else {
            float newPos = Mathf.SmoothDamp(transform.position.y, bTarget.y - 50, ref v, .2f);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
        }
    }
}
