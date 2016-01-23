/*******************************************************************************
 File Name: UIManager.cs
 Descript:
    instance pool
 Version: 3.1
 Created Time: 2016/1/20 18:48:20
 Compiler: NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: Jimbo
 mail: jimboo.lu@gmail.com
 
 Company:
*******************************************************************************/

using System;

public class UIManager {

    public UIManager(int capacity = 10) {
        head = null;
        Capacity = capacity;
        Count = 0;
    }

    public int Capacity { get; set; }
    public int Count { get; private set; }

    Node head;

    public T Create<T>(EventArgs e = null) where T : UIBase, new() {
        T obj;
        if(null == head) {
            head = new Node();
            obj = new T();
            head.Data = obj;
            return obj;
        }
        Node node = head;
        while(true) {
            if (node.Data is T) {
                Node pre = node.Pre;
                pre.Next = node.Next;
                node.Next = head;
                head.Pre = node;
                head = node;
                return node.Data as T;
            }
            if(null == node.Next) {
                break;
            }
            node = node.Next;
        }
        if(Count >= Capacity) {
            obj = new T();
            obj.Show(e);
            UIBase o = node.Data;
            o.Delete();
            node.Data = obj;
            Node pre = node.Pre;
            pre.Next = null;
            node.Pre = null;
            node.Next = head;
            head.Pre = node;
            head = node;
            return obj;
        }
        else {
            obj = new T();
            Node newNode = new Node();
            newNode.Data = obj;
            newNode.Next = head;
            head.Pre = newNode;
            head = newNode;
            Count++;
        }
        obj.Show(e);
        return obj;
    }

    public void Delete<T>() where T : UIBase {
        if(null == head) {
            return;
        }
        Node node = head;
        Node d = head;
        while(true) {
            if (node.Data is T) {
                d = node;
            }
            if(null == node.Next) {
                break;
            }
            node = node.Next;
        }
        if(d != node) {
            Node pre = d.Pre;
            Node next = d.Next;
            pre.Next = next;
            next.Pre = pre;
            node.Next = d;
            d.Pre = node;
        }
    }

    class Node {
        public Node() {
            Data = null;
            Next = null;
            Pre = null;
        }

        public UIBase Data { get; set; }
        public Node Next { get; set; }
        public Node Pre { get; set; }
    }
}
