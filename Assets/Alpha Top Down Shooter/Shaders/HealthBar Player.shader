Shader "Unlit/HealthBarPlayer"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _Health ("Health", Range(0,1)) = 1
        _HealthColorFull ("Full Health Color", Color) = (1, 1, 1, 1)
        _HealthColorLow ("Low Health Color", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 100

        Pass
        {
        
            ZWrite Off
            //Blend src * X + dst * y
            //src * srcAlpha + dst * (1-srcAlpha) like lerp
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Health;
            float4 _HealthColorFull;
            float4 _HealthColorLow;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
                }

            float4 frag (v2f i) : SV_Target
            {
                
                // sample the texture
                //float3 healbarColor = tex2D(_MainTex, float2(_Health, i.uv.y));
                float healthbarMask = _Health > i.uv.x;
                //clip(healthbarMask - 0.5); //Make full transparent, can't be mixed transparent
                
                float tHealthColor = saturate(InverseLerp(0.2, 0.8, _Health));
                float3 healthbarColor = lerp(_HealthColorLow, _HealthColorFull, tHealthColor);
                
                //float flash = cos(_Time.y * 1) * 0.4 + 1;
                
                //float flashSaturation = cos(_Time.y * 4) * 0.4 + 1;
                ///float flashHue = cos(_Time.y * 4) * 0.2;
                //healthbarColor *= flash;
                //float3 bgColor = float3(0,0,0);
                //float3 outColor = lerp(bgColor, healthbarColor, healthbarMask);
                
                return float4(healthbarColor * healthbarMask, 1);
                //return float4(healbarColor * flashSaturation, 1);
                //return float4(healbarColor + flashHue, 1);
            }
            ENDCG
        }
    }
}
