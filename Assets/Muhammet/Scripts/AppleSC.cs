using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AppleSC : MonoBehaviour
{
    private XRGrabInteractable grab;

    public AppleSwing swing;
    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
    }


    // Update is called once per frame
    void Update()
    {
        if (grab.isSelected)
        {
            grab.forceGravityOnDetach = true;
            swing.isSwinged = true;
        }
        if (grab.isHovered && (!swing.isSwing || !swing.isSwinged))
        {
            swing.isSwing = true;
            Invoke("DropTheApple", 3f);
        }

    }

    public void DropTheApple()
    {
        Debug.Log("DropTheApple Worked");
        grab.forceGravityOnDetach = true;
        GetComponent<Rigidbody>().useGravity = true;
        swing.isSwinged = true;
    }
}
