using UnityEngine;
using System;

public class UIBase : MonoBehaviour {
    
    public virtual void Show(EventArgs e) {

    }

    public void Delete() {
        Destroy(gameObject);
    }
}
