using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Buttons : MonoBehaviour {

    Vector3 bTarget;
    float v = 0f;
    public GameObject textObj;
    Text text;

    List<string> labels = new List<string>(new string[] {
        "Forced Sterilization",
        "Distribute Unpure Water",
        "Execution of Newborns",
        "Encourage Labor",
        "Encourage Education",
        "Public Housing Investment",
        "1-Child Rule",
        "Reserve Meds for Elderly",
        "Ban Motor Vehicles",
        "Instate Curfew",
        "Ban Pets",
        "Free Birth Control",
        "Free Abortions",
        "Limit Property Ownership"});

	// Use this for initialization
	void Start () {
        text = textObj.GetComponent<Text>();
        bTarget = new Vector3(-12, 25, 0);
    }

    public void move() {
        StartCoroutine("swap");
    }

    public IEnumerator swap() {
        text.text = labels[Random.Range(0, labels.Count - 1)];
        int x = 0;
        while (x < 2) {
            active = !active;
            yield return new WaitForSeconds(5);
            x++;
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
