
Shader "WaterShader" {

	//set properties
	Properties {
		_MainTex ("Diffuse(RGB) Spec(A)", 2D) = "white" {}
       	_BumpMap ("Bumpmap", 2D) = "bump" {}
     }
     SubShader {

     	//set rendertype and queue
       	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

       	CGPROGRAM
       	#pragma surface surf SimpleSpecular alpha

       	//2D textures
    	sampler2D _MainTex;
		sampler2D _BumpMap;
 
       	half4 LightingSimpleSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
			half4 c;

			// apply colour
			c.rgb = s.Albedo;

			//set semi transparency
			c.a = s.Alpha;
			return c;
       	}
 
       	struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
			float4 color: COLOR;
       	};

       	void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			// apply bump map to have more realistic feel of water
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
			o.Alpha = c.a;
       	}
       	ENDCG
     } 
     Fallback "Diffuse"
}