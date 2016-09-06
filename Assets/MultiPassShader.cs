using UnityEngine;

namespace XJ.Unity3D.ImageEffects
{
    [RequireComponent(typeof(Camera))]
    [ExecuteInEditMode]
    [AddComponentMenu("XJImageEffects/MultiPassShader")]
    public class MultiPassShader : ImageEffect
    {
        protected override void OnRenderImage
            (RenderTexture source, RenderTexture destination)
        {
            // source から renderTexture へ描画するときに Pass 0 を使い、
            // renderTexture から null ( = Screen) へ描画するときに Pass 1 を使う。
            // Blit 関数の引数 dest が null のとき、スクリーンに描画される。

            RenderTexture renderTexture = new RenderTexture
                (source.width, source.height, source.depth, source.format);

            Graphics.Blit(source, renderTexture, base.Material, 0);
            Graphics.Blit(renderTexture, null, base.Material, 1);
        }
    }
}