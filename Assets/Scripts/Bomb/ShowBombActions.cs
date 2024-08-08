
using UnityEngine;

public class ShowBombActions : MonoBehaviour
{
    private int checkHover;
    private GameObject redWire;
    public void HoverRed()
    {
        Debug.Log("Red wire has been hovered");
        checkHover = 1;
        checkHoverNumber(checkHover);
    }
    
    public void HoverBlue()
    {
        Debug.Log("Blue wire has been hovered");
        checkHover = 2;
        checkHoverNumber(checkHover);
    }
    
    public void HoverYellow()
    {
        Debug.Log("Yellow wire has been hovered");
        checkHover = 3;
        checkHoverNumber(checkHover);
    }

    private int checkHoverNumber(int chockHover)
    {
        Debug.Log("number thing:  " + checkHover);
        if (checkHover == 1)
        {
            // Perform actions
            var redRenderer = redWire.GetComponent<Renderer>();
            
        }
        
        if (checkHover == 2)
        {
            // Perform actions
        }
        
        if (checkHover == 2)
        {
            // Perform actions
        }
        return (checkHover);
    }
}
