using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject redCube;
    public GameObject endCube;
    private int newId = 0;
    
    public Dictionary<int, GameObject> listCube = new Dictionary<int, GameObject>();
    public TypeCube[,,] grid;
    public enum TypeCube{
        nul,
        redCube,
        endCube
       
    }
    /*
    [System.Serializable]
    public class Cell
    {
        public GameObject view;
        public GameObject type;
    }*/

   // List<List<List<Cell>>> list;
   // private Cell[,,] grid;

   /* public struct Cell
    {
        public GameObject view;
        public TypeCube type;

        public Cell(GameObject view , TypeCube type)
        {
            this.view = view;
            this.type = type;
        }
    }
   */
   
    void Start()
    {
        CreateGrid();
      //  SpawnStart();
    }

    private void CreateGrid()
    {

        if (App.Level == 0)
        {
            grid = new TypeCube[5,1,1];
            grid[0, 0, 0] = TypeCube.redCube;
            grid[4, 0, 0] = TypeCube.endCube;
        }


        //    Debug.Log("grid.Length " + grid.Length);
        for (var x = 0; x < grid.GetLongLength(0); x++)
            for (var y = 0; y < grid.GetLongLength(1); y++)
                for (var z = 0; z < grid.GetLongLength(2); z++)
                {
                    if(grid[x, y, z]!=TypeCube.nul)
                        SpawnCube(x, y, z, grid[x, y, z]);
                }
        //  Debug.Log("grid "+x+"  "+ grid[x,0,0]);
        //  SpawnCube(sx,sy,sz, TypeCube.redCube);
        //    SpawnCube(fx,fy,fz, TypeCube.endCube);
        /*List<List<object>> list = new List<List<object>>(); //инициализация
        list.Add(new List<object>());//добавление новой строки
        list[0].Add("asd")//добавление столбца в новую строку
        list[0][0];//обращение к первому столбцу первой строки*/



        //  for (int y = 0; y < 3; y++)
        //      Debug.Log("Grid "+grid[0, y].x);
        //  generationGrid();
        checkArrow();
    }

    private void checkArrow()
    {
           var  mX = grid.GetLongLength(0);
           var  mY = grid.GetLongLength(1);
           var  mZ = grid.GetLongLength(2);
        /**   for (var x = 0; x < mX; x++)
             for (var y = 0; y < mY; y++)
                 for (var z = 0; z < mZ; z++)
                 {
                     if (grid[x, y, z] != TypeCube.nul)
                     {
                        // logika 
                     }
                 }   
     */
        for (int x = 0; x < listCube.Count; x++)
        {
            CubeApp cb = listCube[x].GetComponent<CubeApp>();
            int[] a = new int [6];
            int i = 0;
            if (cb.type > 0)
            {
                long _x = (long)(cb.pX + 1);
                long _y = 0;
                long _z = 0;
                if (cb.pX<mX-1 &&  (grid[_x,_y,_z] == TypeCube.nul))
                {
                    a[i] = 0;
                    //logika
                }
              // cb.showArrow(a);
            }

         //   Debug.Log(" =  " + x + "  " + listCube[x]);
        }
    }

    private bool isStart = true;
         
    private void SpawnCube(float sx, float sy, float sz, TypeCube tp)
    {
        GameObject go;
        int freeArrow = 0;
        switch (tp)
        {
            case TypeCube.redCube: go = Instantiate(redCube, new Vector3(0, 0, 0), Quaternion.identity); freeArrow = 2; break;
            case TypeCube.endCube: go = Instantiate(endCube, new Vector3(0, 0, 0), Quaternion.identity);  break;

           default:
                go = Instantiate(redCube, new Vector3(0, 0, 0), Quaternion.identity); freeArrow = 20; break;
        }

        CubeApp ca = go.GetComponent<CubeApp>();
        if (go) { 
            ca.pX = sx;
            ca.pY = sy;
            ca.pZ = sz;
            ca.id = newId;
            if (isStart && freeArrow>0)
            {
                freeArrow --;
                isStart = false;
            }

            ca.type = freeArrow;

          }
        
        go.transform.Rotate(0f, 0f, 0f);
        go.transform.SetParent(App.map.transform);
        go.transform.position = new Vector3(sx,sy,sz);
        go.transform.rotation = App.map.transform.rotation;
        listCube.Add(newId, go);
        newId++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
