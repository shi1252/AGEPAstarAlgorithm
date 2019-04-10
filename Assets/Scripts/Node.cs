using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;
    public Node parent = null;
    public int gCost;
    public int hCost;
    public int fCost {  get { return gCost + hCost; } }

	public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
	{
		this.walkable = _walkable;
		this.worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}

    public int Compare(Node item)
    {
        if (fCost < item.fCost)
            return -1;
        else if (fCost == item.fCost)
        {
            if (gCost < item.gCost)
                return 0;
            return 1;
        }
        return 2;
    }
}
