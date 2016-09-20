using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkerController : MonoBehaviour {
    public float progress;
    public int currentWorkers;
    public int maxWorkers;
    public float[] currentRange;
    public Slider slider;
    public Image image;
    public PopulationManager popManager;
    public Text text;
    public int populationPercentage;
	// Use this for initialization
	void Start () {
        popManager = GameObject.Find("PopulationController").GetComponent<PopulationManager>();
	}
	
	// Update is called once per frame
	void Update () {
        updateSlider();

    }
    void convertRange(float originalStart, float originalEnd, float newStart, float newEnd,float value)
    {
        float originalRange = originalEnd - originalStart;
        float newRange = newEnd - newStart;
        float ratio = newRange / originalRange;
        float newValue = value * ratio;
        float resultValue = newValue + newStart;
        //todo: new image fill algorithm
        image.fillAmount = resultValue;
        //Debug.Log(resultValue);
    }
    public void updateSlider()
    {
        popManager.calculateTotalWorkers();
        float population = popManager.unemployedPopulation;
        float maxAllowed = slider.value + popManager.unemployedPopulation;

        slider.maxValue = maxAllowed;
        convertRange(slider.minValue, slider.maxValue, 0f, 1f, slider.value);
        populationPercentage = Mathf.RoundToInt((slider.value / popManager.totalPopulation) * 100.0f);
        text.text = Mathf.RoundToInt(slider.value).ToString();
    }
}
