/*
Edge Collider 2D to Pollygon Collider 2D by Hawken King http://hawkenking.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EC2PC : MonoBehaviour {

	public bool convertToTriggers;

	void Start () {
		EdgeCollider2D[] edgeColliders = gameObject.GetComponentsInChildren<EdgeCollider2D>();
		foreach (EdgeCollider2D coll in edgeColliders) {
			// myPoints.Clear();
			Vector2[] myPoints = coll.points;
			int myEdges = coll.edgeCount;
			PolygonCollider2D myPoly = coll.gameObject.AddComponent<PolygonCollider2D>();
			myPoly.points = myPoints;
			myPoly.pathCount = 1;
			myPoly.SetPath(0,myPoints);
			if (convertToTriggers) myPoly.isTrigger = true;
			Destroy(coll);
		}
	}
}
