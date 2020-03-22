using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{

    private void Start()
    {
		StartCoroutine(Destroy());
    }

	IEnumerator Destroy (){
		yield return new WaitForSeconds(3f);
		Destroy(this.gameObject);
	}
}
