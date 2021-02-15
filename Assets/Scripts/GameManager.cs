using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ResultController ResultController;
    public GameObject Player;
    public AmmoUI AmmoUI;

    private void Awake()
    {
        Instance = this;
    }

}
