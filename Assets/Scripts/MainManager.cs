using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private int level;

    private void Update()
    {
        level = (int)Time.time/4;
    }

    public int GetLevel()
    {
        return level;
    }
}
