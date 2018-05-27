using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Zenject.Tests
{
    public class TestSceneContextEvents : SceneTestFixture
    {
        [UnityTest]
        public IEnumerator TestScene()
        {
            yield return LoadScene();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
