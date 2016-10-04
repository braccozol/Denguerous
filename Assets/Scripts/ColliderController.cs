using UnityEngine;
using System.Collections;

public class ColliderController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {

        switch (col.gameObject.tag) {
            case "objeto":
                print(col.gameObject.name);
                break;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "objeto")
        {
            print(col.gameObject.name);
        }
    }

    void OnCollisionStay2D() {
        print("está batendo");
    }

    void OnTriggerEnter2D(Collider2D col) {
        switch (col.gameObject.tag) {
            case "objeto":
                print(col.gameObject.name);
                break;
        }
    }
}