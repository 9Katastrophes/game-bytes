using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solemates_GameManager : MonoBehaviour
{
    // Singleton Definition
    public static Solemates_GameManager S;

    // Game Objects
    public GameObject sockPrefab;

    // Game Variables
    public int numSocks;
    public Sprite[] sockPatterns;

    public int verticalOffset;
    public int horizontalOffset;

    private GameObject p1Sock;
    private GameObject p2Sock;

    private void Awake()
    {
        // Check for the singleton - does it exist already?
        if (Solemates_GameManager.S)
        {
            // There is already a game manager
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
    }

    void Start()
    {
        numSocks = 2 * sockPatterns.Length;

        // Create our socks
        for (int i = 0; i < numSocks; i++)
        {
            int patternNumber = i % sockPatterns.Length;
            makeSock(patternNumber);
        }

        // Initialize player socks
        p1Sock = transform.GetChild(0).gameObject;
        p2Sock = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        
    }

    private void makeSock(int patternNumber)
    {
        int xPos = Random.Range(-horizontalOffset, horizontalOffset);
        int yPos = Random.Range(-verticalOffset, verticalOffset);

        GameObject sock = Instantiate(sockPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity, this.transform);
        sock.GetComponent<SpriteRenderer>().sprite = sockPatterns[patternNumber];
    }

    public void getRandomSock(int player)
    {
        bool sockFound = false;
        GameObject newSock = null;

        while (!sockFound)
        {
            int newSockNumber = Random.Range(0, transform.childCount);
            newSock = transform.GetChild(newSockNumber).gameObject;

            if (!(newSock.Equals(p1Sock)) && !(newSock.Equals(p2Sock)))
            {
                sockFound = true;
            }
        }

        if (player == 1)
        {
            p1Sock.GetComponent<SockScript>().setPlayerControlled(false);
            p1Sock.GetComponent<SockScript>().setPlayerControlled(true);
            p1Sock = newSock;
        }
        else if (player == 2)
        {
            p2Sock.GetComponent<SockScript>().setPlayerControlled(false);
            p2Sock.GetComponent<SockScript>().setPlayerControlled(true);
            p2Sock = newSock;
        }
    }

    private void killAllSocks()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private bool doSocksMatch(GameObject sock1, GameObject sock2)
    {
        if (sock1.GetComponent<SpriteRenderer>().sprite.Equals(sock2.GetComponent<SpriteRenderer>().sprite))
        {
            return true;
        }
        return false;
    }

    public void attemptMatch()
    {
        // TODO: figure out how to get all gameobjects that are colliding with player gameobject and check for match
    }
}
