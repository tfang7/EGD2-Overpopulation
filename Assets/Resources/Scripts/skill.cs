using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class skill : MonoBehaviour {
    public WorkerController worker;
    public Image image;
    // Use this for initialization
    void Start () {
      //  Debug.Log(image.fillAmount);
        image.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = worker.populationPercentage / 100.0f;
     //   Debug.Log(worker.populationPercentage/100.0f);
    }
}
