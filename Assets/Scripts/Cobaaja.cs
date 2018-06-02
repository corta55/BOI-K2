using UnityEngine;

public class Cobaaja : MonoBehaviour {

	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left*10*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * 10 * Time.deltaTime);
        }
    }
}
