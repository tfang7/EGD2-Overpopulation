using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] skills;
    public GameObject populationController;
    PopulationManager populationManager;
    public int tickrate = 1;
    Vector3 bTarget;

    float v = 0f;
    bool buttonsActive = false;

    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        bTarget = new Vector3(-12, -230, 0);
        populationManager = populationController.GetComponent<PopulationManager>();
        StartCoroutine("Tick");
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator GenerateButtons() {
        Debug.Log("generating buttons");
        while (buttons[0].transform.position.y != bTarget.y) {
            if (buttonsActive) {
                foreach (GameObject button in buttons) {
                    button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - 50, 0);
                    float newPos = Mathf.SmoothDamp(button.transform.position.y, bTarget.y, ref v, .2f);
                    button.transform.position = new Vector3(button.transform.position.x, newPos, button.transform.position.z);
                }
            }
            else {
                foreach (GameObject button in buttons) {
                    float newPos = Mathf.SmoothDamp(button.transform.position.y, bTarget.y - 50, ref v, .2f);
                    button.transform.position = new Vector3(button.transform.position.x, newPos, button.transform.position.z);
                }
            }
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Tick() {
        int ticker = 0;
        while (true) {
            ticker++; 
            Debug.Log("tick");
            TickSkills();
            populationManager.Tick();
            yield return new WaitForSeconds(tickrate);
        }
    }

    void TickSkills() {
        foreach (GameObject s in skills) {
            Debug.Log(s);
            skill sk = s.GetComponent<skill>();
            if (sk != null)
                sk.Tick();
        }
    }
}
