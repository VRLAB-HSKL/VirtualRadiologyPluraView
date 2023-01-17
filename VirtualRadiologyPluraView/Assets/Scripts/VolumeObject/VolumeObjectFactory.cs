using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Text;
using DefaultNamespace;
using Debug = UnityEngine.Debug;

namespace UnityVolumeRendering
{
    public class VolumeObjectFactory
    {
        private const int noiseDimX = 512;
        private const int noiseDimY = 512;

        public static VolumeRenderedObject CreateObject(VolumeDataset dataset)
        {
            GameObject outerObject = new GameObject("VolumeRenderedObject_" + dataset.datasetName);
            VolumeRenderedObject volObj = outerObject.AddComponent<VolumeRenderedObject>();

            GameObject meshContainer = GameObject.Instantiate((GameObject)Resources.Load("VolumeContainer"));
            meshContainer.transform.parent = outerObject.transform;
            meshContainer.transform.localScale = Vector3.one;
            meshContainer.transform.localPosition = Vector3.zero;
            meshContainer.transform.parent = outerObject.transform;
            outerObject.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

            MeshRenderer meshRenderer = meshContainer.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(meshRenderer.sharedMaterial);
            volObj.meshRenderer = meshRenderer;
            volObj.dataset = dataset;

            const int noiseDimX = 512;
            const int noiseDimY = 512;
            Texture2D noiseTexture = NoiseTextureGenerator.GenerateNoiseTexture(noiseDimX, noiseDimY);

            TransferFunction tf = TransferFunctionDatabase.CreateTransferFunction();
            Texture2D tfTexture = tf.GetTexture();
            volObj.transferFunction = tf;

            TransferFunction2D tf2D = TransferFunctionDatabase.CreateTransferFunction2D();
            volObj.transferFunction2D = tf2D;

            meshRenderer.sharedMaterial.SetTexture("_DataTex", dataset.GetDataTexture());
            meshRenderer.sharedMaterial.SetTexture("_GradientTex", null);
            meshRenderer.sharedMaterial.SetTexture("_NoiseTex", noiseTexture);
            meshRenderer.sharedMaterial.SetTexture("_TFTex", tfTexture);

            meshRenderer.sharedMaterial.EnableKeyword("MODE_DVR");
            meshRenderer.sharedMaterial.DisableKeyword("MODE_MIP");
            meshRenderer.sharedMaterial.DisableKeyword("MODE_SURF");

            if(dataset.scaleX != 0.0f && dataset.scaleY != 0.0f && dataset.scaleZ != 0.0f)
            {
                float maxScale = Mathf.Max(dataset.scaleX, dataset.scaleY, dataset.scaleZ);
                volObj.transform.localScale = new Vector3(dataset.scaleX / maxScale, dataset.scaleY / maxScale, dataset.scaleZ / maxScale);
            }

            return volObj;
        }


        /*public static IEnumerator CreateObjectRoutine(VolumeDataset dataset, Action<VolumeRenderedObject> vro)
        {
            Stopwatch sw = new Stopwatch();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("### CreateObjectRoutine ###");

            sw.Start();

            GameObject outerObject = new GameObject("VolumeRenderedObject_" + dataset.datasetName);
            VolumeRenderedObject volObj = outerObject.AddComponent<VolumeRenderedObject>();

            sw.Stop();
            sb.AppendLine("CreationTime: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;

            GameObject meshContainer = GameObject.Instantiate((GameObject)Resources.Load("VolumeContainer"));
            meshContainer.transform.parent = outerObject.transform;
            meshContainer.transform.localScale = Vector3.one;
            meshContainer.transform.localPosition = Vector3.zero;
            meshContainer.transform.parent = outerObject.transform;
            outerObject.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

            sw.Stop();
            sb.AppendLine("MeshContainer: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;

            MeshRenderer meshRenderer = meshContainer.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(meshRenderer.sharedMaterial);
            volObj.meshRenderer = meshRenderer;
            volObj.dataset = dataset;

            sw.Stop();
            sb.AppendLine("MeshRendererSet: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();


            yield return null;


            Texture2D noiseTexture = NoiseTextureGenerator.GenerateNoiseTexture(noiseDimX, noiseDimY);

            sw.Stop();
            sb.AppendLine("NoiseTextureGeneration: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;

            TransferFunction tf = TransferFunctionDatabase.CreateTransferFunction();
            Texture2D tfTexture = tf.GetTexture();
            volObj.transferFunction = tf;

            sw.Stop();
            sb.AppendLine("TransferfunctionCreation: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;

            TransferFunction2D tf2D = TransferFunctionDatabase.CreateTransferFunction2D();
            volObj.transferFunction2D = tf2D;

            sw.Stop();
            sb.AppendLine("2dTransferFunctionCreation: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;


            //Texture3D dataTexture = dataset.GetDataTextureRef();


            Texture3D dataTexture = null;
            //yield return dataset.GetDataTextureRoutine(x => dataTexture = x);

            yield return VolumeDatasetTextureCalc.CreateTextureInternalRoutine(
                dataset.dimX, dataset.dimY, dataset.dimZ,
                dataset.data, x => dataTexture = x);

            dataset.dataTexture = dataTexture;

            if (dataTexture is null)
                Debug.Log("dataTexture is null");

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_GetDataTexture: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            meshRenderer.sharedMaterial.SetTexture("_DataTex", dataTexture);

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_SetDataTexture: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            yield return null;

            meshRenderer.sharedMaterial.SetTexture("_GradientTex", null);

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_GradientTex: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            meshRenderer.sharedMaterial.SetTexture("_NoiseTex", noiseTexture);

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_NoiseTex: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();


            meshRenderer.sharedMaterial.SetTexture("_TFTex", tfTexture);

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_TFTex: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();


            yield return null;

            meshRenderer.sharedMaterial.EnableKeyword("MODE_DVR");
            meshRenderer.sharedMaterial.DisableKeyword("MODE_MIP");
            meshRenderer.sharedMaterial.DisableKeyword("MODE_SURF");

            sw.Stop();
            sb.AppendLine("ShaderTextureSet_Keywords: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            //return volObj;

            Debug.Log(sb);

            vro(volObj);
        }*/

        public static void SpawnCrossSectionPlane(VolumeRenderedObject volobj)
        {
            GameObject quad = GameObject.Instantiate((GameObject)Resources.Load("CrossSectionPlane"));
            quad.transform.rotation = Quaternion.Euler(270.0f, 0.0f, 0.0f);
            CrossSectionPlane csplane = quad.gameObject.GetComponent<CrossSectionPlane>();
            csplane.SetTargetObject(volobj);
            quad.transform.position = volobj.transform.position;

#if UNITY_EDITOR
            UnityEditor.Selection.objects = new UnityEngine.Object[] { quad };
#endif
        }

        public static void SpawnCutoutBox(VolumeRenderedObject volobj)
        {
            GameObject obj = GameObject.Instantiate((GameObject)Resources.Load("CutoutBox"));
            obj.transform.rotation = Quaternion.Euler(270.0f, 0.0f, 0.0f);
            CutoutBox cbox = obj.gameObject.GetComponent<CutoutBox>();
            cbox.SetTargetObject(volobj);
            obj.transform.position = volobj.transform.position;

#if UNITY_EDITOR
            UnityEditor.Selection.objects = new UnityEngine.Object[] { obj };
#endif
        }
    }
}
