// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UI/CutoutShader"
{
    Properties
    {
        _PanelColor ("Color", color) = (0, 0, 0, 1)
        _CutoutCenterX ("Center X", Range(0,1000)) = 1.0
        _CutoutCenterY ("Center Y", Range(0,1000)) = 1.0
        _CutoutSize ("Size", float) = 5.0
        _CutoutBlend ("Blend", Range(0,25)) = 0
    }
    SubShader
    {         
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane"}
        
        // No depth
        ZWrite Off ZTest Always
        
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }


            float _CutoutCenterX;
            float _CutoutCenterY;
            float4 _PanelColor;
            float _CutoutSize;
            float _CutoutBlend;

            bool isInsideEllipsis(float2 center, float ellipsisWidth, float ellipsisHeight, float2 targetPoint)
            {
                
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _PanelColor;
/*
                 // Calculate distance to player position
                float2 screenPos = ComputeScreenPos(UnityObjectToClipPos(i.vertex)).xy / 2;
                float2 screenPosInPixel = float2(screenPos.x * _ScreenParams.x, screenPos.y * _ScreenParams.y);
                float dist = distance(screenPosInPixel, float2(_CutoutCenterX, _CutoutCenterY));

                const float smallCircleSize = _CutoutSize - _CutoutBlend /2;
                const float bigCircleSize =  _CutoutSize + _CutoutBlend /2;
      
                  // Return appropriate colour
                 if (dist < smallCircleSize) {
                     discard;
                     //col.a = 0.01;
                 }
                 if (dist < bigCircleSize) {
                     col.a = lerp(0, col.a, (dist-smallCircleSize) / _CutoutBlend);
                 }
                
                return col;
                */
                
                float2 screenPos = i.uv * _ScreenParams;
                float2 targetPos = float2(_CutoutCenterX, _CutoutCenterY) * _ScreenParams;
                
                float dist = distance(screenPos, targetPos);

                const float smallCircleSize = _CutoutSize - _CutoutBlend /2;
                const float bigCircleSize =  _CutoutSize + _CutoutBlend /2;
      
                  // Return appropriate colour
                 if (dist < smallCircleSize) {
                     discard;
                     //col.a = 0.01;
                 }
                 if (dist < bigCircleSize) {
                     col.a = lerp(0, col.a, (dist-smallCircleSize) / _CutoutBlend);
                 }
                
                return col;
            }
            ENDCG
        }
    }
}
