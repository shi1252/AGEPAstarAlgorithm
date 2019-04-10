using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue
{
    Node[] data;
    int count = 0;

    public PriorityQueue(int size)
    {
        data = new Node[size];
    }

    public void Enqueue(Node item)
    {
        data[count++] = item;
        Compare(count - 1);
    }

    public Node Dequeue()
    {
        if (Count <= 0)
            return null;

        Node ret = data[0];
        int last = Count - 1;
        data[0] = data[last];
        count--;

        last--;
        int i = 0;
        if (Count > 0)
        {
            while (true)
            {
                int lc = i * 2 + 1;
                if (lc > last) break;
                int rc = lc + 1;
                if (rc <= last && data[rc].Compare(data[lc]) < 0)
                    lc = rc;
                if (data[i].Compare(data[lc]) < 0) break;
                Node temp = data[i];
                data[i] = data[lc];
                data[lc] = temp;
                i = lc;
            }
        }
        return ret;
    }

    public void Compare(int i)
    {
        while (i > 0)
        {
            int j = (i - 1) / 2;

            int compare = data[i].Compare(data[j]);

            if (compare > 0) break;
            else if (compare < 0)
            {
                Node temp = data[i];
                data[i] = data[j];
                data[j] = temp;
            }
            else
            {
                if (data[i].gCost > data[j].gCost)
                {
                    Node temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
            i = j;
        }
    }

    public int Count { get { return count; } }

    public bool Contains(Node item)
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i] == item)
                return true;
        }
        return false;
    }

    public int IndexOf(Node item)
    {
        int i = 0;
        for (; i < count; i++)
        {
            if (data[i] == item) break;
        }
        return i;
    }
}