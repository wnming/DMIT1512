using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PaddleBehaviour leftPaddle;
    [SerializeField] PaddleBehaviour rightPaddle;
    [SerializeField] PlungerScript plunger;
    [SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;
    [SerializeField] InputAction pullPlunger;
    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
        pullPlunger.Enable();
    }
    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
        pullPlunger.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }
    // Update is called once per frame
    void Update()
    {
        leftPaddle.Flip(useLeft.IsPressed());
        rightPaddle.Flip(useRight.IsPressed());
        plunger.Pull(pullPlunger.ReadValue<float>());
    }
}
