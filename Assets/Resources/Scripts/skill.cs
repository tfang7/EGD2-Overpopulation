using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
public class skill : MonoBehaviour {
    public WorkerController worker;
    public Image image;
    public bool employmentBool;
    public PopulationManager popManager;

    private float sanitationPercentage;
    // Use this for initialization
    void Start () {
        image.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (name.Contains("Employment"))
        {
            image.fillAmount = popManager.workPopulation / popManager.totalPopulation * 1.0f;
        }
        else if (name.Contains("Sanitation")) {
            List<GameObject> stats = GameObject.FindGameObjectsWithTag("populationStat").ToList();
            sanitationPercentage = 0.0f;
            stats.ForEach(calculateSanitation);
            image.fillAmount = sanitationPercentage / (stats.Count);

        }
        else
        {
            image.fillAmount = worker.populationPercentage / 100.0f;
        }
        //   Debug.Log(worker.populationPercentage/100.0f);
    }
    void calculateSanitation(GameObject go)
    {
        if (go.name == "statSan") return;
        float fillAmount = go.GetComponent<Image>().fillAmount * 1.0f;
        //double fill amount of sanitation stat if water progress is high
        if (go.name == "statWat") fillAmount *= 2.0f;

        sanitationPercentage += fillAmount;

        Debug.Log(sanitationPercentage/5.0f);

    }
}
