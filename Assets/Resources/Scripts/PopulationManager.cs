using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulationManager : MonoBehaviour {


    private Text populationText;
    private Text deathRateText;
    private Text birthRateText;
    private Text growthRateText;

    public float birthRate;
    public float deathRate;
    public float growthRate;

    public float totalPopulation;
    public float workPopulation;
    public float unemployedPopulation;

    public GameObject growthR;
    public GameObject deathR;
    public GameObject populationR;
    public GameObject birthR;
    public Slider[] sliders;
	// Use this for initialization
	void Awake () {
        totalPopulation = 100;
        birthRate = 100;
        deathRate = 0;
        growthRate = 0f;
        populationText = populationR.GetComponent<Text>();
        deathRateText = deathR.GetComponent<Text>();
        birthRateText = birthR.GetComponent<Text>();
        growthRateText = growthR.GetComponent<Text>();

    }
    // Update is called once per frame
    public void Tick() {
       // birthRate = adjustRate(birthRate, Random.Range(1, 100) * 1 / 3);
        deathRate += 10;
        calculateGrowthRate();
        totalPopulation += (int) Mathf.Ceil(growthRate * Time.deltaTime);
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
        float difference = birthRate - deathRate;
        growthRate = (workPopulation / totalPopulation) * Mathf.Exp(0.01f);
        birthRate = Mathf.Ceil(growthRate);
        growthRateText.color = Color.red;
        if (growthRate > 0)
        {
            growthRateText.color = Color.green;
        }
        growthRateText.text = "Growth Rate: " + growthRate.ToString();
    }
    void calculateDeathRate()
    {

    }
    public float calculateTotalWorkers()
    {
        workPopulation = 0;
        for (int i = 0; i < sliders.Length; i++)
        {
            workPopulation += sliders[i].value;
        }
        unemployedPopulation = (totalPopulation - workPopulation);
        return unemployedPopulation;
    }

}
