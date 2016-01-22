/*******************************************************************************
 File Name: UIManager.cs
 Descript:
 
 Version: 3.1
 Created Time: 2016/1/20 18:48:20
 Compiler: NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: 
 mail: 
 
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

    public T Create<T>(EventArgs e = null) where T : UIBase, new() {
        Node node = head;
        Node pre = head;
        while(null != node) {
            if(node.Data is T) {
                pre.Next = node.Next;
                node.Next = head;
                head = node;
                return node.Data as T;
            }
            pre = node;
            node = node.Next;
        }
        T obj = new T();
        if(null == node) {
            node = new Node();
            node.Data = obj;
            return obj;
        }
        Node newNode = new Node();
        newNode.Data = obj;
        newNode.Next = head;
        head = newNode;
        Count++;
        if (Count > Capacity) {
            Clean();
        }
        obj.Show(e);
        return obj;
    }

    public void Destory<T>() where T : UIBase {
        if(null == head) {
            return;
        }
        Node node = head;
        Node pre = head;
        while(null != node) {
            if(node.Data is T) {
                pre.Next = node.Next;
                Count--;
                break;
            }
            pre = node;
            node = node.Next;
        }
    }

    class Node {
        public Node() {
            Data = null;
            Next = null;
        }

        public UIBase Data { get; set; }
        public Node Next { get; set; }
    }

    Node head;

    void Clean() {
        if(null == head) {
            return;
        }
        Node node = head;
        int i = 0;
        while (i < Capacity && null != node) {
            node = node.Next;
            i++;
        }
        Count = i;
        if(null != node.Next) {
            node.Next = null;
        }
    }
}
