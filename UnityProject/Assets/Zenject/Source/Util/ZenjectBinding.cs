#if !ZEN_NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using ModestTree;

namespace Zenject
{
    // We include Zenject as a prefix to make it obvious to whoever sees it in the scene what it is, since
    // it will likely be spread out throughout the scene
    [ExecuteInEditMode]
    public class ZenjectBinding : MonoBehaviour
    {
        [SerializeField]
        Component _component = null;

        [SerializeField]
        BindTypes _bindType = BindTypes.ToInstance;

        // Strip out update method for release builds
        // The only reason we don't wrap this in #if UNITY_EDITOR is to support
        // the ability to put zenject into a DLL
        [Conditional("DEBUG")]
        public void Update()
        {
            if (Application.isEditor)
            {
                if (_component != null && _component.gameObject != this.gameObject)
                {
                    // This isn't actually necessary but I like to enforce this to avoid people adding confusing links
                    // to different objects around in the scene
                    Log.Warn("ZenjectBinding should only be hooked up to components on the same game object");
                    _component = null;
                }

                // This is nice so that it automatically adds the reference when you add it
                // though of course it can get it wrong sometimes
                // It also means that you can't set _component to null, but in that case it should just be deleted then
                if (_component == null)
                {
                    _component = this.gameObject.GetComponents<Component>()
                        .Where(x => !(x is Transform) && !(x is ZenjectBinding)).FirstOrDefault();
                }
            }
        }

        public Component Component
        {
            get
            {
                return _component;
            }
        }

        public BindTypes BindType
        {
            get
            {
                return _bindType;
            }
        }

        public enum BindTypes
        {
            ToInstance,
            ToInterfaces,
            ToInstanceAndInterfaces,
        }
    }
}

#endif

