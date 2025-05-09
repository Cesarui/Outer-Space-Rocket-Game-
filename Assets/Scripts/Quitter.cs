using UnityEngine;
using UnityEngine.InputSystem;

public class Quitter : MonoBehaviour
{
    void Update()
    {
        // Quits the game

        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}
