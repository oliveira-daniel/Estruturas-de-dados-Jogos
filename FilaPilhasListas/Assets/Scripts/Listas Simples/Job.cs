using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Job : MonoBehaviour
{
    [SerializeField]
    private Image remainingTime, timeCounter;
    private Image jobIcon;
    public Sprite jobSprite;

    public bool IsComplete
    {
        get
        {
            return remainingTime.fillAmount <= 0;
        }
    }

    // Use this for initialization
    void Start()
    {
        timeCounter.gameObject.SetActive(false);
        remainingTime.fillAmount = 1f;
        jobIcon = transform.FindChild("JobIcon").GetComponent<Image>();
        jobIcon.sprite = jobSprite;
    }

    public void ProcessJob()
    {
        if (!timeCounter.IsActive()) 
            timeCounter.gameObject.SetActive(true);
        // Decrescer o tempo de forma aleatória
        remainingTime.fillAmount -= Random.Range(0f, 0.005f);
    }

}
