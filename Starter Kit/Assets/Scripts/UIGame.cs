/*******************************************************************************
 File Name: UIGame.cs
 Descript:
        objects pool, simple factory
 Version: 2.0
 Created Time: 2016/1/29 23:45:21
 Compiler: .NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: Jimbo
 mail: jimboo.lu@gmail.com
 
 Company: 
*******************************************************************************/

using System;
using UnityEngine;

public class UIGame : MonoBehaviour {

    private static Node head = null;
    private static Node end = null;
    private static int count = 0;
    private static int capacity = 10;

    public static T Create<T>() where T : UIGame, new() {
        T obj;
        Node node = head;
        while (null != node) {
            if (node.Data is T) {
                Node pre = node.Pre;
                Node next = node.Next;
                if (null != pre) {
                    pre.Next = next;
                }
                if (null != next) {
                    next.Pre = pre;
                }
                node.Pre = null;
                node.Next = head;
                head.Pre = node;
                obj = node.Data as T;
                return obj;
            }
            node = node.Next;
        }
        obj = new T();
        if (count < capacity) {
            count++;
            node = new Node();
            node.Data = obj;
            if (1 == count) {
                head = node;
                end = node;
            }
            else {
                node.Next = head;
                head.Pre = node;
                head = node;
            }
        }
        else {
            node = end;
            end = node.Pre;
            node.Data = obj;
            end.Next = null;
            node.Pre = null;
            node.Next = head;
            head.Pre = node;
            head = node;
        }
        return obj;
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

    private class Node {
        public Node() {
            Data = null;
            Pre = null;
            Next = null;
        }
        public UIGame Data { get; set; }
        public Node Pre { get; set; }
        public Node Next { get; set; }
    }
}
