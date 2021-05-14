using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBlocks : MonoBehaviour
{
    [SerializeField]
    private GameObject startPos;
    [SerializeField]
    private GameObject jengaBlock;

    public float zoffset, yoffset, xoffset;
    private float xgap , zgap, ygap;
    private Vector3 spawnPoint ;
    private bool firstBlock = true;
    // Start is called before the first frame update

   
    void Start()
    {

        zgap = (jengaBlock.transform.lossyScale.z / 2) + zoffset;
        ygap = (jengaBlock.transform.lossyScale.y) + yoffset;
        xgap = (jengaBlock.transform.lossyScale.z / 2) + xoffset;
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

    private void facingXblocks()
    {
       
       firstBlock = true;
       for(int i = 1; i<= 3; i++)
        {
            float zgapp = firstBlock ? 0 : zgap;
            GameObject tempBlockX = Instantiate(jengaBlock, spawnPoint - new Vector3(0, 0, zgapp), Quaternion.identity);
            //tempBlockX.transform.SetParent(startPos.transform);
            zgap *= -1;
            firstBlock = false;
        }
        spawnPoint += new Vector3(0, ygap , 0);
    }  

    private void facingZblocks()
    {
        firstBlock = true;
        for (int j = 1; j <= 3; j++)
        {
            float xgapp = firstBlock ? 0 : xgap;
            GameObject tempBlockZ = Instantiate(jengaBlock, spawnPoint - new Vector3(xgapp, 0, 0), Quaternion.Euler(0,90,0));
            //tempBlockZ.transform.SetParent(startPos.transform);
            xgap *= -1;
            firstBlock = false;
        }
        spawnPoint += new Vector3(0, ygap , 0);
    }
}
