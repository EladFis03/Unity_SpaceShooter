using UnityEngine;
using System.Collections;

namespace ModularSpaceshipPack
{
    public class AddColliders : MonoBehaviour
    {

        [ContextMenu("Add Colliders")]
        public void Add()
        {
            MeshFilter[] meshes = GetComponentsInChildren<MeshFilter>();
            for (int i = 0; i < meshes.Length; i++)
            {
                if(meshes[i].gameObject.GetComponent<MeshCollider>() == null)
                    meshes[i].gameObject.AddComponent<MeshCollider>();
            }
        }

        [ContextMenu("Remove Colliders")]
        public void Remove()
        {
            MeshCollider[] meshes = GetComponentsInChildren<MeshCollider>();
            int l = meshes.Length;
            for (int i = 0; i < l; i++)
            {
                DestroyImmediate(meshes[i]);
            }
        }

    }
}