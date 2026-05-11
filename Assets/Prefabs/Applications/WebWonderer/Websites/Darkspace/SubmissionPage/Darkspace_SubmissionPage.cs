using System;
using UnityEngine;

public class Darkspace_SubmissionPage : MonoBehaviour
{
    [SerializeField] private GameObject contentDescription;
    [SerializeField] private GameObject contentOverdue;

    private void Start()
    {
        contentDescription.SetActive(true);
        contentOverdue.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.game.GameTimer.TimePassed >= GameManager.game.GameTimer.WaitTime)
        {
            contentDescription.SetActive(false);
            contentOverdue.SetActive(true);
        }
    }
}
