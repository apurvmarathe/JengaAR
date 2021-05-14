using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    public static GameObject currentGO ;
    // Start is called before the first frame update
   
    public static void CurrentGO(GameObject selectedBlock)
    {
        currentGO = selectedBlock;
    }
}
