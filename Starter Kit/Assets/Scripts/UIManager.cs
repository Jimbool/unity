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
        head = new Node();
        end = head;
        Capacity = capacity;
        Count = 0;
    }

    public int Capacity { get; set; }
    public int Count { get; private set; }

    Node head;
    Node end;

    public T Create<T>(EventArgs e = null) where T : UIBase, new() {
        T obj;
        Node node = head;
        while(end != node) {
            if (node.Data is T) {
                Node pre = node.Pre;
                pre.Next = node.Next;
                node.Next = head;
                head.Pre = node;
                head = node;
                obj = node.Data as T;
                obj.Show(e);
                return obj;
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
        while (end != node) {
            if (node.Data is T) {
                Node pre = node.Pre;
                Node next = node.Next; 
                pre.Next = node.Next;
            }
            node = node.Next;
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
姓    名：卢建波                        性   别：男
出生年月：1991/10/28                    籍   贯：四川乐山
毕业学校：成都东软学院                  专   业：网络工程
联系电话：13908079090                   E-mail  ：986652618@qq.com 
个人主页:  https://github.com/Jimbool/unity
           http://ermao.sinaapp.com/