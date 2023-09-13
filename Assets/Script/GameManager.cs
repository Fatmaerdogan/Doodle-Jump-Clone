using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action GameEndActive;
    public Action<int> Score;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

}
