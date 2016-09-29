using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class JobManager : MonoBehaviour
{
    public float SimulTime { private set; get; }
    [SerializeField]
    private Text textTime;
    [SerializeField]
    private GameObject jobObject;
    private Job actualJob;
    private List<GameObject> jobList;
    [SerializeField]
    private Sprite[] jobSprites;

    // Use this for initialization
    void Start()
    {
        SimulTime = 0f;
        jobList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        // Atualizar o tempo de simulação
        SimulTime += Time.deltaTime;

        // Verificar os jobs
        if (jobList.Count > 0)
        {
            if (actualJob == null)
            {
                actualJob = jobList[0].GetComponent<Job>();
            }

            ProcessActualJob();
        }

        AtualizarHUD();
    }

    void AtualizarHUD()
    {
        textTime.text = ((int)SimulTime).ToString();
    }

    void ProcessActualJob()
    {
        actualJob.ProcessJob();
        if (actualJob.IsComplete)
        {
            jobList.RemoveAt(0);
            Destroy(actualJob.gameObject);
        }
    }

    // Adicionar um novo job na lista / fila
    public void AddJob()
    {
        int jobType = Random.Range(0, 3);
        GameObject job = Instantiate(jobObject);
        job.GetComponent<Job>().jobSprite = jobSprites[jobType];
        job.transform.SetParent(transform.FindChild("JobPanel"));
        jobList.Add(job);
    }
}
