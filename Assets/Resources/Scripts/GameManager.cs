using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] skills;
    public GameObject populationController;
    PopulationManager populationManager;
    public int tickrate = 1;

    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        populationManager = populationController.GetComponent<PopulationManager>();
        StartCoroutine("Tick");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Tick() {
        while (true) {
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
