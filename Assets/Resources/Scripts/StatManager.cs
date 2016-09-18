using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatManager : MonoBehaviour {
    public Image[] populationStats;
    private float fillRate = 0.1f;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < populationStats.Length; i++)
        {
            populationStats[i].fillAmount -= fillRate * Time.deltaTime;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Image statImage;
        for (int i = 0; i < populationStats.Length; i++)
        {
            statImage = populationStats[i];

            if (statImage.fillAmount <= 0f) statImage.fillAmount = 1f;

            statImage.fillAmount -= fillRate * Time.deltaTime;
            
            if (statImage.GetComponentInChildren<Text>()) statImage.GetComponentInChildren<Text>().text = (Mathf.RoundToInt( Mathf.Clamp01(populationStats[i].fillAmount) * 100)).ToString();

        }
    }
}
