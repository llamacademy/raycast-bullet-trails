using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private Gun Gun;
    [SerializeField]
    private InputActionAsset InputActions;

    // If you want to always fire like in the video, this is what I did. 
    // For more robust holding you can consider attaching the OnShoot via code and handling if the button is pressed
    // This gist: https://gist.github.com/Invertex/db99b1b16ca53805ae02697b1a51ea77
    // and forum thread may be helpful to achieving that: https://forum.unity.com/threads/new-input-system-how-to-use-the-hold-interaction.605587/page-4#post-7314433
    //private void Update()
    //{
    //    Gun.Shoot();
    //}

    private void OnEnable()
    {
        foreach (InputAction action in InputActions.actionMaps[0].actions)
        {
            if (action.name.Equals("Shoot"))
            {
                action.performed += HandleShoot;
            }
        }
    }

    private void OnDisable()
    {
        foreach (InputAction action in InputActions.actionMaps[0].actions)
        {
            if (action.name.Equals("Shoot"))
            {
                action.performed -= HandleShoot;
            }
        }
    }

    private void HandleShoot(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Gun.Shoot();
        }
    }

    public void OnShoot()
    {
        Gun.Shoot();
    }
}
