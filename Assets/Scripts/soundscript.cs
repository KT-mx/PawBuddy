using UnityEngine;

using static OVRInput;

public class soundScript : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx1;

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
        {
            animationValue = 2;
        }
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            animationValue = 10;
        }
        if (OVRInput.Get(OVRInput.RawButton.X))
        {
            animationValue = 3;
        }
        if (OVRInput.Get(OVRInput.RawButton.Y))
        {
            animationValue = 1;
            src.clip = sfx1;
            src.Play();
        }
    
        pressARaw = OVRInput.Get(OVRInput.RawButton.A);
        pressBRaw = OVRInput.Get(OVRInput.RawButton.B);
        pressXRaw = OVRInput.Get(OVRInput.RawButton.X);
        pressYRaw = OVRInput.Get(OVRInput.RawButton.Y);
    
        // Set the animation parameter
        Animation_Dog.SetInteger("ActionType_int", animationValue);
        
        float animationTime = Animation_Dog.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animationTime >= 0.9f)
        {
            animationValue = 0;
        }
    }

    
}

