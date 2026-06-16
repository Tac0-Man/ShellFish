using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Image bar;
    private float counter;
    public float max = 5f;
    public bool started;
   
    void Start()
    {
        bar.fillAmount = 0f;
    }

   
    void Update()
    {
        if (started && counter <= max )
        {
            counter += Time.deltaTime;
            bar.fillAmount = counter/max; 
        }
    }

    public void Begin()
    {
        started = true;
    }

    public void End()
    {
        started = false;
        bar.fillAmount = 0f;
        counter = 0f;
    }


}
