using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] skills;
    public GameObject populationController;
    PopulationManager populationManager;
    public int tickrate = 1;

    float v = 0f;
    bool buttonsActive = false;

    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        populationManager = populationController.GetComponent<PopulationManager>();
        StartCoroutine("Tick");
        GenerateButtons();
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator GenerateButtons() {
        Debug.Log("generating buttons");
        if (buttonsActive) {
            foreach (GameObject button in buttons) {
                float newPos = Mathf.SmoothDamp(button.transform.position.y, button.transform.position.y - 50, ref v, .2f);
                button.transform.position = new Vector3(button.transform.position.x, newPos, button.transform.position.z);
            }
            foreach (GameObject button in buttons) {
                float newPos = Mathf.SmoothDamp(button.transform.position.y, button.transform.position.y + 50, ref v, .2f);
                button.transform.position = new Vector3(button.transform.position.x, newPos, button.transform.position.z);
            }
        }
        else {
            foreach (GameObject button in buttons) {
                float newPos = Mathf.SmoothDamp(button.transform.position.y, button.transform.position.y + 50, ref v, .2f);
                button.transform.position = new Vector3(button.transform.position.x, newPos, button.transform.position.z);
            }
        }
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
