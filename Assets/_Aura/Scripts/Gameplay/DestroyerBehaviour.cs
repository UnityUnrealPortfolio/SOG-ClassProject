using UnityEngine;

/// <summary>
/// This class defines the behaviour of a gameobject that
/// destroys/turns off any other gameobject that enters it's collider
/// </summary>
public class DestroyerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the other game object tagged 'laser'? or is it 'asteroid'
        //deal with it accordingly

        if (collision.gameObject.tag == "laser")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "asteroid")
        {
            var refToBehaviour = collision.transform.parent.GetComponent<AsteroidTwoBehaviour>();
            if (refToBehaviour != null)
            {

                refToBehaviour.HandleDestruction();
            }
        }
        else
        {
            Debug.Log($"{collision.gameObject.name} has no tag you!");
        }
    }
}
