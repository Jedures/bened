using Invector.CharacterController;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float MinDamage = 10f;
    public float MaxDamage = 40f;

    private bool doDamage = false;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter - " + other.collider.tag);

        if (doDamage == true)
            return;

        if (other.collider.tag == "Player")
        {
            other.collider.GetComponent<vThirdPersonController>().DoDamage(Random.Range(MinDamage, MaxDamage));

            doDamage = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (doDamage == false)
            return;

        if (other.collider.tag == "Player")
        {
            doDamage = false;
        }
    }
}
