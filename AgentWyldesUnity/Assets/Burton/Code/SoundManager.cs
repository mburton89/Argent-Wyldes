using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource buttonClick;

    private void Awake()
    {
        Instance = this;
    }
}
