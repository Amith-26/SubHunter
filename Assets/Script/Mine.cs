using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class Mine : MonoBehaviour
{
    private SeaMine mines;
    private void Start()
    {
        mines = FindObjectOfType<SeaMine>();
        mines.MineCounter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Submarine"))
        {
            mines.DecrementMine();
        }
    }
    private void Update()
    {
        transform.Rotate(0f, 0f, 25f * Time.deltaTime);
    }
}
