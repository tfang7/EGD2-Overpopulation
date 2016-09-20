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
        populationManager = populationController.GetComponent<PopulationManager>();
        StartCoroutine("Tick");
    }

    // Update is called once per frame
    void Update () {
	
	}

    void MoveButtons() {
        foreach(GameObject button in buttons) {
            button.GetComponent<Buttons>().move();
        }
    }

    IEnumerator Tick() {
        int ticker = 0;
        while (true) {
            ticker++; 
            Debug.Log("tick");
            if (ticker == 2) {
                MoveButtons();
            }
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
