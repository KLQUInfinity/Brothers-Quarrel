using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManger : UIManager
{
    #region Singleton
    public static LevelUIManger Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


}
