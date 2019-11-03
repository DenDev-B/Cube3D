using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeApp : MonoBehaviour
{
    public GameObject View;
    public List<GameObject> arrows;
    public Vector3 pos=Vector3.zero;
    public int Arrow=0;
    public bool isCreate = false;
    public float pX;
    public float pY;
    public float pZ;
    public int id;
    public int ftreeArrow;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        clearArrow();

        int[] a = {0,0,0,0, 0, 0 };
        showArrow(a);

        
    }

    private void clearArrow()
    {
        for (int a = 0; a < arrows.Count; a++)
        {
            arrows[a].SetActive(false);
        }
    }

    public void showArrow(int [] ar )
    {
        if (arrows.Count == 0) return;
           for(int a = 0; a < ar.Length; a++)
           {
               if(ar[a]>=0)
                  arrows[ar[a]].SetActive(true);
           }
      //  arrows[ar[0]].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
