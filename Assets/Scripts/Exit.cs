using UnityEngine;

public class Exit : MonoBehaviour
{

    private void Start()
    {
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
    }

    public void exit ()
    {
        Application.Quit();
    }
}
