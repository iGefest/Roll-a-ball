using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
	public Text countText;
	public Text winText;

    private Rigidbody rb;
	private int count;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
    }

     void FixedUpdate()
    {
        float moveHorizaontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizaontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 11) 
		{
			winText.text="You Win!";
		}
	}
}
