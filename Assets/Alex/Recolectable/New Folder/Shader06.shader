Shader "IFP/Shader06"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _ColorFresnel ("ColorFresnel", Color) = (0,0,0,0)
        _Intensidad ("Intensidad", Float) = 0
        _LineWidth ("LineWidth", Float) = 0
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex VShader
            #pragma fragment FShader

            #include "UnityCG.cginc"

            struct VSInput
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 cam : TEXCOORD1;
                //float dir : TEXCOORD2;
                fixed4 ret2 : TEXCOORD3;
            };

            struct VSOutput
            {
                float2 uv : TEXCOORD0;
                float4 position : SV_POSITION;
                float3 normal : NORMAL;
                float4 cam : TEXCOORD1;
                //float dir : TEXCOORD2;
                fixed4 ret2 : TEXCOORD3;
            };

            sampler2D _MainTex;
            sampler2D _Mask;
            float4 _ColorFresnel;
            float _Intensidad;
            float _LineWidth;
            
            VSOutput VShader(VSInput i)
            {
                VSOutput o;
                
                float4 positionO = i.position;
                
                float4 positionW = mul(UNITY_MATRIX_M, positionO);
                
                float4 positionC = mul(UNITY_MATRIX_V, positionW);
                
                float4 positionS = mul(UNITY_MATRIX_P, positionC);


                o.position = positionS;
                o.uv = i.uv;

                float4 normW = mul(UNITY_MATRIX_M, i.normal);
                float4 normC = mul(UNITY_MATRIX_V, normW);

                o.normal = normC;
                o.cam = positionC;

                fixed4 texColor = tex2D(_MainTex , i.uv);

                float dir = 1 - dot(normalize(i.cam), -normalize(i.normal));

                fixed4 ret2 = dir * _Intensidad < _LineWidth ? texColor : _ColorFresnel;

                                
                return o;
            }

            float4 FShader(VSOutput i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex , i.uv);

                float dir = 1 - dot(normalize(i.cam), -normalize(i.normal));

                fixed4 ret2 = dir * _Intensidad < _LineWidth ? texColor : _ColorFresnel;

                return ret2;
            }
            
            ENDCG
        }
    }
}