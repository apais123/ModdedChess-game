using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promotion : MonoBehaviour
{
    public GameObject controller;
    [SerializeField]
    public GameObject whitePromote;
    [SerializeField]
    public GameObject blackPromote;

    public void Activate(string player)
    {
        if (player == "white")
        {
            whitePromote.SetActive(true);
        }
    }
}
