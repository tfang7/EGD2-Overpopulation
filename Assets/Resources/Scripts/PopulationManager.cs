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
    public skill[] skills;
	// Use this for initialization
	void Awake () {
        totalPopulation = 100;
        birthRate = 3;
        deathRate = 1;
        growthRate = 0f;
        populationText = populationR.GetComponent<Text>();
        deathRateText = deathR.GetComponent<Text>();
        birthRateText = birthR.GetComponent<Text>();
        growthRateText = growthR.GetComponent<Text>();

    }
    // Update is called once per frame
    public void Tick() {
       // birthRate = adjustRate(birthRate, Random.Range(1, 100) * 1 / 3);
        calculateGrowthRate();
     //   totalPopulation -= deathRate;
        totalPopulation += (int) Mathf.Ceil(birthRate);
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
        birthRateText.text = birthRate.ToString();
        deathRateText.text = deathRate.ToString();
    }
    void calculateGrowthRate()
    {
        float difference = birthRate - deathRate;
        growthRate = difference;
       // birthRate = Mathf.Ceil(growthRate);
        growthRateText.color = Color.red;
        if (growthRate > 0)
        {
            growthRateText.color = Color.green;
        }
        growthRateText.text =  Mathf.Floor(growthRate).ToString();
    }
    void calculateDeathRate()
    {
        deathRate += Mathf.Floor(0.1f * Mathf.Exp(workPopulation / totalPopulation));
    }
    public float calculateTotalWorkers()
    {
        workPopulation = 0;
        for (int i = 0; i < sliders.Length; i++)
        {
            workPopulation += sliders[i].value;
        }
        unemployedPopulation = (totalPopulation - workPopulation);
        if (unemployedPopulation <= 0) unemployedPopulation = 0;
        float unemployedRatio = 1.0f - (workPopulation / totalPopulation);
      //  if (unemployedRatio <= 0f) deathRate = 0.0f;
        
        float employedRatio = (workPopulation / totalPopulation);
      //  if (employedRatio <= 0f) deathRate = 2.0f;

        //deathRate += Mathf.Floor(Mathf.Abs(employedRatio - unemployedRatio) * 1.05f) * (birthRate * 1.25f);
        birthRate += Mathf.Ceil(Mathf.Abs(employedRatio * Mathf.Exp(employedRatio * 0.01f)));
        float deathEquation = 1;
        if (deathEquation >= birthRate)
        {
            deathEquation = birthRate / 2;
        }
        Debug.Log(deathEquation);
        deathRate += deathEquation;
        return unemployedPopulation;
    }

    

}
