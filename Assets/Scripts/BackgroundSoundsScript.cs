using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundSoundsScript : MonoBehaviour
{
    [Header("Audio Sorce")]
    [SerializeField] AudioSource musicSorce;
    [SerializeField] AudioSource SFXSorce;

    [SerializeField]
    [Header("Audio Clip")]
    public AudioClip bakground;

    private void Start()
    {
        musicSorce.clip = bakground;
        musicSorce.Play();
    }
}