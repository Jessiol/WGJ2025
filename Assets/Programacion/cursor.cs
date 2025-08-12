using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{

    public Texture2D cursor_activo;
    public Vector2 onbuttonhotspot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    public void botonactivado()
    {
        Cursor.SetCursor(cursor_activo, onbuttonhotspot, CursorMode.Auto);
    }

    public void btnfueraa()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
