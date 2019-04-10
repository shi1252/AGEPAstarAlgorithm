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
        int i = count - 1;

        while (i > 0)
        {
            int j = (i - 1) / 2;
            int compare = data[i].Compare(data[j]);
            if (compare > 0) break;
            Swap(i, j);
            i = j;
        }
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
                if (rc <= last && data[rc].Compare(data[lc]) < 1)
                    lc = rc;
                int compare = data[lc].Compare(data[i]);
                if (compare > 0) break;
                Swap(i, lc);
                i = lc;
            }
        }
        return ret;
    }

    public void Swap(int n1, int n2)
    {
        Node temp = data[n1];
        data[n1] = data[n2];
        data[n2] = temp;
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
}