/*******************************************************************************
 File Name: UIManager.cs
 Descript:
 
 Version: 1.0
 Created Time: 2016/1/29 23:47:38
 Compiler: .NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: Jimbo
 mail: jimboo.lu@gmail.com
 
 Company: 
*******************************************************************************/

using System;

public class UIManager {
    public UIManager() {
        Capacity = 10;
        Count = 0;
        head = end = null;
    }

    public UIManager(int capacity) {
        if(0 < capacity) {
            Capacity = capacity;
        }
        else {
            capacity = 10;
        }
        Count = 0;
        head = end = null;
    }

    public int Count { get; private set; }
    public int Capacity { get; set; }

    Node head;
    Node end;

    public T Create<T>() where T : UIBase, new() {
        T obj;
        Node node = head;
        while(null != node) {
            if(node.Data is T) {
                Node pre = node.Pre;
                Node next = node.Next;
                if(null != pre) {
                    pre.Next = next;
                }
                if(null != next) {
                    next.Pre = pre;
                }
                node.Pre = null;
                node.Next = head;
                head.Pre = node;
                obj = node.Data as T;
                obj.Show();
                return obj;
            }
        }
        obj = new T();
        if(Count < Capacity) {
            Count++;
            node = new Node();
            node.Data = obj;
            if (1 == Count) {
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
        obj.Show();
        return obj;
    }

    public T Create<T>(EventArgs e) where T : UIBase, new() {
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
                obj.Show(e);
                return obj;
            }
        }
        obj = new T();
        if (Count < Capacity) {
            Count++;
            node = new Node();
            node.Data = obj;
            if (1 == Count) {
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
        obj.Show(e);
        return obj;
    }

    class Node {
        public Node() {
            Data = null;
            Pre = null;
            Next = null;
        }
        public UIBase Data { get; set; }
        public Node Pre { get; set; }
        public Node Next { get; set; }
    }
}
