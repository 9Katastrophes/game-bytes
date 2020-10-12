using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockScript : MonoBehaviour
{
    private bool playerControlled;

    // Start is called before the first frame update
    void Start()
    {
        playerControlled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isPlayerControlled()
    {
        return playerControlled;
    }

    public void setPlayerControlled(bool b)
    {
        playerControlled = b;
    }
}
