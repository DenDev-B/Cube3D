using UnityEngine;
using UnityEngine.UI;

public class Controll : MonoBehaviour
{
    public float sens;
    public Text ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

   private float dx = 0;
   private float dy = 0;
    void Update()
    {

#if UNITY_ANDROID

        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            // Пермещение одним касанием (move) 
            if (touches.Length == 1)
            {
                if (touches[0].phase == TouchPhase.Moved)
                {
                    Vector2 delta = touches[0].deltaPosition;
                 //   ui.text = "x " + delta.x;

                        transform.Rotate(0f, -delta.x * Time.deltaTime*sens, 0f);
                        transform.Rotate(delta.y * Time.deltaTime*sens,0f, 0f);
                }
            }
                  /*  float x1 = -Input.touches[0].deltaPosition.x;
                     float y1 = Input.touches[0].deltaPosition.y;
                   //  ui.text = "x " + x1+"  y"+y1;
                    if (  Input.touchCount ==1)
                    {
                           ui.text = "x " + x1 + "  y" + y1;
                           if (dx != Input.mousePosition.x)
                          {
                                if (dx - 100f > x1)
                                {
                                    dx = x1;
                                    transform.Rotate(0f, 10.0f, 0f);
                                }
                                if (dx + 100f < x1)
                                {
                                    dx = x1;
                                    transform.Rotate(0f, -10.0f, 0f);
                                }
                          }
                if (dy != y1)
                {
                    if (dy - 100f > y1)
                    {
                        dy = y1;
                        transform.Rotate(10.0f, 0f, 0f);
                    }
                    if (dy + 100f < y1)
                    {
                        dy = y1;
                        transform.Rotate(-10.0f, 0f, 0f);
                    }
                }
            }

    */
        }
 #endif
 #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            dx = Input.mousePosition.x;
            dy = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0))
        {
            if(dx != Input.mousePosition.x)
            {
                 if(dx-100f> Input.mousePosition.x)
                {
                    dx = Input.mousePosition.x;
                    transform.Rotate(0f, 10.0f, 0f);
                }
                if (dx + 100f < Input.mousePosition.x)
                {
                    dx = Input.mousePosition.x;
                    transform.Rotate(0f, -10.0f, 0f);
                }
            }
         
            if (dy != Input.mousePosition.y)
            {
                if (dy - 100f > Input.mousePosition.y)
                {
                    dy = Input.mousePosition.y;
                    transform.Rotate( 10.0f,0f, 0f);
                }
                if (dy + 100f < Input.mousePosition.y)
                {
                    dy = Input.mousePosition.y;
                    transform.Rotate(-10.0f,0f, 0f);
                }
            }
        }
#endif
    }

}
