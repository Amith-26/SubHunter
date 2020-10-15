using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    [SerializeField] private int points = 0;
    public AudioClip clip1;
    private AudioManger manger;
    private Score score;
    private void Start()
    {
        score = FindObjectOfType<Score>();
        manger = FindObjectOfType<AudioManger>();
    }
    private void Update()
    {
        transform.Rotate(0f, 0f, 25f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            score.MetalBoxScore(points);
            manger.PickUpSound();
            Destroy(this.gameObject);
        }
    }
}
