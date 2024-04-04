using UnityEngine;

using static OVRInput;

public class Newscript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private bool pressARaw;
    [SerializeField] private bool pressBRaw;
    [SerializeField] private bool pressXRaw;
    [SerializeField] private bool pressYRaw;
    [SerializeField] private Controller controller;
    [SerializeField] private Animator Animation_Dog;

    private Controller activeController = Controller.None; // Currently active controller
    private int animationValue = 0; // Stores the current animation value

    void Start()
    {
        activeController = Controller.None;
    }

    void Update()
    {

        if (OVRInput.Get(OVRInput.RawButton.A))
            animationValue = 1;
        if (OVRInput.Get(OVRInput.RawButton.B))
            animationValue = 2;
        if (OVRInput.Get(OVRInput.RawButton.X))
            animationValue = 3;
        if (OVRInput.Get(OVRInput.RawButton.Y))
            animationValue = 4;
        
        pressARaw = OVRInput.Get(OVRInput.RawButton.A);
        pressBRaw = OVRInput.Get(OVRInput.RawButton.B);
        pressXRaw = OVRInput.Get(OVRInput.RawButton.X);
        pressYRaw = OVRInput.Get(OVRInput.RawButton.Y);

        // Set the animation parameter
        Animation_Dog.SetInteger("ActionType_int", animationValue);
    }
}

