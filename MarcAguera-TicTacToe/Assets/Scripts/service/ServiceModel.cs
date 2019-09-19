using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ServiceModel : IServiceModel
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public MenuSignal menuSignal { get; set; }

    private GameObject _bundle;

    public GameObject cellGO
    {
        get
        {
            return _bundle;
        }
    }


    public IEnumerator LoadBundle()
    {
        while (!Caching.ready)
        {
            yield return null;
        }

        //Begin download
        WWW www = WWW.LoadFromCacheOrDownload("https://www.dropbox.com/s/73kyy8jmb5v2swl/Cell.unity3d?dl=1", 0);
        yield return www;

        //Load the downloaded bundle
        AssetBundle bundle = www.assetBundle;

        //Load an asset from the loaded bundle
        AssetBundleRequest bundleRequest = bundle.LoadAssetAsync("Cell", typeof(GameObject));
        yield return bundleRequest;

        //get object
        _bundle = bundleRequest.asset as GameObject;

        menuSignal.Dispatch();

        bundle.Unload(false);
        www.Dispose();
    }

    public void Load()
    {
        MonoBehaviour root = contextView.GetComponent<GameRoot>();
        root.StartCoroutine(LoadBundle());
    }
}
