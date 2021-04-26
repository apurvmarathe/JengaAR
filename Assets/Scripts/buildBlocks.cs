using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBlocks : MonoBehaviour
{
    [SerializeField]
    private GameObject startPos;
    [SerializeField]
    private GameObject jengaBlock;

    private float xgap = 0.21f , zgap = 0.21f;
    private Vector3 spawnPoint ;
    private bool firstBlock = true;
    // Start is called before the first frame update

   
    void Start()
    {
        spawnPoint = startPos.transform.position;
        for(int loop=1;loop<=18;loop++)
        {
            if(loop % 2 == 0)
            {
                facingZblocks();
            }
            else
            {
                facingXblocks();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void facingXblocks()
    {
       
       firstBlock = true;
       for(int i = 1; i<= 3; i++)
        {
            float zgapp = firstBlock ? 0 : zgap;
            GameObject tempBlockX = Instantiate(jengaBlock, spawnPoint - new Vector3(0, 0, zgapp), Quaternion.identity);
            tempBlockX.transform.SetParent(startPos.transform);
            zgap *= -1;
            firstBlock = false;
        }
        spawnPoint += new Vector3(0, 0.2f, 0);
    }  

    private void facingZblocks()
    {
        firstBlock = true;
        for (int j = 1; j <= 3; j++)
        {
            float xgapp = firstBlock ? 0 : xgap;
            GameObject tempBlockZ = Instantiate(jengaBlock, spawnPoint - new Vector3(xgapp, 0, 0), Quaternion.Euler(0,90,0));
            tempBlockZ.transform.SetParent(startPos.transform);
            xgap *= -1;
            firstBlock = false;
        }
        spawnPoint += new Vector3(0, 0.2f, 0);
    }
}
