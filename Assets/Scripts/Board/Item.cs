using System;
using System.Linq;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class Item
{

    public ItemProfile ItemProfile;

    public Cell Cell { get; private set; }

    public Transform View { get; private set; }


    public virtual void SetView(GameObject item, ItemProfile[] itemProfiles)
    {
        string prefabname = GetPrefabName();
        if (!string.IsNullOrEmpty(prefabname))
        {
            View = item.Spawn().transform;
            View.GetComponent<SpriteRenderer>().sprite = itemProfiles.Where(i => i.Name == prefabname).First().Sprites[1];

            //GameObject prefab = Resources.Load<GameObject>(prefabname);
            //if (prefab)
            //{
            //    View = GameObject.Instantiate(prefab).transform;
            //    Debug.Log(itemProfiles.Where(i => i.Name == prefabname).First().Sprites[1].name);
            //}
        }
    }

    protected virtual string GetPrefabName() { return string.Empty; }

    public virtual void SetCell(Cell cell, ItemProfile itemProfile)
    {
        Cell = cell;
        ItemProfile = itemProfile;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 0;
        }

    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    //GameObject.Destroy(View.gameObject);
                    View.gameObject.Recycle();
                    View = null;
                    Cell = null;
                }
                );
        }
    }



    internal void AnimateForHint()
    {
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill(true);
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            //GameObject.Destroy(View.gameObject);
            View.gameObject.Recycle();
            View = null;
        }
    }
}
