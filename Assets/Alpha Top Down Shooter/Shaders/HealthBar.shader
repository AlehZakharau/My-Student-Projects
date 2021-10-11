Shader "Unlit/HealthBar"
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
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            //float _Health;
            float4 _HealthColorFull;
            float4 _HealthColorLow;
            
            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_DEFINE_INSTANCED_PROP(float, _Health)
            UNITY_INSTANCING_BUFFER_END(Props)

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v,o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
                }

            float4 frag (v2f i) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(i);
                float health = UNITY_ACCESS_INSTANCED_PROP(Props, _Health);
                
                // sample the texture
                //float3 healbarColor = tex2D(_MainTex, float2(_Health, i.uv.y));
                float healthbarMask = health > i.uv.x;
                //clip(healthbarMask - 0.5); //Make full transparent, can't be mixed transparent
                
                float tHealthColor = saturate(InverseLerp(0.2, 0.8, health));\
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
