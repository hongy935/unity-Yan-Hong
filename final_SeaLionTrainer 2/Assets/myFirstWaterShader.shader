Shader "Unlit/myFirstWaterShader" //name how it appears in unity
{
	Properties //"public variables" of your shader
	{
		//declare a "Texture" variable for inspector
		_MainTex ("Texture", 2D) = "white" {}
		_waveHeight("Wave Height", Float) = 0.5
		_waveFreq("Wave Frequency", Float) = 2
	}
	SubShader //where our shader code actually starts
	{
		Tags { "RenderType"="Opaque" }
		LOD 100 //LOD = "level of detail"
		//more expensive shader have higher LOD

		Pass // one "update" for your GPU
		{
		//where our CG/HLSL code actually starts
			CGPROGRAM // HLSL used to be called "CG"
			#pragma vertex vert //the vertex shader is called "vert"
			#pragma fragment frag //fragment shader is called "frag"
			// make fog work
			#pragma multi_compile_fog

			//import all the shader libraries that unity wrote already
			#include "UnityCG.cginc" //cg inc = CG included

			//struct = like a class, container for data
			//appdata = data we pass from Maya model > vertex shader
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			//vertex 2 fragment, data from vertex shader to fragment shader
			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			//more variable declarations for use in our shader code
			sampler2D _MainTex; //this has a twin in Properties
			float4 _MainTex_ST; // ST = scale/transformation,  float4=4 floats automatically generated
			float _waveHeight;
			float _waveFreq;

			//vertex function
			v2f vert (appdata v)
			{
				v2f o;
				//multiply outside sin wave to adjust amplitude(height)
				//multiply inside sin wave to adjust frequency(speed)
				v.vertex += float4(0, sin(_Time.y*_waveFreq + v.vertex.x + v.vertex.z)*_waveHeight, 0, 0);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}


			//fragment program
			//fixed = more optimized"float"
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.y, _Time.x)*0.1);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG // CG/HLSL code ends
		}
	}
}
