using UnityEngine;

using static OVRInput;

public class Newscript : MonoBehaviour
{
    [SerializeField] private bool pressARaw;
    [SerializeField] private bool pressBRaw;
    [SerializeField] private bool pressXRaw;
    [SerializeField] private bool pressYRaw;
    [SerializeField] private Controller controller;
    [SerializeField] private Animator Animation_Dog;

    private Controller activeController = Controller.None; // Currently active controller
    private int animationValue = 0; // Stores the current animation value
    private bool Sit_b = false;
    void Start()
    {
        activeController = Controller.None;
    }

    void Update()
    {   
        Animation_Dog.SetBool("AttackReady_b", false); // Set the boolean parameter "AttackReady_b" to false

        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            Animation_Dog.SetBool("Sleep_b", false);
            animationValue = 2;

        }
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
          Animation_Dog.SetBool("Sleep_b", false);
          animationValue = 10;
        }
        if (OVRInput.Get(OVRInput.RawButton.X))
        {
            Animation_Dog.SetBool("Sleep_b", false);
            Animation_Dog.SetBool("AttackReady_b", true); // Set the boolean parameter "AttackReady_b" to true
        }
        if (OVRInput.Get(OVRInput.RawButton.Y))
        {
            Animation_Dog.SetBool("Sleep_b", false);
            animationValue = 1;
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0.0f)
        {
            Animation_Dog.SetBool("Sleep_b", false);
            if(Sit_b)
            {
                Animation_Dog.SetBool("Sit_b", false);
                Sit_b = false;
            }
            else
            {
                Animation_Dog.SetBool("Sit_b", true);
                Sit_b = true;
            }
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.0f)
        {
            Animation_Dog.SetBool("Sleep_b", true);
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.0f)
        {
            Animation_Dog.SetBool("Sleep_b", false);
            Animation_Dog.SetBool("Jump_tr", true);
        }



    
        pressARaw = OVRInput.Get(OVRInput.RawButton.A);
        pressBRaw = OVRInput.Get(OVRInput.RawButton.B);
        pressXRaw = OVRInput.Get(OVRInput.RawButton.X);
        pressYRaw = OVRInput.Get(OVRInput.RawButton.Y);
    
        // Set the animation parameter
        Animation_Dog.SetInteger("ActionType_int", animationValue);
        
        float animationTime = Animation_Dog.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animationTime >= 0.9f && animationValue != 0)
        {
            animationValue = 0;
        }
    }

    
}

