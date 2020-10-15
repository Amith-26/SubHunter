using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private int seaMine = 0;
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public void MineCounter()
    {
        seaMine++;
    }
    public void DecrementMine()
    {
        seaMine--;
        player.SeaMineLeft(1);
    }
}
