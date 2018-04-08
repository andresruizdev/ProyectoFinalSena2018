using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStreet : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Delete(other));
    }

    //Corrutina que elimina la calle tras terminar de pasarla
    IEnumerator Delete(Collider other)
    {
        yield return new WaitForSeconds(2);
        if (other.tag == "Player")
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
