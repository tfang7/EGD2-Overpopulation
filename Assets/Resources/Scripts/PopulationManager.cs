using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulationManager : MonoBehaviour {


    private Text populationText;
    private Text deathRateText;
    private Text birthRateText;
    private Text growthRateText;

    public float  birthRate;
    public float deathRate;
    public float growthRate;

    public float totalPopulation;
    public float workPopulation;
    public float unemployedPopulation;

    public Slider[] sliders;
	// Use this for initialization
	void Start () {
        totalPopulation = 100;
        birthRate = 100;
        deathRate = 0;
        growthRate = 0f;
        populationText = GameObject.Find("populationCounter").GetComponent<Text>();
        deathRateText = GameObject.Find("deathRate").GetComponent<Text>();
        birthRateText = GameObject.Find("birthRate").GetComponent<Text>();
        growthRateText = GameObject.Find("growthRate").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        birthRate = adjustRate(birthRate, Random.Range(1,100) * 1/3);
        deathRate += 10;
        calculateGrowthRate();
        totalPopulation += (int)Mathf.Ceil(growthRate * Time.deltaTime);
        setText();
        calculateTotalWorkers();
    }
    void setPopulationText()
    {
            
    }
    float adjustRate(float rate, float change) {
        rate += change;
        return rate;
    }
    void setText()
    {
        populationText.text = totalPopulation.ToString();
        birthRateText.text = "Birth Rate:" + birthRate.ToString();
        deathRateText.text = "Death Rate:" + deathRate.ToString();
    }
    void calculateGrowthRate()
    {
        growthRate = birthRate - deathRate;
        growthRateText.color = Color.red;
        if (growthRate > 0)
        {
            growthRateText.color = Color.green;
        }
        growthRateText.text = "Growth Rate: " + growthRate.ToString();
    }
    public float calculateTotalWorkers()
    {
        workPopulation = 0;
        for (int i = 0; i < sliders.Length; i++)
        {
            workPopulation += sliders[i].value;
        }
        unemployedPopulation = (totalPopulation - workPopulation);
        Debug.Log(unemployedPopulation);
        return unemployedPopulation;
    }

}
