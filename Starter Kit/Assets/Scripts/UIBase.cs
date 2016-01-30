/*******************************************************************************
 File Name: UIBase.cs
 Descript:
 
 Version: 1.0
 Created Time: 2016/1/29 23:45:21
 Compiler: .NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: Jimbo
 mail: jimboo.lu@gmail.com
 
 Company: 
*******************************************************************************/

using System;
using UnityEngine;

public class UIBase : MonoBehaviour {

    public UIBase() {

    }

    public virtual void Show() {

    }

    public virtual void Show(EventArgs e) {

    }

    public void Close() {
        if(gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
        }
    }

    public void Delete() {
        Destroy(gameObject);
    }
}
