using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public enum NodeType { Ground, Path, Start, End};
    [SerializeField]
    NodeType m_type;
    public NodeType nodeType { get { return m_type; } set { m_type = value; } }

}
