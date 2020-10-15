using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] wavePoints = null;
    public int submarine = 0;
    public int Wave = 1;
    public GameObject submarinePrefab;
    public float delay = 7f;
    private int currentWavePoint;
    public Text subsLeft;
    public Text subs;
    private SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_SubmarineSpawn());
        subsLeft.text = "WAVE " + Wave;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    IEnumerator _SubmarineSpawn()
    {
            for (int i = 1; i <= Wave; i++)
            {
                SubmarineSpawn();
                yield return new WaitForSeconds(delay);
            }
    }
    private void SubmarineSpawn()
    {
        currentWavePoint = (int)Random.Range(0, wavePoints.Length);
        GameObject submarine = Instantiate(submarinePrefab, wavePoints[currentWavePoint].position, Quaternion.identity);
    }
    public void SubmarineCounter()
    {
        submarine++;
        subs.text = "SUBS " + submarine;
    }
    public void SubmarineDecrement()
    {
        submarine--;
        subs.text = "SUBS " + submarine;
        if (submarine <= 0 && Wave <= 10)
        {
            Wave++;
            MissionCompleted();
            subsLeft.text = "WAVE " + Wave;
            StartCoroutine(_SubmarineSpawn());
        }
    }
    public void MissionCompleted()
    {
        if (Wave > 10)
        {
            sceneLoader.WinScene();
        }
    }
    
}
