using UnityEngine;
using UnityEngine.Events;

public class triggerevents : MonoBehaviour
{

    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enteredTrigger.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enteredTrigger.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enteredTrigger.Invoke();
        }
    }
}
