using UnityEngine;

public class RayHelper {

    public static bool Cast(Ray ray, out RaycastHit hit, float range, int layerMask){
        return Physics.Raycast(ray, out hit, 100f, layerMask);
    }

    public static bool Cast(Ray ray, out RaycastHit hit, float range){
        return Physics.Raycast(ray, out hit, 100f);
    }

    public static int allButLayerMask(int layerId){
		return ~(onlyLayerMask(layerId)); 
	}

	public static int onlyLayerMask(int layerId){
		return 1 << layerId;
	}

    public static int allButLayerMask(string layerName){
		return allButLayerMask(LayerMask.NameToLayer(layerName)); 
	}

	public static int onlyLayerMask(string layerName){
		return onlyLayerMask(LayerMask.NameToLayer(layerName)); 
	}
}